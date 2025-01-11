namespace _ModificaImmagine_29_11_24
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            Redo = new Button();
            Undo = new Button();
            groupBox3 = new GroupBox();
            Sepia_filter = new Button();
            Invert_filter = new Button();
            groupBox2 = new GroupBox();
            Reverse_orientation_Horizontal = new Button();
            Reverse_orientation_Vertical = new Button();
            groupBox1 = new GroupBox();
            blue_value_output = new Label();
            green_value_output = new Label();
            red_value_output = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            input_colorVariation = new NumericUpDown();
            remove_blue = new Button();
            add_blue = new Button();
            remove_green = new Button();
            add_green = new Button();
            remove_red = new Button();
            add_red = new Button();
            pictureBox1 = new PictureBox();
            save_image = new Button();
            load_image = new Button();
            PictureBox = new PictureBox();
            Rotate_left = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)input_colorVariation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(Redo);
            panel1.Controls.Add(Undo);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(save_image);
            panel1.Controls.Add(load_image);
            panel1.Location = new Point(11, 458);
            panel1.Name = "panel1";
            panel1.Size = new Size(1019, 149);
            panel1.TabIndex = 1;
            // 
            // Redo
            // 
            Redo.Enabled = false;
            Redo.Location = new Point(944, 87);
            Redo.Margin = new Padding(3, 4, 3, 4);
            Redo.Name = "Redo";
            Redo.Size = new Size(63, 60);
            Redo.TabIndex = 19;
            Redo.Tag = "";
            Redo.Text = "--> redo";
            Redo.UseVisualStyleBackColor = true;
            Redo.Click += GetChange;
            // 
            // Undo
            // 
            Undo.Enabled = false;
            Undo.Location = new Point(944, 15);
            Undo.Margin = new Padding(3, 4, 3, 4);
            Undo.Name = "Undo";
            Undo.Size = new Size(63, 60);
            Undo.TabIndex = 2;
            Undo.Tag = "";
            Undo.Text = "<-- undo";
            Undo.UseVisualStyleBackColor = true;
            Undo.Click += GetChange;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(Sepia_filter);
            groupBox3.Controls.Add(Invert_filter);
            groupBox3.Location = new Point(731, 4);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(200, 71);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "Filter";
            // 
            // Sepia_filter
            // 
            Sepia_filter.Enabled = false;
            Sepia_filter.Location = new Point(97, 29);
            Sepia_filter.Margin = new Padding(3, 4, 3, 4);
            Sepia_filter.Name = "Sepia_filter";
            Sepia_filter.Size = new Size(93, 31);
            Sepia_filter.TabIndex = 3;
            Sepia_filter.Tag = "sepia_filter";
            Sepia_filter.Text = "sepia filter";
            Sepia_filter.UseVisualStyleBackColor = true;
            Sepia_filter.Click += ModifyImage;
            // 
            // Invert_filter
            // 
            Invert_filter.Enabled = false;
            Invert_filter.Location = new Point(6, 29);
            Invert_filter.Margin = new Padding(3, 4, 3, 4);
            Invert_filter.Name = "Invert_filter";
            Invert_filter.Size = new Size(85, 31);
            Invert_filter.TabIndex = 2;
            Invert_filter.Tag = "invert_filter";
            Invert_filter.Text = "invert filter";
            Invert_filter.UseVisualStyleBackColor = true;
            Invert_filter.Click += ModifyImage;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(Rotate_left);
            groupBox2.Controls.Add(Reverse_orientation_Horizontal);
            groupBox2.Controls.Add(Reverse_orientation_Vertical);
            groupBox2.Location = new Point(525, 4);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(200, 112);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "modify orientation";
            // 
            // Reverse_orientation_Horizontal
            // 
            Reverse_orientation_Horizontal.Enabled = false;
            Reverse_orientation_Horizontal.Location = new Point(98, 29);
            Reverse_orientation_Horizontal.Margin = new Padding(3, 4, 3, 4);
            Reverse_orientation_Horizontal.Name = "Reverse_orientation_Horizontal";
            Reverse_orientation_Horizontal.Size = new Size(85, 31);
            Reverse_orientation_Horizontal.TabIndex = 1;
            Reverse_orientation_Horizontal.Tag = "reverse_horizontal";
            Reverse_orientation_Horizontal.Text = "Horizontal";
            Reverse_orientation_Horizontal.UseVisualStyleBackColor = true;
            Reverse_orientation_Horizontal.Click += ModifyImage;
            // 
            // Reverse_orientation_Vertical
            // 
            Reverse_orientation_Vertical.Enabled = false;
            Reverse_orientation_Vertical.Location = new Point(7, 29);
            Reverse_orientation_Vertical.Margin = new Padding(3, 4, 3, 4);
            Reverse_orientation_Vertical.Name = "Reverse_orientation_Vertical";
            Reverse_orientation_Vertical.Size = new Size(85, 31);
            Reverse_orientation_Vertical.TabIndex = 0;
            Reverse_orientation_Vertical.Tag = "reverse_vertical";
            Reverse_orientation_Vertical.Text = "Vertical";
            Reverse_orientation_Vertical.UseVisualStyleBackColor = true;
            Reverse_orientation_Vertical.Click += ModifyImage;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(blue_value_output);
            groupBox1.Controls.Add(green_value_output);
            groupBox1.Controls.Add(red_value_output);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(input_colorVariation);
            groupBox1.Controls.Add(remove_blue);
            groupBox1.Controls.Add(add_blue);
            groupBox1.Controls.Add(remove_green);
            groupBox1.Controls.Add(add_green);
            groupBox1.Controls.Add(remove_red);
            groupBox1.Controls.Add(add_red);
            groupBox1.Location = new Point(123, 4);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(396, 141);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "modify colors values";
            // 
            // blue_value_output
            // 
            blue_value_output.BackColor = SystemColors.ControlLight;
            blue_value_output.BorderStyle = BorderStyle.FixedSingle;
            blue_value_output.Location = new Point(174, 115);
            blue_value_output.Name = "blue_value_output";
            blue_value_output.Size = new Size(76, 21);
            blue_value_output.TabIndex = 15;
            blue_value_output.Text = "0";
            // 
            // green_value_output
            // 
            green_value_output.BackColor = SystemColors.ControlLight;
            green_value_output.BorderStyle = BorderStyle.FixedSingle;
            green_value_output.Location = new Point(89, 115);
            green_value_output.Name = "green_value_output";
            green_value_output.Size = new Size(76, 21);
            green_value_output.TabIndex = 14;
            green_value_output.Text = "0";
            // 
            // red_value_output
            // 
            red_value_output.BackColor = SystemColors.ControlLight;
            red_value_output.BorderStyle = BorderStyle.FixedSingle;
            red_value_output.Location = new Point(5, 115);
            red_value_output.Name = "red_value_output";
            red_value_output.Size = new Size(76, 21);
            red_value_output.TabIndex = 13;
            red_value_output.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(173, 24);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 12;
            label4.Text = "blue:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 24);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 11;
            label3.Text = "green:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 24);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 10;
            label2.Text = "red:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(269, 27);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 9;
            label1.Text = "color variation:";
            // 
            // input_colorVariation
            // 
            input_colorVariation.Enabled = false;
            input_colorVariation.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            input_colorVariation.Location = new Point(269, 52);
            input_colorVariation.Margin = new Padding(3, 4, 3, 4);
            input_colorVariation.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            input_colorVariation.Name = "input_colorVariation";
            input_colorVariation.Size = new Size(63, 27);
            input_colorVariation.TabIndex = 8;
            input_colorVariation.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // remove_blue
            // 
            remove_blue.Enabled = false;
            remove_blue.Location = new Point(173, 84);
            remove_blue.Name = "remove_blue";
            remove_blue.Size = new Size(78, 28);
            remove_blue.TabIndex = 6;
            remove_blue.Tag = "change_color";
            remove_blue.Text = "blue -";
            remove_blue.UseVisualStyleBackColor = true;
            remove_blue.Click += ModifyImage;
            // 
            // add_blue
            // 
            add_blue.Enabled = false;
            add_blue.Location = new Point(173, 52);
            add_blue.Name = "add_blue";
            add_blue.Size = new Size(78, 28);
            add_blue.TabIndex = 5;
            add_blue.Tag = "change_color";
            add_blue.Text = "blue +";
            add_blue.UseVisualStyleBackColor = true;
            add_blue.Click += ModifyImage;
            // 
            // remove_green
            // 
            remove_green.Enabled = false;
            remove_green.Location = new Point(88, 84);
            remove_green.Name = "remove_green";
            remove_green.Size = new Size(78, 28);
            remove_green.TabIndex = 4;
            remove_green.Tag = "change_color";
            remove_green.Text = "green -";
            remove_green.UseVisualStyleBackColor = true;
            remove_green.Click += ModifyImage;
            // 
            // add_green
            // 
            add_green.Enabled = false;
            add_green.Location = new Point(88, 52);
            add_green.Name = "add_green";
            add_green.Size = new Size(78, 28);
            add_green.TabIndex = 3;
            add_green.Tag = "change_color";
            add_green.Text = "green +";
            add_green.UseVisualStyleBackColor = true;
            add_green.Click += ModifyImage;
            // 
            // remove_red
            // 
            remove_red.Enabled = false;
            remove_red.Location = new Point(3, 84);
            remove_red.Name = "remove_red";
            remove_red.Size = new Size(78, 28);
            remove_red.TabIndex = 2;
            remove_red.Tag = "change_color";
            remove_red.Text = "red -";
            remove_red.UseVisualStyleBackColor = true;
            remove_red.Click += ModifyImage;
            // 
            // add_red
            // 
            add_red.Enabled = false;
            add_red.Location = new Point(3, 52);
            add_red.Name = "add_red";
            add_red.Size = new Size(78, 28);
            add_red.TabIndex = 1;
            add_red.Tag = "change_color";
            add_red.Text = "red +";
            add_red.UseVisualStyleBackColor = true;
            add_red.Click += ModifyImage;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, -327);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(776, 308);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // save_image
            // 
            save_image.Enabled = false;
            save_image.Location = new Point(15, 80);
            save_image.Name = "save_image";
            save_image.Size = new Size(87, 60);
            save_image.TabIndex = 7;
            save_image.Text = "Save Picture";
            save_image.UseVisualStyleBackColor = true;
            save_image.Click += SaveImage;
            // 
            // load_image
            // 
            load_image.Location = new Point(15, 15);
            load_image.Name = "load_image";
            load_image.Size = new Size(87, 60);
            load_image.TabIndex = 0;
            load_image.Text = "Load Picture";
            load_image.UseVisualStyleBackColor = true;
            load_image.Click += LoadImage;
            // 
            // PictureBox
            // 
            PictureBox.Location = new Point(11, 13);
            PictureBox.Margin = new Padding(3, 4, 3, 4);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(1019, 438);
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox.TabIndex = 2;
            PictureBox.TabStop = false;
            // 
            // Rotate_left
            // 
            Rotate_left.Location = new Point(7, 67);
            Rotate_left.Name = "Rotate_left";
            Rotate_left.Size = new Size(85, 29);
            Rotate_left.TabIndex = 2;
            Rotate_left.Text = "90° left";
            Rotate_left.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(98, 67);
            button1.Name = "button1";
            button1.Size = new Size(85, 29);
            button1.TabIndex = 3;
            button1.Text = "90° left";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1042, 619);
            Controls.Add(PictureBox);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Image Editor";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)input_colorVariation).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button save_image;
        private Button remove_blue;
        private Button add_blue;
        private Button remove_green;
        private Button add_green;
        private Button remove_red;
        private Button add_red;
        private Button load_image;
        private PictureBox pictureBox1;
        private PictureBox PictureBox;
        private NumericUpDown input_colorVariation;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label red_value_output;
        private Label blue_value_output;
        private Label green_value_output;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button Reverse_orientation_Horizontal;
        private Button Reverse_orientation_Vertical;
        private GroupBox groupBox3;
        private Button Invert_filter;
        private Button Sepia_filter;
        private Button Undo;
        private Button Redo;
        private Button button1;
        private Button Rotate_left;
    }
}