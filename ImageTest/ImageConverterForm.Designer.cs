namespace SNTImageConverter
{
    partial class ImageConverterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageConverterForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnRRotate = new System.Windows.Forms.Button();
            this.buttLRotate = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.NumericUpDown();
            this.txtWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnResize = new System.Windows.Forms.Button();
            this.btnAddHorizontal = new System.Windows.Forms.Button();
            this.btnAddVertical = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOriginalResolution = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.picResize = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblResizeResolution = new System.Windows.Forms.Label();
            this.screenshot = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResize)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.screenshot);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnRRotate);
            this.panel1.Controls.Add(this.buttLRotate);
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnResize);
            this.panel1.Controls.Add(this.btnAddHorizontal);
            this.panel1.Controls.Add(this.btnAddVertical);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 49);
            this.panel1.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(189, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1019, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "ToBinary",
            "Gray Average method",
            "Gray Luminosity Method",
            "Gray Single Channel Method",
            "Negative",
            "to 1.5x2 Array in A4 page",
            "to 3x2 Array in A4 page",
            "to 3x4 Array in A4 page",
            "to 4x3 Array in A4 page",
            "to 4x6 Array in A4 page"});
            this.comboBox1.Location = new System.Drawing.Point(728, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // btnRRotate
            // 
            this.btnRRotate.Image = global::SNTImageConverter.Properties.Resources.ic_rotate_right;
            this.btnRRotate.Location = new System.Drawing.Point(678, 12);
            this.btnRRotate.Name = "btnRRotate";
            this.btnRRotate.Size = new System.Drawing.Size(43, 31);
            this.btnRRotate.TabIndex = 3;
            this.btnRRotate.UseVisualStyleBackColor = true;
            this.btnRRotate.Click += new System.EventHandler(this.btnRRotate_Click);
            // 
            // buttLRotate
            // 
            this.buttLRotate.Image = global::SNTImageConverter.Properties.Resources.ic_rotate_left;
            this.buttLRotate.Location = new System.Drawing.Point(624, 12);
            this.buttLRotate.Name = "buttLRotate";
            this.buttLRotate.Size = new System.Drawing.Size(48, 31);
            this.buttLRotate.TabIndex = 3;
            this.buttLRotate.UseVisualStyleBackColor = true;
            this.buttLRotate.Click += new System.EventHandler(this.buttLRotate_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(564, 16);
            this.txtHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(54, 20);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(462, 15);
            this.txtWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(54, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "height:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(417, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "width:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(938, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(858, 14);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(75, 23);
            this.btnResize.TabIndex = 0;
            this.btnResize.Text = "Convert";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnAddHorizontal
            // 
            this.btnAddHorizontal.Location = new System.Drawing.Point(94, 13);
            this.btnAddHorizontal.Name = "btnAddHorizontal";
            this.btnAddHorizontal.Size = new System.Drawing.Size(89, 23);
            this.btnAddHorizontal.TabIndex = 0;
            this.btnAddHorizontal.Text = "Add Horizontal";
            this.btnAddHorizontal.UseVisualStyleBackColor = true;
            this.btnAddHorizontal.Click += new System.EventHandler(this.btnAddHorizontal_Click);
            // 
            // btnAddVertical
            // 
            this.btnAddVertical.Location = new System.Drawing.Point(13, 13);
            this.btnAddVertical.Name = "btnAddVertical";
            this.btnAddVertical.Size = new System.Drawing.Size(75, 23);
            this.btnAddVertical.TabIndex = 0;
            this.btnAddVertical.Text = "Add Vertical";
            this.btnAddVertical.UseVisualStyleBackColor = true;
            this.btnAddVertical.Click += new System.EventHandler(this.btnAddVertical_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1112, 252);
            this.splitContainer1.SplitterDistance = 626;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.picOriginal);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(626, 226);
            this.panel4.TabIndex = 2;
            // 
            // picOriginal
            // 
            this.picOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOriginal.Location = new System.Drawing.Point(0, 0);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(626, 226);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblOriginalResolution);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 226);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 26);
            this.panel2.TabIndex = 1;
            // 
            // lblOriginalResolution
            // 
            this.lblOriginalResolution.AutoSize = true;
            this.lblOriginalResolution.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblOriginalResolution.Location = new System.Drawing.Point(134, 4);
            this.lblOriginalResolution.Name = "lblOriginalResolution";
            this.lblOriginalResolution.Size = new System.Drawing.Size(28, 13);
            this.lblOriginalResolution.TabIndex = 0;
            this.lblOriginalResolution.Text = "pixel";
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Controls.Add(this.picResize);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(482, 226);
            this.panel5.TabIndex = 2;
            // 
            // picResize
            // 
            this.picResize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picResize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picResize.Location = new System.Drawing.Point(0, 0);
            this.picResize.Name = "picResize";
            this.picResize.Size = new System.Drawing.Size(482, 226);
            this.picResize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picResize.TabIndex = 0;
            this.picResize.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblResizeResolution);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 226);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(482, 26);
            this.panel3.TabIndex = 1;
            // 
            // lblResizeResolution
            // 
            this.lblResizeResolution.AutoSize = true;
            this.lblResizeResolution.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblResizeResolution.Location = new System.Drawing.Point(185, 4);
            this.lblResizeResolution.Name = "lblResizeResolution";
            this.lblResizeResolution.Size = new System.Drawing.Size(28, 13);
            this.lblResizeResolution.TabIndex = 0;
            this.lblResizeResolution.Text = "pixel";
            // 
            // screenshot
            // 
            this.screenshot.Location = new System.Drawing.Point(309, 14);
            this.screenshot.Name = "screenshot";
            this.screenshot.Size = new System.Drawing.Size(75, 23);
            this.screenshot.TabIndex = 7;
            this.screenshot.Text = "ScreenShot";
            this.screenshot.UseVisualStyleBackColor = true;
            this.screenshot.Click += new System.EventHandler(this.screenShot_Click);
            // 
            // ImageConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 301);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageConverterForm";
            this.Text = "SNT Image Converter";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picResize)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown txtHeight;
        private System.Windows.Forms.NumericUpDown txtWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.Button btnAddVertical;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox picResize;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOriginalResolution;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblResizeResolution;
        private System.Windows.Forms.Button btnRRotate;
        private System.Windows.Forms.Button buttLRotate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAddHorizontal;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button screenshot;
    }
}

