﻿using System;
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
        

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Insert a image";
            ofd.Filter = "JPEG Images|*.jpg|PNG Images |*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picOriginal.Image = Image.FromFile(ofd.FileName);
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
                else if (comboBox1.SelectedItem.ToString().Contains("Gray"))
                {
                    picResize.Image = img.toGrayScale(comboBox1.SelectedItem.ToString());
                }
                else if (comboBox1.SelectedItem.ToString().Equals("Negative"))
                {
                    picResize.Image = img.toNegative();
                }
                else if (comboBox1.SelectedItem.ToString().Equals("to 4x6 Array in A4 page"))
                {
                    picResize.Image = img.toA4Array();
                   
                }
                lblResizeResolution.Text = String.Format("{0}*{1} pixels", picResize.Image.Width, picResize.Image.Height);
            }
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
                         Graphics Interchange Format(*.gif)|*.gif|
                          Icon Format(*.ico)|*.ico";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream filelocation = (FileStream)sfd.OpenFile())
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1: picResize.Image.Save(filelocation, ImageFormat.Bmp); break;
                        case 2: picResize.Image.Save(filelocation, ImageFormat.Jpeg); break;
                        case 3: picResize.Image.Save(filelocation, ImageFormat.Png); break;
                        case 4: picResize.Image.Save(filelocation, ImageFormat.Tiff); break;
                        case 5: picResize.Image.Save(filelocation, ImageFormat.Gif); break;
                        case 6: picResize.Image.Save(filelocation, ImageFormat.Icon); break;
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
    }
}