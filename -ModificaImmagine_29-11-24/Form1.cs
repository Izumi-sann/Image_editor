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
 * one other color modifier
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
        static int[] colorValuesRGB = new int[] { 0, 0, 0 };//modificatori dei valori red, green, blue
        static string ImagePath = "";
        static Image base_image; //una copia dell'immagine senza modifiche(con i ribaltamenti) per risolvere il problema di modifica dei colori

        //un contatore per verificare se l'immagine è stata routata verticalmente o orizzontalmente;
        //è necessario quando si va a modificare i colori dell'immagine, siccome tale funzione usa "base_image" per settare i nuovi colori, e pertanto è prima da ruotare se necessario
        static bool[] orientation_counter = new bool[] { false, false };//vertical, horizontal

        public Form1() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e) { }


        //******** main functions ********//
        private void LoadImage(object sender, EventArgs e) //central function to load the image onto the app
        {
            try { ImagePath = File_dialog_search(); }
            catch { return; }

            Text = $"image - {ImagePath} - saved";

            PictureBox.Load(ImagePath);
            base_image = new Bitmap(ImagePath);

            EnableButtons("enable_all");
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
            void GetImageReady()
            {
                if (orientation_counter[0])
                {
                    ModifyImageOrientation("vertical", ref base_image);
                    orientation_counter[0] = false;
                }
                if (orientation_counter[1])
                {
                    ModifyImageOrientation("horizontal", ref base_image);
                    orientation_counter[1] = false;
                }
            }

            string tag = ((Button)sender).Tag.ToString();
            
            switch (tag) {
                case "change_color":
                    GetImageReady();//change orientation of "base_image" since we use that one to change colors, and we need to set the orientation as the one displayed
                    ModifyImageColors(sender, "set_values");//the colors are changed here
                    break;
                case "invert_colors":
                    GetImageReady();//change orientation of "base_image" since we use that one to change colors, and we need to set the orientation as the one displayed
                    ModifyImageColors(sender, "invert");//the colors are changed here
                    break;
                case "reverse_vertical":
                    Image verticalFlippedImage = PictureBox.Image;//we can't directly pass PictureBox.Image with ref, so we use a temporary variable
                    ModifyImageOrientation("vertical", ref verticalFlippedImage);
                    PictureBox.Image = verticalFlippedImage;
                    orientation_counter[0] = !orientation_counter[0];
                    break;
                case "reverse_horizontal":
                    Image horizontalFlippedImage = PictureBox.Image;//we can't directly pass PictureBox.Image with ref, so we use a temporary variable
                    ModifyImageOrientation("horizontal", ref horizontalFlippedImage);
                    PictureBox.Image = horizontalFlippedImage;
                    orientation_counter[1] = !orientation_counter[1];
                    break;
            }

            if (!Text.Contains("not saved"))
                Text = $"image - {ImagePath} - not saved";
            
        }

        /// <summary>
        /// used to manage every function regarding modifing the image's colors, invert colors or set colors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="option"> tells which function to use, can be "set_values" or "invert_colors"</param>
        private void ModifyImageColors(object sender, string option)//used in whichever case i change the image's colors
        {
            EnableButtons("disable_processing");
            Cursor.Current = Cursors.WaitCursor;

            ChangeColorValues(sender);
            Bitmap MyBitmap = option == "set_values" ? new Bitmap(base_image) : new Bitmap(PictureBox.Image);//crea matrice bitmap
            Bitmap pixel_matrix = ModifyColorsMatrix(MyBitmap, option);//modifica colori pixel matrice
            Image modified_image = assemble_image(pixel_matrix);//riassebla la matrice in un oggetto Image
            PictureBox.Image = modified_image;

            EnableButtons("enable_all");
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// used to manage every function regarding modifing the image's colors, invert colors or set colors
        /// </summary>
        /// <param name="orientation">the orientation we want, can be "vertical" or "horizontal"</param>
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


        //******** other utility functions ********//
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
                            MessageBox.Show("il file selezionato non è valido.", "file non valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// used for those function which need to modify the colors of the image, in this case uses SetColorsValuesMatrix(colorValuesRGB) and InvertColorsMatrix 
        /// </summary>
        /// <param name="MyBitmap"></param>
        /// <param name="option"></param>
        /// <returns>return the modified BitMap object passed to it</returns>
        private Bitmap ModifyColorsMatrix(Bitmap MyBitmap, string option)
        {
            if (option == "set_values")
                return SetColorValuesMatrix(MyBitmap);
            else if (option == "invert_colors")
                return InvertColorsMatrix(MyBitmap);

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
        }

        /// <summary>
        /// invert the colors of the passed BitMap
        /// </summary>
        /// <param name="MyBitmap"></param>
        /// <returns>return the modified BitMap object passed to it</returns>
        private Bitmap InvertColorsMatrix(Bitmap MyBitmap)
        {
            int pixel_width = MyBitmap.Width;
            int pixel_height = MyBitmap.Height;

            for (int x = 0; x < pixel_width; x++)
            {
                for (int y = 0; y < pixel_height; y++)
                {
                    Color pixel_color = MyBitmap.GetPixel(x, y);
                    Color new_pixel_color = InvertColorPixel(pixel_color);
                    MyBitmap.SetPixel(x, y, new_pixel_color);
                }
            }
            return MyBitmap;
        }

        /// <summary>
        /// modify the passed pixel(Color) with colorValuesRGB's values
        /// </summary>
        /// <param name="pixel_color"></param>
        /// <returns>a Color object which represents the new pixel</returns>
        private Color ModifyColorPixel(Color pixel_color)
        {
            int red_value = Math.Clamp(pixel_color.R + colorValuesRGB[0], 0, 255);
            int green_value = Math.Clamp(pixel_color.G + colorValuesRGB[1], 0, 255);
            int blue_value = Math.Clamp(pixel_color.B + colorValuesRGB[2], 0, 255);

            Color new_pixel = Color.FromArgb(red_value, green_value, blue_value);

            return new_pixel;
        }

        /// <summary>
        /// invert the passed pixel(Color)
        /// </summary>
        /// <param name="pixel_color"></param>
        /// <returns>a Color object which represents the new pixel</returns>
        private Color InvertColorPixel(Color pixel_color)
        {
            // Invert the color values
            int red_value = 255 - pixel_color.R;
            int green_value = 255 - pixel_color.G;
            int blue_value = 255 - pixel_color.B;

            Color new_pixel = Color.FromArgb(red_value, green_value, blue_value);

            return new_pixel;
        }

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

                    Invert_colors.Enabled = false;
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

                    Invert_colors.Enabled = true;
                    break;

            }
        }
    
    }
}