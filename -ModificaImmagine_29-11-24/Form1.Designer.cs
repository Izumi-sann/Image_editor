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
            groupBox3 = new GroupBox();
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
            Sepia_filter = new Button();
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
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(save_image);
            panel1.Controls.Add(load_image);
            panel1.Location = new Point(10, 256);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(679, 112);
            panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(Sepia_filter);
            groupBox3.Controls.Add(Invert_filter);
            groupBox3.Location = new Point(429, 60);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(175, 49);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "Change colors";
            // 
            // Invert_filter
            // 
            Invert_filter.Enabled = false;
            Invert_filter.Location = new Point(6, 20);
            Invert_filter.Name = "Invert_filter";
            Invert_filter.Size = new Size(74, 23);
            Invert_filter.TabIndex = 2;
            Invert_filter.Tag = "invert_filter";
            Invert_filter.Text = "invert filter";
            Invert_filter.UseVisualStyleBackColor = true;
            Invert_filter.Click += ModifyImage;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Reverse_orientation_Horizontal);
            groupBox2.Controls.Add(Reverse_orientation_Vertical);
            groupBox2.Location = new Point(429, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(175, 53);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "modify orientation";
            // 
            // Reverse_orientation_Horizontal
            // 
            Reverse_orientation_Horizontal.Enabled = false;
            Reverse_orientation_Horizontal.Location = new Point(86, 22);
            Reverse_orientation_Horizontal.Name = "Reverse_orientation_Horizontal";
            Reverse_orientation_Horizontal.Size = new Size(74, 23);
            Reverse_orientation_Horizontal.TabIndex = 1;
            Reverse_orientation_Horizontal.Tag = "reverse_horizontal";
            Reverse_orientation_Horizontal.Text = "Horizontal";
            Reverse_orientation_Horizontal.UseVisualStyleBackColor = true;
            Reverse_orientation_Horizontal.Click += ModifyImage;
            // 
            // Reverse_orientation_Vertical
            // 
            Reverse_orientation_Vertical.Enabled = false;
            Reverse_orientation_Vertical.Location = new Point(6, 22);
            Reverse_orientation_Vertical.Name = "Reverse_orientation_Vertical";
            Reverse_orientation_Vertical.Size = new Size(74, 23);
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
            groupBox1.Location = new Point(108, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(315, 106);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "modify colors values";
            // 
            // blue_value_output
            // 
            blue_value_output.BackColor = SystemColors.ControlLight;
            blue_value_output.BorderStyle = BorderStyle.FixedSingle;
            blue_value_output.Location = new Point(152, 86);
            blue_value_output.Name = "blue_value_output";
            blue_value_output.Size = new Size(67, 16);
            blue_value_output.TabIndex = 15;
            blue_value_output.Text = "0";
            // 
            // green_value_output
            // 
            green_value_output.BackColor = SystemColors.ControlLight;
            green_value_output.BorderStyle = BorderStyle.FixedSingle;
            green_value_output.Location = new Point(78, 86);
            green_value_output.Name = "green_value_output";
            green_value_output.Size = new Size(67, 16);
            green_value_output.TabIndex = 14;
            green_value_output.Text = "0";
            // 
            // red_value_output
            // 
            red_value_output.BackColor = SystemColors.ControlLight;
            red_value_output.BorderStyle = BorderStyle.FixedSingle;
            red_value_output.Location = new Point(4, 86);
            red_value_output.Name = "red_value_output";
            red_value_output.Size = new Size(67, 16);
            red_value_output.TabIndex = 13;
            red_value_output.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(151, 18);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 12;
            label4.Text = "blue:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 18);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 11;
            label3.Text = "green:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 18);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 10;
            label2.Text = "red:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(225, 18);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 9;
            label1.Text = "color variation:";
            // 
            // input_colorVariation
            // 
            input_colorVariation.Enabled = false;
            input_colorVariation.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            input_colorVariation.Location = new Point(225, 37);
            input_colorVariation.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            input_colorVariation.Name = "input_colorVariation";
            input_colorVariation.Size = new Size(55, 23);
            input_colorVariation.TabIndex = 8;
            input_colorVariation.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // remove_blue
            // 
            remove_blue.Enabled = false;
            remove_blue.Location = new Point(151, 63);
            remove_blue.Margin = new Padding(3, 2, 3, 2);
            remove_blue.Name = "remove_blue";
            remove_blue.Size = new Size(68, 21);
            remove_blue.TabIndex = 6;
            remove_blue.Tag = "change_color";
            remove_blue.Text = "blue -";
            remove_blue.UseVisualStyleBackColor = true;
            remove_blue.Click += ModifyImage;
            // 
            // add_blue
            // 
            add_blue.Enabled = false;
            add_blue.Location = new Point(151, 39);
            add_blue.Margin = new Padding(3, 2, 3, 2);
            add_blue.Name = "add_blue";
            add_blue.Size = new Size(68, 21);
            add_blue.TabIndex = 5;
            add_blue.Tag = "change_color";
            add_blue.Text = "blue +";
            add_blue.UseVisualStyleBackColor = true;
            add_blue.Click += ModifyImage;
            // 
            // remove_green
            // 
            remove_green.Enabled = false;
            remove_green.Location = new Point(77, 63);
            remove_green.Margin = new Padding(3, 2, 3, 2);
            remove_green.Name = "remove_green";
            remove_green.Size = new Size(68, 21);
            remove_green.TabIndex = 4;
            remove_green.Tag = "change_color";
            remove_green.Text = "green -";
            remove_green.UseVisualStyleBackColor = true;
            remove_green.Click += ModifyImage;
            // 
            // add_green
            // 
            add_green.Enabled = false;
            add_green.Location = new Point(77, 39);
            add_green.Margin = new Padding(3, 2, 3, 2);
            add_green.Name = "add_green";
            add_green.Size = new Size(68, 21);
            add_green.TabIndex = 3;
            add_green.Tag = "change_color";
            add_green.Text = "green +";
            add_green.UseVisualStyleBackColor = true;
            add_green.Click += ModifyImage;
            // 
            // remove_red
            // 
            remove_red.Enabled = false;
            remove_red.Location = new Point(3, 63);
            remove_red.Margin = new Padding(3, 2, 3, 2);
            remove_red.Name = "remove_red";
            remove_red.Size = new Size(68, 21);
            remove_red.TabIndex = 2;
            remove_red.Tag = "change_color";
            remove_red.Text = "red -";
            remove_red.UseVisualStyleBackColor = true;
            remove_red.Click += ModifyImage;
            // 
            // add_red
            // 
            add_red.Enabled = false;
            add_red.Location = new Point(3, 39);
            add_red.Margin = new Padding(3, 2, 3, 2);
            add_red.Name = "add_red";
            add_red.Size = new Size(68, 21);
            add_red.TabIndex = 1;
            add_red.Tag = "change_color";
            add_red.Text = "red +";
            add_red.UseVisualStyleBackColor = true;
            add_red.Click += ModifyImage;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, -245);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(679, 231);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // save_image
            // 
            save_image.Enabled = false;
            save_image.Location = new Point(13, 60);
            save_image.Margin = new Padding(3, 2, 3, 2);
            save_image.Name = "save_image";
            save_image.Size = new Size(76, 45);
            save_image.TabIndex = 7;
            save_image.Text = "Save Picture";
            save_image.UseVisualStyleBackColor = true;
            save_image.Click += SaveImage;
            // 
            // load_image
            // 
            load_image.Location = new Point(13, 11);
            load_image.Margin = new Padding(3, 2, 3, 2);
            load_image.Name = "load_image";
            load_image.Size = new Size(76, 45);
            load_image.TabIndex = 0;
            load_image.Text = "Load Picture";
            load_image.UseVisualStyleBackColor = true;
            load_image.Click += LoadImage;
            // 
            // PictureBox
            // 
            PictureBox.Location = new Point(10, 12);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(679, 230);
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox.TabIndex = 2;
            PictureBox.TabStop = false;
            // 
            // Sepia_filter
            // 
            Sepia_filter.Enabled = false;
            Sepia_filter.Location = new Point(86, 20);
            Sepia_filter.Name = "Sepia_filter";
            Sepia_filter.Size = new Size(81, 23);
            Sepia_filter.TabIndex = 3;
            Sepia_filter.Tag = "sepia_filter";
            Sepia_filter.Text = "sepia filter";
            Sepia_filter.UseVisualStyleBackColor = true;
            Sepia_filter.Click += ModifyImage;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(700, 378);
            Controls.Add(PictureBox);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
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
    }
}