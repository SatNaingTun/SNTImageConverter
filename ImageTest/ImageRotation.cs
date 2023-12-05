using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SNTImageConverter
{
   public static class ImageRotation
    {
       public static Image RotateLeft90(this Image image)
       {
           
           Bitmap input = new Bitmap(image);
           Bitmap output = new Bitmap(input.Height, input.Width);
           for (int y = 0; y < input.Height; y++)
           {
               int ty = input.Width - 1;
               for (int x = 0; x < input.Width; x++)
               {
                   output.SetPixel(y, ty, input.GetPixel(x, y));
                   ty--;
               }
               
           }
           return output;
       }

       public static Image RotateRight90(this Image image)
       {
           Bitmap input = new Bitmap(image);
           Bitmap output = new Bitmap(input.Height, input.Width);
           for (int x = 0; x < input.Width; x++)
           {
               int tx = input.Height-1;
               for (int y = 0; y < input.Height; y++)  
               {
                   output.SetPixel(tx, x, input.GetPixel(x, y));
                   tx--;
               }

           }
           return output;
       }
    }
}
