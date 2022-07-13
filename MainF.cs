using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;

namespace C_Sharp_Rotation_Flip_Resize
{
    public partial class MainF : Form
    {
        public MainF()
        {
            InitializeComponent();
        }

        private void MainF_Load(object sender, EventArgs e)
        {


            using(OpenFileDialog oDialog = new OpenFileDialog())
            { 
                if (oDialog.ShowDialog() == DialogResult.OK)
                {
                    oDialog.InitialDirectory = Application.StartupPath;
                    oDialog.Filter = "그림 파일  (*.jpg, *.gif, *.bmp) | *.jpg; *.gif; *.bmp; | *.*";

                    //MessageBox.Show(Properties.Resources.Tagicoma_04.ToString());
                    
                    Mat src = Cv2.ImRead(oDialog.FileName, ImreadModes.Color);

                    //Mat src = Cv2.ImRead(@"..Resources\Tagicoma.04.jpg", ImreadModes.Color);
                    Mat dst = new Mat();

                    Cv2.Flip(src, dst, FlipMode.X);

                    pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);
                    pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst);

                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    //pictureBox1.BackgroundImage = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);
                    //pictureBox2.BackgroundImage = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst);
                    //pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }
    }
}
