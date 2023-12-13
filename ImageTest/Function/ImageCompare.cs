using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SNTImageConverter.Function
{
    class ImageCompare
    {
        public bool isTheSame(Image image,Image secondImage)
        {
            Bitmap firstBmp = new Bitmap(image, new Size(16, 16));
            Bitmap secondBmp = new Bitmap(secondImage, new Size(16, 16));
            for (int x = 0; x < image.Width; x++)
            {
                for (int y  = 0; y < image.Height; y++)
                {
                  bool isEqual=  firstBmp.GetPixel(x, y).Equals(secondBmp.GetPixel(x, y));
                  if (isEqual==false)
                  {
                      return false;
                  }
                }
                if (x==image.Width)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
