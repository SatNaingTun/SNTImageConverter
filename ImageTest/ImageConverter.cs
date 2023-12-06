using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SNTImageConverter
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
        public static Image toBinary(this Image img,int threshold)
        {
            Bitmap output = new Bitmap(img);
            Rectangle ret = new Rectangle(0, 0, output.Width, output.Height);
            BitmapData data = output.LockBits(ret, System.Drawing.Imaging.ImageLockMode.ReadWrite, output.PixelFormat);
            int bpp = Bitmap.GetPixelFormatSize(output.PixelFormat) / 8;
            byte[] temp = new byte[data.Stride * data.Height];
            Marshal.Copy(data.Scan0, temp, 0, temp.Length);

            for (int k = 0; k < temp.Length; k+=bpp)
            {
                int averageColor = (temp[k] + temp[k + 1] + temp[k + 3]) / 3;
                if (averageColor >= threshold)
                {
                    temp[k] = 255;     //Blue
                    temp[k + 1] = 255; //Green
                    temp[k + 2] = 255; //Red
                }
                else
                {
                    temp[k] = 0;     //Blue
                    temp[k + 1] = 0; //Green
                    temp[k + 2] = 0; //Red
                }

            }
            Marshal.Copy(temp, 0, data.Scan0, temp.Length);
            output.UnlockBits(data);
            return output;

        }


        public static Image toGrayScale(this Image img, string method)
        {
            Bitmap output = new Bitmap(img);
            Rectangle ret = new Rectangle(0, 0, output.Width, output.Height);
            BitmapData data = output.LockBits(ret, System.Drawing.Imaging.ImageLockMode.ReadWrite, output.PixelFormat);
            int bpp = Bitmap.GetPixelFormatSize(output.PixelFormat) / 8;
            byte[] temp = new byte[data.Stride * data.Height];
            Marshal.Copy(data.Scan0, temp, 0, temp.Length);

            for (int k = 0; k < temp.Length; k += bpp)
            {
                int averageColor = (temp[k] + temp[k + 1] + temp[k + 3]) / 3;
                double gray = 0;
                switch (method)
                {
                    case "Gray Average method":
                        int min = Math.Min(Math.Min(temp[k], temp[k + 1]), temp[k + 2]);
                        int max = Math.Max(Math.Max(temp[k], temp[k + 1]), temp[k + 2]);
                        gray = (min + max) / 2;
                        break;
                    case "Gray Luminosity Method":
                        gray = (0.114 * temp[k]) + (0.587 * temp[k+1]) + (0.299 * temp[k+2]);
                        break;
                    case "Gray Single Channel Method":
                        gray = temp[k+1];
                        break;
                }
                temp[k] = (byte)gray;
                temp[k + 1] = (byte)gray;
                temp[k + 2] = (byte)gray;

            }
            Marshal.Copy(temp, 0, data.Scan0, temp.Length);
            output.UnlockBits(data);
            return output;

        }
        public static Image toNegative(this Image img)
        {
            Bitmap output = new Bitmap(img);
            Rectangle ret = new Rectangle(0, 0, output.Width, output.Height);
            BitmapData data = output.LockBits(ret, System.Drawing.Imaging.ImageLockMode.ReadWrite, output.PixelFormat);
            int bpp = Bitmap.GetPixelFormatSize(output.PixelFormat) / 8;
            byte[] temp = new byte[data.Stride * data.Height];
            Marshal.Copy(data.Scan0, temp, 0, temp.Length);

            for (int k = 0; k < temp.Length; k += bpp)
            {
               
               
                temp[k] = (byte)(255-temp[k]);
                temp[k + 1] = (byte)(255 - temp[k+1]);
                temp[k + 2] = (byte)(255 - temp[k]+2);

            }
            Marshal.Copy(temp, 0, data.Scan0, temp.Length);
            output.UnlockBits(data);
            return output;

        }
        public static Image addBorder(this Image img,int borderSize,Color borderColor)
        {
            Bitmap output = new Bitmap(img.Width,img.Height);
            //using (Graphics gfx = Graphics.FromImage(output))
            //{
            //    using (Brush brush = new SolidBrush(borderColor))
            //    {
            //        gfx.FillRectangle(brush, 0, 0, img.Width-3, img.Height-2);
            //    }
            //    gfx.DrawImage(img, new Rectangle(borderSize, borderSize, img.Width, img.Height));
            //}

            //return output;
            using (Graphics gfx = Graphics.FromImage(output))
            {
                using (Pen pen=new Pen(borderColor,borderSize))
                {
                    gfx.DrawRectangle(pen,new Rectangle(0,0,img.Width,img.Height));
                }
                gfx.DrawImage(img, new Rectangle(borderSize, borderSize, img.Width-borderSize, img.Height-borderSize));
            }

            return output;

        }

        public static Image toA4Array(this Image img)
        {
            Image smallImge = img.toChangeSize(4*96, 6*96);
            smallImge = smallImge.addBorder(5, Color.Blue);
            Bitmap a4Bitmap = new Bitmap(2480, 3508);
            //Array.Copy(smallImge, a4Bitmap, smallImge.Width);
            using (Graphics gfx = Graphics.FromImage(a4Bitmap))
            {
                for (int w = 0; w+smallImge.Width < a4Bitmap.Width; w += smallImge.Width + 5)
                    for (int h = 0; h+smallImge.Height < a4Bitmap.Height; h += smallImge.Height + 5)
                gfx.DrawImage(smallImge, new Rectangle(w, h, smallImge.Width, smallImge.Height));

              
                    //gfx.DrawImage(smallImge, new Rectangle(0,h, smallImge.Width, smallImge.Height));
            }
            return a4Bitmap;
        }
    }
}
