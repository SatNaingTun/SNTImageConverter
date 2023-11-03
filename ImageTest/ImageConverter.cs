using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ImageTest
{
   public static class ImageConverter
    {
        public static byte[] toByteArray(this Image image)
        {
            MemoryStream imageStream = new MemoryStream();
            image.Save(imageStream, image.RawFormat);
            return imageStream.ToArray();
        }

        public static Image toImage(this byte[] byteArray)
        {
            MemoryStream imageStream = new MemoryStream(byteArray);
            Image image = Image.FromStream(imageStream);
            return image;
        }
        public static Image toChangeSize(this Image image, int width, int height)
        {
            Bitmap input = new Bitmap(image);
            Bitmap output = new Bitmap(width, height);

            double tx = input.Width / (double)width;
            double ty = input.Height / (double)height;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    int px = (int)Math.Floor(x * tx);
                    int py = (int)Math.Floor(y * ty);
                    output.SetPixel(x, y, input.GetPixel(px, py));
                }
            return output;
        }
        //public static Image Contrast(this Image img, double contrast)
        //{
        //    Bitmap output = new Bitmap(img);
        //    Rectangle rect = new Rectangle(0, 0, output.Width, output.Height);
        //    BitmapData data = output.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, output.PixelFormat);
        //    int bpp = Bitmap.GetPixelFormatSize(output.PixelFormat) / 8;
        //    unsafe
        //    {
        //        byte* ptr = (byte*)data.Scan0.ToPointer();

        //    }
        //    return output;

        //}
    }
}
