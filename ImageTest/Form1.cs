using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ImageTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Insert a image";
            ofd.Filter = "JPEG Images|*.jpg|PNG Images |*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picOriginal.Image = Image.FromFile(ofd.FileName);
                lblOriginalResolution.Text = String.Format("{0}*{1} pixels", picOriginal.Image.Width, picOriginal.Image.Height);
            }

        }
        
        private Image CompressImageQuality(Image img, int qty)
        {
            var jpgEncoder = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
               EncoderParameters encoderParms=new EncoderParameters(1);
            encoderParms.Param[0]=new EncoderParameter(System.Drawing.Imaging.Encoder.Quality,qty);
            var ms=new MemoryStream();
            img.Save(ms,jpgEncoder,encoderParms);
            byte[] imgByte=ms.ToArray();
            ms=new MemoryStream(imgByte);
            Image outputImg=Image.FromStream(ms,true);
            return outputImg;
           
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(txtWidth.Value);
            int height = Convert.ToInt32(txtHeight.Value);
            Image img = picOriginal.Image.toChangeSize( width, height);
            picResize.Image = img;
            lblResizeResolution.Text = String.Format("{0}*{1} pixels", width, height);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save an image";
            sfd.Filter = @"
                        Joint Photographic Expert Group(*.jpeg)|*.jpeg|
                        Portable Network Graphics(*.png)|*.png|
                         Bitmap(*.bmp)|*.bmp|
                        Tagged Image File Format(*.tiff)|*.tiff|
                         Graphics Interchange Format(*.gif)|*.gif";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream filelocation = (FileStream)sfd.OpenFile();
                switch (sfd.FilterIndex)
                {
                    case 1: picResize.Image.Save(filelocation, ImageFormat.Bmp); break;
                    case 2: picResize.Image.Save(filelocation, ImageFormat.Jpeg); break;
                    case 3: picResize.Image.Save(filelocation, ImageFormat.Png); break;
                    case 4: picResize.Image.Save(filelocation, ImageFormat.Tiff); break;
                    case 5: picResize.Image.Save(filelocation, ImageFormat.Gif); break;
                }
            }
        }
    }
}
