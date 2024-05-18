namespace SNTImageConverter
{
    partial class Color_Picker
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.btnColorPicker = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "color";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(27, 25);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(100, 20);
            this.txtColor.TabIndex = 1;
            // 
            // btnColorPicker
            // 
            this.btnColorPicker.Location = new System.Drawing.Point(27, 112);
            this.btnColorPicker.Name = "btnColorPicker";
            this.btnColorPicker.Size = new System.Drawing.Size(75, 23);
            this.btnColorPicker.TabIndex = 2;
            this.btnColorPicker.Text = "pick Color";
            this.btnColorPicker.UseVisualStyleBackColor = true;
            this.btnColorPicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnColorPicker_MouseDown);
            this.btnColorPicker.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnColorPicker_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Color from Screen";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(180, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 138);
            this.panel1.TabIndex = 4;
            // 
            // Color_Picker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 165);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnColorPicker);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label1);
            this.Name = "Color_Picker";
            this.Text = "Color_Picker";
            this.Load += new System.EventHandler(this.Color_Picker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Button btnColorPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}