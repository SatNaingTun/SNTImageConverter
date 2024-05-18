using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SNTImageConverter
{
    public partial class Color_Picker : Form
    {
        bool buttonPressed = false;
        public Color_Picker()
        {
            InitializeComponent();
        }

        Color GetColorAt(Point location)
        {
            using (Bitmap pixelContainer=new Bitmap(1,1))
            {
                using (Graphics graphics=Graphics.FromImage(pixelContainer))
                {
                    graphics.CopyFromScreen(location, Point.Empty, pixelContainer.Size);
                }
                return pixelContainer.GetPixel(0, 0);
            }
        }

        private void btnColorPicker_MouseDown(object sender, MouseEventArgs e)
        {
            buttonPressed = true;
            Cursor = Cursors.Cross;

            //BackgroundThread();
        }

        private void btnColorPicker_MouseUp(object sender, MouseEventArgs e)
        {
            buttonPressed = false;
            Cursor = Cursors.Default;
        }

        private void Color_Picker_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread thread = new Thread(BackgroundThread) { };
            thread.Start();
            //BackgroundThread();
        }
        void BackgroundThread()
        {
            while (true)
            {
                if (buttonPressed)
                {
                    Point cursorPosition = Cursor.Position;
                    Color selectedColor = GetColorAt(cursorPosition);
                    panel1.BackColor = selectedColor;
                    string hexColor = ColorTranslator.ToHtml(selectedColor);
                    txtColor.Text = hexColor;
                }
            }
        }
    }
}
