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

namespace SNTImageConverter
{
    public partial class ImageConverterForm : Form
    {
        public ImageConverterForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        

        private void btnAddVertical_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Insert a image";
            //ofd.Filter = "Save an image";
            ofd.Filter = @"
                         jpg file(*.jpg)|*.jpg|
                        jpeg file(*.jpeg)|*.jpeg|
                        png(*.png)|*.png|
                         Bitmap(*.bmp)|*.bmp|
                        Tagged Image File Format(*.tiff)|*.tiff|
                         Graphics Interchange Format(*.gif)|*.gif|
                          Icon Format(*.ico)|*.ico";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (picOriginal.Image == null)
                {
                    picOriginal.Image = Image.FromFile(ofd.FileName);
                    
                }
                else
                {
                    picOriginal.Image = picOriginal.Image.addImageVertical(Image.FromFile(ofd.FileName));
                   
                }
                lblOriginalResolution.Text = String.Format("{0}*{1} pixels", picOriginal.Image.Width, picOriginal.Image.Height);
                txtWidth.Value = picOriginal.Image.Width;
                txtHeight.Value = picOriginal.Image.Height;
            }

        }
        private void btnAddHorizontal_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Insert a image";
            //ofd.Filter = "Save an image";
            ofd.Filter = @"
                         jpg file(*.jpg)|*.jpg|
                        jpeg file(*.jpeg)|*.jpeg|
                        png(*.png)|*.png|
                         Bitmap(*.bmp)|*.bmp|
                        Tagged Image File Format(*.tiff)|*.tiff|
                         Graphics Interchange Format(*.gif)|*.gif|
                          Icon Format(*.ico)|*.ico";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (picOriginal.Image == null)
                {
                    picOriginal.Image = Image.FromFile(ofd.FileName);

                }
                else
                {
                    picOriginal.Image = picOriginal.Image.addImageHorizontal(Image.FromFile(ofd.FileName));

                }
                lblOriginalResolution.Text = String.Format("{0}*{1} pixels", picOriginal.Image.Width, picOriginal.Image.Height);
                txtWidth.Value = picOriginal.Image.Width;
                txtHeight.Value = picOriginal.Image.Height;
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
            if (picOriginal.Image != null)
            {
                int width = Convert.ToInt32(txtWidth.Value);
                int height = Convert.ToInt32(txtHeight.Value);

                Image img = picOriginal.Image.toChangeSize(width, height);
                picResize.Image = img;
               

               
                if (comboBox1.SelectedItem.ToString() == "ToBinary")
                {
                    picResize.Image = img.toBinary(150);
                }
                if (comboBox1.SelectedItem.ToString().Contains("Gray"))
                {
                    picResize.Image = img.toGrayScale(comboBox1.SelectedItem.ToString());
                }
                 if (comboBox1.SelectedItem.ToString().Equals("Negative"))
                {
                    picResize.Image = img.toNegative();
                }

                if (comboBox1.SelectedItem.ToString().Equals("to 1.5x2 Array in A4 page"))
                {
                    //picResize.Image = img.toA4Array(4 * 96, 6 * 96);
                    picResize.Image = img.toA4Array(450, 600);

                }
                if (comboBox1.SelectedItem.ToString().Equals("to 4x6 Array in A4 page"))
                {
                    //picResize.Image = img.toA4Array(4 * 96, 6 * 96);
                    picResize.Image = img.toA4Array(1200, 1800 );
                 
                }
                if (comboBox1.SelectedItem.ToString().Equals("to 3x2 Array in A4 page"))
                {
                    //picResize.Image = img.toA4Array(4 * 96, 6 * 96);
                    picResize.Image = img.toA4Array(900, 600,5,20,10);

                }
                if (comboBox1.SelectedItem.ToString().Equals("to 3x4 Array in A4 page"))
                {
                    //picResize.Image = img.toA4Array(4 * 96, 6 * 96);
                    picResize.Image = img.toA4Array(900, 1200, 5, 20, 10);

                }
                if (comboBox1.SelectedItem.ToString().Equals("to 4x3 Array in A4 page"))
                {
                    //picResize.Image = img.toA4Array(4 * 96, 6 * 96);
                    picResize.Image = img.toA4Array(1200, 900, 5, 20, 10);

                }
                
                lblResizeResolution.Text = String.Format("{0}*{1} pixels", picResize.Image.Width, picResize.Image.Height);
            }
        }
        //private int  inch2Pixel(double 
      


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save an image";
            sfd.Filter = @"
                             

                        Joint Photographic Expert Group(*.jpg)|*.jpg|
                        Portable Network Graphics(*.png)|*.png|
                        
                        Tagged Image File Format(*.tiff)|*.tiff|
                         Graphics Interchange Format(*.gif)|*.gif|
                            Bitmap(*.bmp)|*.bmp|
                          Icon Format(*.ico)|*.ico";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream filelocation = (FileStream)sfd.OpenFile())
                {
                    switch (sfd.FilterIndex)
                    {
                        
                        //case 1: picResize.Image.Save(filelocation, ImageFormat.Jpeg); break;
                        case 0: picResize.Image.Save(filelocation, ImageFormat.Jpeg); break;
                        case 1: picResize.Image.Save(filelocation, ImageFormat.Png); break;
                        case 2: picResize.Image.Save(filelocation, ImageFormat.Tiff); break;
                        case 3: picResize.Image.Save(filelocation, ImageFormat.Gif); break;
                        case 4: picResize.Image.Save(filelocation, ImageFormat.Bmp); break;
                        case 5: picResize.Image.Save(filelocation, ImageFormat.Icon); break;
                    }
                }
              
            }
        }

        private void buttLRotate_Click(object sender, EventArgs e)
        {
            if (picResize.Image != null)
            {
                Image img = picResize.Image.RotateLeft90();
                picResize.Image = img;
                lblResizeResolution.Text = String.Format("{0}*{1} pixels", img.Width, img.Height);
            }
            else if(picOriginal.Image!=null)
            {

                Image img = picOriginal.Image.RotateLeft90();
                picResize.Image = img;
                lblResizeResolution.Text = String.Format("{0}*{1} pixels", img.Width, img.Height);
            }
           
        }

        private void btnRRotate_Click(object sender, EventArgs e)
        {
            if (picResize.Image != null)
            {
                Image img = picResize.Image.RotateRight90();
                picResize.Image = img;
                lblResizeResolution.Text = String.Format("{0}*{1} pixels", img.Width, img.Height);
            }
            else if (picOriginal.Image != null)
            {
                Image img = picOriginal.Image.RotateRight90();
                picResize.Image = img;
                lblResizeResolution.Text = String.Format("{0}*{1} pixels", img.Width, img.Height);
            }
        
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (picResize.Image != null)
            {
                ImagePrintDocument pd = new ImagePrintDocument(picResize.Image);
                PrintPreviewDialog dialog = new PrintPreviewDialog();
               dialog.Document = pd;
               
                //dialog.Show();
                dialog.Show();
                
                
            }
           
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            picOriginal.Image = null;
            picResize.Image = null;
        }

       
    }
}
