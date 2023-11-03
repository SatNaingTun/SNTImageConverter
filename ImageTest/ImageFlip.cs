using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageTest
{
  public  class ImageFlip
    {
        public Image FilpVertical(Image img,int width,int height)
        {
            Bitmap input = new Bitmap(img);
            Bitmap output = new Bitmap(width, height);


            int ty = input.Height - 1;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                   
                    output.SetPixel(x, ty, input.GetPixel(x, y));
                }
                ty--;
            }
            return output;
        }

        public static Image FilpHorizontal(Image img, int width, int height)
        {
            Bitmap input = new Bitmap(img);
            Bitmap output = new Bitmap(width, height);


            int tx = input.Width - 1;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    output.SetPixel(tx, y, input.GetPixel(x, y));
                    tx--;
                }
                
            }
            return output;
        }

        public static Image FilpHorizontalVertical(Image img, int width, int height)
        {
            Bitmap input = new Bitmap(img);
            Bitmap output = new Bitmap(width, height);


            int tx = input.Width - 1;
            int ty = input.Height - 1;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    output.SetPixel(tx, ty, input.GetPixel(x, y));
                    tx--;
                }
                ty--;
            }
            return output;
        }
    }
}
