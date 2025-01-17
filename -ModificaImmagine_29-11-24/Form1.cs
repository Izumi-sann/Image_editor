/*
 * ->int colorValues[] red, green, blue
 * ->string image_path
 * 
 * Load image
 * -search direcotry
 *      -dialogo
 *      -verifica directory
 * -Display_image
 * 
 * 
 * change color
 * -add/remove red
 * -add/remove blue
 * -add/remove green
 * 
 * Save_image
 * 
 */
/*TODO
 */

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace _ModificaImmagine_29_11_24
{
    public partial class Form1 : Form
    {
//******** main variables ********//
        int[] colorValuesRGB = new int[] { 0, 0, 0 };//modificatori dei valori red, green, blue
        string ImagePath = "";
        Image base_image; //una copia dell'immagine senza modifiche(con i ribaltamenti) per risolvere il problema di modifica dei colori

        //un contatore per verificare se l'immagine � stata routata verticalmente o orizzontalmente o invertita;
        //� necessario quando si va a modificare i colori dell'immagine, siccome tale funzione usa "base_image" per settare i nuovi colori, e pertanto � prima da ruotare se necessario
        bool[] orientation_flag = new bool[] { false, false };//vertical, horizontal
        bool invert_flag = false;

        //salvataggi delle modifiche per backtraking, salva base_image e PictureBox.Image, l'immagine � salvata per ogni cambiamento, per un massimo di 20 passi
        List<(Image base_image, Image picturebox_image, int[] color_values)> Image_versions;
        int version_counter = 0;

        public Form1() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e) { }


//**************** MAIN FUNCTIONS ****************//
        private void LoadImage(object sender, EventArgs e) //central function to load the image onto the app
        {
            try { ImagePath = File_dialog_search(); }
            catch { return; }

            //change form caption
            Text = $"image - {ImagePath} - saved";

            //load image
            PictureBox.Load(ImagePath);
            base_image = new Bitmap(ImagePath);

            //insert base_image as the first version
            Image_versions = new List<(Image base_image, Image picturebox_image, int[] color_values)>();
            version_counter = 0;

            //enable various buttons
            EnableButtons("enable_all");

            //set the color values and labels
            colorValuesRGB = new int[] { 0, 0, 0 };
            red_value_output.Text = "0";
            green_value_output.Text = "0";
            blue_value_output.Text = "0";

            Image_versions.Add((base_image, PictureBox.Image, new int[] {colorValuesRGB[0], colorValuesRGB[1], colorValuesRGB[2]}));
        }

        /// <summary>
        /// used to manage every function int the program regarding the modification of the image
        /// </summary>
        private void ModifyImage(object sender, EventArgs e)//central function to modify the visualized imageaa
        {
            /*change color: 
             * is based on "base_image, not on the current image displayed; 
             * when the color is changed we take "base_iamge" and add the 3 values(rgb). 
             * we don't add the 3 values to the current displayed because 
             * if a pixel has a red value = 6, and you remove 10 (two times) you get 0, and at the same time on another pixel with a start red value = 255 we get 235
             * so now if we add 10 we get pixel1 = 10, pixel2 = 245...which is different from the initial image.
             * the problem cease to exists if we modify the displayed image starting from the "base image" values.
             * to mantain the correct orientation of displayed image we need to reverse "base_image" if needed before changing colors, since we start from it.
             */
            //here we change the orientation of "base_image" to correctly change color after
            void Get_BaseImage_Ready()
            {
                if (orientation_flag[0])
                {
                    ModifyImageOrientation("vertical", ref base_image);
                    orientation_flag[0] = false;
                }
                if (orientation_flag[1])
                {
                    ModifyImageOrientation("horizontal", ref base_image);
                    orientation_flag[1] = false;
                }
                if (invert_flag) {
                    base_image = assemble_image(ApplyInvertFilter(new Bitmap(base_image)));
                    invert_flag = !invert_flag;
                }

            }

            string tag = ((Button)sender).Tag.ToString();
            
            switch (tag) {
                case "change_color":
                    ChangeColorValues(sender);//modify the color values in colorValuesRGB
                    Get_BaseImage_Ready();//change orientation of "base_image" since we use that one to change colors, and we need to set the orientation as the one displayed
                    ModifyImageColors(sender, "set_values");//the colors are changed here
                    break;
                case "invert_filter":
                    Get_BaseImage_Ready();//change orientation of "base_image" since we use that one to change colors, and we need to set the orientation as the one displayed
                    ModifyImageColors(sender, "invert");//the colors are changed here
                    invert_flag = !invert_flag;
                    break;
                case "sepia_filter":
                    Get_BaseImage_Ready();
                    ModifyImageColors(sender, "sepia");
                    break;
                case "reverse_vertical":
                    Image verticalFlippedImage = PictureBox.Image;//we can't directly pass PictureBox.Image with ref, so we use a temporary variable
                    ModifyImageOrientation("vertical", ref verticalFlippedImage);
                    PictureBox.Image = verticalFlippedImage;
                    orientation_flag[0] = !orientation_flag[0];
                    break;
                case "reverse_horizontal":
                    Image horizontalFlippedImage = PictureBox.Image;//we can't directly pass PictureBox.Image with ref, so we use a temporary variable
                    ModifyImageOrientation("horizontal", ref horizontalFlippedImage);
                    PictureBox.Image = horizontalFlippedImage;
                    orientation_flag[1] = !orientation_flag[1];
                    break;
            }

            if (!Text.Contains("not saved"))
                Text = $"image - {ImagePath} - not saved";

            //manage image version
            try {
                //Image_versions[version_counter+1] = (base_image, PictureBox.Image, new int[] { colorValuesRGB[0], colorValuesRGB[1], colorValuesRGB[2] });
                Image_versions.Insert(version_counter + 1, (base_image, PictureBox.Image, new int[] { colorValuesRGB[0], colorValuesRGB[1], colorValuesRGB[2] }));
            } catch { 
                Image_versions.Add((base_image, PictureBox.Image, new int[] { colorValuesRGB[0], colorValuesRGB[1], colorValuesRGB[2] }));
            }

            version_counter++;
            EnableButtons("version_counter");
        }

        /// <summary>
        /// used to manage every function regarding modifing the image's colors, invert colors or set colors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="option"> tells which function to use, can be "set_values" or "invert" or "sepia"</param>
        private void ModifyImageColors(object sender, string option)//used in whichever case i change the image's colors
        {
            EnableButtons("disable_processing");
            Cursor.Current = Cursors.WaitCursor;

            Bitmap MyBitmap = option == "set_values" ? new Bitmap(base_image) : new Bitmap(PictureBox.Image);//crea matrice bitmap. se bisogna cambiare colore con i singoli valori usa base_image, in caso contrario PicturBox.Image
            Bitmap pixel_matrix = ModifyColorsMatrix(MyBitmap, option);//modifica colori pixel matrice
            Image modified_image = assemble_image(pixel_matrix);//riassebla la matrice in un oggetto Image
            PictureBox.Image = modified_image;

            EnableButtons("enable_all");
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// used to manage every function regarding modifing the image's colors, invert colors or set colors
        /// </summary>
        /// <param name="orientation">the orientation we need, can be "vertical" or "horizontal"</param>
        /// <param name="toReverse"> an image to reverse, since it doesn't directly use PictureBox.Image</param>
        private void ModifyImageOrientation(string orientation, ref Image toReverse)//used if i need to change orientation
        {
            //both vertically and horizontally

            EnableButtons("disable_processing");
            Cursor.Current = Cursors.WaitCursor;

            Bitmap MyBitmap = new Bitmap(toReverse);//crea matrice bitmap
            Bitmap pixel_matrix;
            try
            {
                pixel_matrix = ModifyOrientationMatrix(MyBitmap, orientation);//modifica colori pixel matrice
            }
            catch { return; }

            toReverse = assemble_image(pixel_matrix);//riassebla la matrice nell'oggetto richiesto
            //PictureBox.Image = toReverse;
            EnableButtons("enable_all");
            Cursor.Current = Cursors.Default;
        }

        private void SaveImage(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save Image";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    // Get the file extension
                    string fileExtension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                    ImageFormat format = ImageFormat.Jpeg;

                    switch (fileExtension)
                    {
                        case ".jpg":
                        case ".jpeg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }

                    // Save the image
                    PictureBox.Image.Save(saveFileDialog.FileName, format);
                }
            }

            Text = $"image - {ImagePath} - saved";
        }


//**************** UTILITY FUNCTIONS ****************//
        private string File_dialog_search()//load function; returns image path
        {
            string path;
            using (var file_browser_dialog = new OpenFileDialog())
            {
                while (true)
                {
                    DialogResult result = file_browser_dialog.ShowDialog();
                    //if i cancel the operation
                    if (result == DialogResult.Cancel)
                        throw new Exception("operation canceled");

                    //if i choose an image && the choosen path is valid
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(file_browser_dialog.FileName))
                    {
                        path = file_browser_dialog.FileName;
                        if (path.EndsWith(".jpg") || path.EndsWith(".png") || path.EndsWith(".jpeg"))
                            return path;
                        else
                            MessageBox.Show("il file selezionato non � valido.", "file non valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// update the "colorValuesRGB" array with new values
        /// </summary>
        /// <param name="sender"></param>
        private void ChangeColorValues(object sender)
        {
            string name = ((Button)sender).Name;
            int color = name.Contains("red") ? 0 : name.Contains("green") ? 1 : 2;
            string function = name.Contains("add") ? "add" : "remove";

            switch (function)
            {
                case "add":
                    colorValuesRGB[color] = Math.Min(255, colorValuesRGB[color] + (int)input_colorVariation.Value);
                    break;
                case "remove":
                    colorValuesRGB[color] = Math.Max(-255, colorValuesRGB[color] - (int)input_colorVariation.Value);
                    break;
            }

            red_value_output.Text = colorValuesRGB[0].ToString();
            green_value_output.Text = colorValuesRGB[1].ToString();
            blue_value_output.Text = colorValuesRGB[2].ToString();
        }


    //the following are used to modify the image color, both using colorValuesRGB(SetColorValuesMatrix) or inverting the colors(InvertColorsMatrix)

        /// <summary>
        /// Used for those functions which need to modify the colors of the image. 
        /// This function uses SetColorValuesMatrix(colorValuesRGB) , ApplyInvertFilter and ApplySepiaFilter.
        /// </summary>
        /// <param name="MyBitmap">The bitmap image to be modified.</param>
        /// <param name="option">The option indicating the type of modification: "set_values" to set color values, "invert_colors" to invert colors, "sepia" to apply sepia filter</param>
        /// <returns>Returns the modified Bitmap object passed to it.</returns>
        private Bitmap ModifyColorsMatrix(Bitmap MyBitmap, string option)
        {
            switch (option) {
                case "set_values":
                    return SetColorValuesMatrix(MyBitmap);
                case "invert":
                    return ApplyInvertFilter(MyBitmap);
                case "sepia":
                    return ApplySepiaFilter(MyBitmap);
            }

            throw new ArgumentException("Invalid option or missing parameters");
        }

        /// <summary>
        /// modify the colors of the passed BitMap based on the values setted by the user with colorValuesRGB
        /// </summary>
        /// <param name="MyBitmap"></param>
        /// <returns>return the modified BitMap object passed to it</returns>
        private Bitmap SetColorValuesMatrix(Bitmap MyBitmap)
        {
            int pixel_width = MyBitmap.Width;
            int pixel_height = MyBitmap.Height;

            for (int x = 0; x < pixel_width; x++)
            {
                for (int y = 0; y < pixel_height; y++)
                {
                    Color pixel_color = MyBitmap.GetPixel(x, y);
                    Color new_pixel_color = ModifyColorPixel(pixel_color);
                    MyBitmap.SetPixel(x, y, new_pixel_color);
                }
            }
            return MyBitmap;

            Color ModifyColorPixel(Color pixel_color)
            {
                int red_value = Math.Clamp(pixel_color.R + colorValuesRGB[0], 0, 255);
                int green_value = Math.Clamp(pixel_color.G + colorValuesRGB[1], 0, 255);
                int blue_value = Math.Clamp(pixel_color.B + colorValuesRGB[2], 0, 255);

                Color new_pixel = Color.FromArgb(red_value, green_value, blue_value);

                return new_pixel;
            }
        }

        /// <summary>
        /// invert the colors of the passed BitMap
        /// </summary>
        /// <param name="MyBitmap"></param>
        /// <returns>return the modified BitMap object passed to it</returns>
        private Bitmap ApplyInvertFilter(Bitmap MyBitmap)
        {
            int pixel_width = MyBitmap.Width;
            int pixel_height = MyBitmap.Height;

            for (int x = 0; x < pixel_width; x++)
            {
                for (int y = 0; y < pixel_height; y++)
                {
                    Color pixel_color = MyBitmap.GetPixel(x, y);

                    //set new color
                    Color new_pixel_color = InvertColorPixel(pixel_color);
                    MyBitmap.SetPixel(x, y, new_pixel_color);
                }
            }
            return MyBitmap;

            //modify pixel
            Color InvertColorPixel(Color pixel_color)
            {
                // Invert the color values
                int red_value = 255 - pixel_color.R;
                int green_value = 255 - pixel_color.G;
                int blue_value = 255 - pixel_color.B;

                Color new_pixel = Color.FromArgb(red_value, green_value, blue_value);

                return new_pixel;
            }
        }

        /// <summary>
        /// apply the "sepia" filter to the passed image. 
        /// this should use a BitMap created from the shown image
        /// </summary>
        /// <param name="MyBitmap"></param>
        /// <returns>return the modified BitMap object passed to it</returns>
        private Bitmap ApplySepiaFilter(Bitmap MyBitmap)
        {
            int pixel_width = MyBitmap.Width;
            int pixel_height = MyBitmap.Height;

            for (int x = 0; x < pixel_width; x++)
            {
                for (int y = 0; y < pixel_height; y++)
                {
                    Color pixel_color = MyBitmap.GetPixel(x, y);
                    
                    //set new color
                    Color sepia_color = SepiaColorPixel(pixel_color);
                    MyBitmap.SetPixel(x, y, sepia_color);
                }
            }
            return MyBitmap;

            Color SepiaColorPixel(Color pixel_color) {
                // Calculate new color values
                int red_value = (int)(0.393 * pixel_color.R + 0.769 * pixel_color.G + 0.189 * pixel_color.B);
                int green_value = (int)(0.349 * pixel_color.R + 0.686 * pixel_color.G + 0.168 * pixel_color.B);
                int blue_value = (int)(0.272 * pixel_color.R + 0.534 * pixel_color.G + 0.131 * pixel_color.B);

                // Clamp the values to be within the valid range [0, 255]
                red_value = Math.Clamp(red_value, 0, 255);
                green_value = Math.Clamp(green_value, 0, 255);
                blue_value = Math.Clamp(blue_value, 0, 255);

                Color sepiaColor = Color.FromArgb(red_value, green_value, blue_value);
                return sepiaColor;
            }
        }


    //the following are used to modify the orientation of the image
        /// <summary>
        /// this function is used to modify the image orientation both horizontally and vertically.
        /// </summary>
        /// <param name="MyBitmap"></param>
        /// <param name="orientation"></param>
        /// <returns>return the modified BitMap object passed to it</returns>
        private Bitmap ModifyOrientationMatrix(Bitmap MyBitmap, string orientation)
        {
            int pixel_width = MyBitmap.Width;//get width
            int pixel_heigth = MyBitmap.Height;//get heigth
            Color current_pixel, opposite_pixel;

            if (orientation == "vertical")
            {
                for (int x = 0; x < pixel_width; x++)
                {
                    for (int y = 0; y < (pixel_heigth / 2) - 1; y++)
                    {
                        current_pixel = MyBitmap.GetPixel(x, y);
                        opposite_pixel = MyBitmap.GetPixel(x, pixel_heigth - 1 - y);

                        MyBitmap.SetPixel(x, y, opposite_pixel);
                        MyBitmap.SetPixel(x, pixel_heigth - 1 - y, current_pixel);
                    }
                }

                return MyBitmap;
            }

            //else horizontal
            for (int y = 0; y < pixel_heigth; y++)
            {
                for (int x = 0; x < (pixel_width / 2) - 1; x++)
                {
                    current_pixel = MyBitmap.GetPixel(x, y);
                    opposite_pixel = MyBitmap.GetPixel(pixel_width - 1 - x, y);

                    MyBitmap.SetPixel(x, y, opposite_pixel);
                    MyBitmap.SetPixel(pixel_width - 1 - x, y, current_pixel);
                }
            }

            return MyBitmap;

        }


//**************** OTHER METHODS ****************//
        /// <summary>
        /// transform the passed BitMap into a Image object
        /// </summary>
        /// <param name="modified_bitmap"></param>
        /// <returns>return an Image object based on the passed BitMap</returns>
        private Image assemble_image(Bitmap modified_bitmap)
        {
            Image converted_image = (Image)modified_bitmap;
            return converted_image;
        }

        private void GetChange(object sender, EventArgs e) {
            string todo = ((Button)sender).Name;
            version_counter = todo == "Undo" ? version_counter-1 : version_counter+1;

            (Image base_image_last, Image picturebox_image_last, int[] color_values) recod = Image_versions[version_counter];//last saved
            base_image = recod.base_image_last;
            PictureBox.Image = recod.picturebox_image_last;
            colorValuesRGB = new int[] { recod.color_values[0], recod.color_values[1], recod.color_values[2] };


            red_value_output.Text = colorValuesRGB[0].ToString();
            green_value_output.Text = colorValuesRGB[1].ToString();
            blue_value_output.Text = colorValuesRGB[2].ToString();

            EnableButtons("version_counter");
        }

        /// <summary>
        /// used to enable or disable certain buttons, based on needs. can be "disable_processing" or "enable_all"
        /// </summary>
        /// <param name="pixel_color"></param>
        /// <returns>a Color object which represents the new pixel</returns>
        private void EnableButtons(string option)
        {
            switch (option)
            {
                case "disable_processing":
                    add_red.Enabled = false;
                    remove_red.Enabled = false;
                    add_green.Enabled = false;
                    remove_green.Enabled = false;
                    add_blue.Enabled = false;
                    remove_blue.Enabled = false;

                    input_colorVariation.Enabled = false;
                    load_image.Enabled = false;
                    save_image.Enabled = false;

                    Reverse_orientation_Horizontal.Enabled = false;
                    Reverse_orientation_Vertical.Enabled = false;

                    Invert_filter.Enabled = false;
                    Sepia_filter.Enabled = false;

                    Undo.Enabled = false;
                    Redo.Enabled = false;
                    break;

                case "enable_all":
                    add_red.Enabled = true;
                    remove_red.Enabled = true;
                    add_green.Enabled = true;
                    remove_green.Enabled = true;
                    add_blue.Enabled = true;
                    remove_blue.Enabled = true;

                    input_colorVariation.Enabled = true;
                    load_image.Enabled = true;
                    save_image.Enabled = true;

                    Reverse_orientation_Horizontal.Enabled = true;
                    Reverse_orientation_Vertical.Enabled = true;

                    Invert_filter.Enabled = true;
                    Sepia_filter.Enabled = true;

                    Undo.Enabled = version_counter > 0 ? true : false;
                    Redo.Enabled = version_counter < Image_versions.Count-1 ? true : false;

                    break;

                case "version_counter":
                    Undo.Enabled = version_counter > 0 ? true : false;
                    Redo.Enabled = version_counter < Image_versions.Count - 1 ? true : false;
                    break;
            }
        }
    
    }
}