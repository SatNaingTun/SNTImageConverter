using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

namespace SNTImageConverter
{
    class ImagePrintDocument:PrintDocument
    {
        Image printImage;
        public ImagePrintDocument()
        {
            this.PrintPage += new PrintPageEventHandler(pd_PrintPage);
        }
        public ImagePrintDocument(Image image)
        {
            printImage = image;
            this.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            Margins margins = new Margins(0, 0, 0, 0);
            DefaultPageSettings.Margins = margins;
        }
        public void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (printImage != null)
                e.Graphics.DrawImage(printImage, new Rectangle(0, 0, printImage.Width, printImage.Height));

        }
    }
}
