using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SNTImageConverter.Function
{
    class ScreenCapture
    {
        public Image captureScreen()
        {
            Bitmap captureBitmap = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            return captureBitmap;
        }
        public Image getActiveWindow()
        {
            var frm = Form.ActiveForm;
            var bmp = new Bitmap(frm.Width, frm.Height);
            
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            
            return bmp;
        }
    }
}
