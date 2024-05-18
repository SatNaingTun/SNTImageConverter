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
using SNTImageConverter.Function;
using System.Threading;



namespace SNTImageConverter
{
    public partial class ImageConverterForm : Form
    {
        //Color oldColor=Color.Yellow;
        bool colorPick = false;
        public ImageConverterForm()
        {
            InitializeComponent();
            //colorRect.FillColor = oldColor;

            
           
           
        }
        public ImageConverterForm(string[] args)
        {
            InitializeComponent();
            
            //colorRect.FillColor = oldColor;
            foreach (string fileName in args)
            {
                if (isValidFile(fileName))
                {
                    if (picOriginal.Image == null)
                    {
                        picOriginal.Image = Image.FromFile(fileName);

                    }
                    else
                    {
                        picOriginal.Image = picOriginal.Image.addImageHorizontal(Image.FromFile(fileName));

                    }
                }
               
            }
        }
        private bool isValidFile(string fileName)
        {
            
                if (File.Exists(fileName))
                {
                    FileInfo fileInfo = new FileInfo(fileName);

                    switch (fileInfo.Extension)
                    {
                        case ".jpg":return true;
                        case ".jpeg": return true;
                        case ".png": return true;
                        case ".bmp": return true;
                        case ".tiff": return true;
                        case ".gif": return true;
                        case ".ico": return true;
                        default: return false;
                    }   
                 }
                return false;
        }
        

        private void btnAddVertical_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Insert a image";
            //ofd.Filter = "Save an image";
            ofd.Filter = @"
                       (*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif;*.ico)|*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif;*.ico|          
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
        private Image getImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Insert a image";
            //ofd.Filter = "Save an image";
            ofd.Filter = @"
                         (*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif;*.ico)|*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif;*.ico|
                        jpg file(*.jpg)|*.jpg|
                        jpeg file(*.jpeg)|*.jpeg|
                        png(*.png)|*.png|
                         Bitmap(*.bmp)|*.bmp|
                        Tagged Image File Format(*.tiff)|*.tiff|
                         Graphics Interchange Format(*.gif)|*.gif|
                          Icon Format(*.ico)|*.ico";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return Image.FromFile(ofd.FileName);
            }

