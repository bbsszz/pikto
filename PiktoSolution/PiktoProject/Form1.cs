using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;



namespace FindCorners
{
    public partial class Form1 : Form
    {
        private Capture _capture;
        private bool _captureInProgres;



        public Form1()
        {
            InitializeComponent();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            Int32 width = (int)numericUpDown1.Value;
            Int32 height = (int)numericUpDown2.Value;
            Size patternSize = new Size(width, height);


         /*   if (_capture == null)
            {
                try { _capture = new Capture(); }
                catch (NullReferenceException except)
                {
                    MessageBox.Show(except.Message);
                }
            }
            if (_capture != null)
            {
                if (_captureInProgres)
                {

                 }
                else
                {

                }
                _captureInProgres = !_captureInProgres;
            }
            */


            if (_capture == null)
            {
                try { _capture = new Capture(); }
                catch (NullReferenceException except)
                {
                    MessageBox.Show(except.Message);
                }
            }

            Image<Bgr, Byte> image2 = _capture.QueryFrame();
            Image<Gray, Byte> gray_image = image2.Convert<Gray, Byte>();

            CvInvoke.cvShowImage("gray scale input image", gray_image.Ptr);

            PointF[] corners = new PointF[] { };

            corners = CameraCalibration.FindChessboardCorners(gray_image, patternSize, Emgu.CV.CvEnum.CALIB_CB_TYPE.ADAPTIVE_THRESH | Emgu.CV.CvEnum.CALIB_CB_TYPE.FILTER_QUADS);

            if (corners != null)
            {
                CameraCalibration.DrawChessboardCorners(gray_image, patternSize, corners);
                CvInvoke.cvShowImage("Result", gray_image.Ptr);


                CvInvoke.cvWaitKey(0);

            }
        }

        

        }

    }