            return null;
        }
        private void btnAddHorizontal_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Insert a image";
            //ofd.Filter = "Save an image";
            ofd.Filter = @"(*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif;*.ico)|*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif;*.ico|
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
        
       

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (picOriginal.Image != null)
            {
                int width = Convert.ToInt32(txtWidth.Value);
                int height = Convert.ToInt32(txtHeight.Value);

                Image img = picOriginal.Image.toChangeSize(width, height);
                picResize.Image = img;

                if (comboBox1.SelectedItem == null || comboBox1.SelectedItem.ToString() == "None")
                {
                    picResize.Image = img;
                }
               
               else if (comboBox1.SelectedItem.ToString() == "ToBinary")
                {
                    picResize.Image = img.toBinary(180);
                }
               else if (comboBox1.SelectedItem.ToString().Contains("Gray"))
                {
                    picResize.Image = img.toGrayScale(comboBox1.SelectedItem.ToString());
                }
               else if (comboBox1.SelectedItem.ToString().Equals("Negative"))
                {
                    picResize.Image = img.toNegative();
                }
                else if (comboBox1.SelectedItem.ToString().Equals("Color Balance"))
                {
                    picResize.Image = img.ColorBalance(colorRect.FillColor.B, colorRect.FillColor.G, colorRect.FillColor.R);
                }
                else if (comboBox1.SelectedItem.ToString().Equals("to 1x1 Array in A4 page"))
                {
                    //picResize.Image = img.toA4Array(4 * 96, 6 * 96);
                    picResize.Image = img.toA4Array(300, 300);

                }
                else if (comboBox1.SelectedItem.ToString().Equals("to 1x1.5 Array in A4 page"))
                {
                    //picResize.Image = img.toA4Array(4 * 96, 6 * 96);
                    picResize.Image = img.toA4Array(300, 450);

                }

              else  if (comboBox1.SelectedItem.ToString().Equals("to 1.5x2 Array in A4 page"))
                {
                    //picResize.Image = img.toA4Array(4 * 96, 6 * 96);
                    picResize.Image = img.toA4Array(450, 600);

                }
               else if (comboBox1.SelectedItem.ToString().Equals("to 4x6 Array in A4 page"))
                {
                    //picResize.Image = img.toA4Array(4 * 96, 6 * 96);
                    picResize.Image = img.toA4Array(1200, 1800 );
                 
                }
               else if (comboBox1.SelectedItem.ToString().Equals("to 3x2 Array in A4 page"))
                {
                    //picResize.Image = img.toA4Array(4 * 96, 6 * 96);
                    picResize.Image = img.toA4Array(900, 600,5,20,10);

                }
               else if (comboBox1.SelectedItem.ToString().Equals("to 3x4 Array in A4 page"))
                {
                    //picResize.Image = img.toA4Array(4 * 96, 6 * 96);
                    picResize.Image = img.toA4Array(900, 1200, 5, 20, 10);

                }
               else if (comboBox1.SelectedItem.ToString().Equals("to 4x3 Array in A4 page"))
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
                if (picResize.Image == null) picResize.Image = picOriginal.Image;

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
            //ScreenCapture screen=new ScreenCapture();
            //picOriginal.Image = screen.captureScreen();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            picOriginal.Refresh();
        }

        private void screenShot_Click(object sender, EventArgs e)
        {
            //ScreenCapture screen = new ScreenCapture();
            //picOriginal.Image = screen.getActiveWindow();
            //CppScreenCapture sc = new CppScreenCapture();
            //foreach (string name in MyWindow.getAllProcessName())
            //{
            //    MessageBox.Show(name);
            //    if (picOriginal.Image == null)
            //        picOriginal.Image = sc.CaptureApplication(name);
            //    else
            //        picOriginal.Image = picOriginal.Image.addImageVertical(sc.CaptureApplication(name));
            //}

            //if (picOriginal.Image == null)
            //    picOriginal.Image = sc.CaptureApplication("SMS.UI");
            //else
            //    picOriginal.Image = picOriginal.Image.addImageVertical(sc.CaptureApplication("SMS.UI"));

            ScreenCapture screen = new ScreenCapture();

            if (picOriginal.Image == null)
            {
                picOriginal.Image = screen.captureScreen();
            }
            else
                picOriginal.Image = picOriginal.Image.addImageVertical(screen.captureScreen());

            
        }

        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            if (e.Button == MouseButtons.Left && picBox.Cursor==Cursors.Cross)
            {
                
                if (picBox.Image != null)
                {
                Bitmap myBitmap = new Bitmap(picBox.Image);

                if(e.X<picBox.Image.Width && e.Y<picBox.Image.Height)
                  colorRect.FillColor= myBitmap.GetPixel(e.X, e.Y);
                //MessageBox.Show("Old Color:"+oldColor);
               
                
                }
                
            }
        }
        Color GetColorAt(Point location)
        {
            using (Bitmap pixelContainer = new Bitmap(1, 1))
            {
                using (Graphics graphics = Graphics.FromImage(pixelContainer))
                {
                    graphics.CopyFromScreen(location, Point.Empty, pixelContainer.Size);
                }
                return pixelContainer.GetPixel(0, 0);
            }
        }

        private void colorRect_Click(object sender, EventArgs e)
        {
            //ColorDialog cldlg = new ColorDialog();
            //if (cldlg.ShowDialog() == DialogResult.OK)
            //{
            //    colorRect.FillColor = cldlg.Color;
            //}
            colorPick = true;
            
            //Cursor = Cursors.Cross;

            
           
        }

        private void picOriginal_MouseEnter(object sender, EventArgs e)
        {
            picOriginal.Cursor = Cursors.Cross;
        }

        private void picOriginal_MouseLeave(object sender, EventArgs e)
        {
            picOriginal.Cursor = Cursors.Default;
        }

       

      

        

       
    }
}
