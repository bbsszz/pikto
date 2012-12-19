using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AForge.Math;
using AForge.Math.Geometry;
using Emgu.CV;
using Emgu.CV.Structure;
namespace Pikto.Position3DForm
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Image<Bgr, Byte> img;
        ViewPosit v;
        public Window1()
        {
            img = new Image<Bgr, Byte>(200, 150, new Bgr(0, 0, 0));
            InitializeComponent();
            v = new ViewPosit(200, 150);
            v.drawPoint(img);
            ImageView.Source=Camera.ToBitmapSource(img);
            worldMtx.setMtx(v.worldMatrix);
            wiewMtx.setMtx(v.viewMatrix);
           
        }
        public void updateAngle(float yaw, float pitch, float roll)
        {
            
            v.updateAngle(yaw, pitch, roll);
            img = new Image<Bgr, Byte>(200, 150, new Bgr(0, 0, 0));
            v.drawPoint(img);
            ImageView.Source = Camera.ToBitmapSource(img);
            worldMtx.setMtx(v.worldMatrix);
            wiewMtx.setMtx(v.viewMatrix);
        }
        public void setEstymationLabel(float estimatedYaw, float estimatedPitch, float estimatedRoll)
        {
            angleLabel.Content = string.Format("Angle Rotation : \n yaw(y)={0} \n pitch(x)={1} \n roll(z)={2})",
                 estimatedYaw, estimatedPitch, estimatedRoll);
        }
        public void setImagePoint(AForge.Point[] imagePoints)
        {
            pointCord1.Text = imagePoints[0].ToString();
            pointCord2.Text = imagePoints[1].ToString();
            pointCord3.Text = imagePoints[2].ToString();
            pointCord4.Text = imagePoints[3].ToString();
        }
        public void setModelPoints(Vector3[] modelPoints)
        {
            modelCord1x.Text = modelPoints[0].X.ToString();
            modelCord1y.Text = modelPoints[0].Y.ToString();
            modelCord1z.Text = modelPoints[0].Z.ToString();

            modelCord2x.Text = modelPoints[1].X.ToString();
            modelCord2y.Text = modelPoints[1].Y.ToString();
            modelCord2z.Text = modelPoints[1].Z.ToString();

            modelCord3x.Text = modelPoints[2].X.ToString();
            modelCord3y.Text = modelPoints[2].Y.ToString();
            modelCord3z.Text = modelPoints[2].Z.ToString();

            modelCord4x.Text = modelPoints[3].X.ToString();
            modelCord4y.Text = modelPoints[3].Y.ToString();
            modelCord4z.Text = modelPoints[3].Z.ToString();

        }
        public void setTransformatinMatrix(Matrix4x4 m)
        {
            est00.Text = m.V00.ToString();
            est01.Text = m.V01.ToString();
            est02.Text = m.V01.ToString();
            est03.Text = m.V03.ToString();

            est10.Text = m.V10.ToString();
            est11.Text = m.V11.ToString();
            est12.Text = m.V12.ToString();
            est13.Text = m.V13.ToString();

            est20.Text = m.V20.ToString();
            est21.Text = m.V21.ToString();
            est22.Text = m.V22.ToString();
            est23.Text = m.V23.ToString();

            est30.Text = m.V30.ToString();
            est31.Text = m.V31.ToString();
            est32.Text = m.V32.ToString();
            est33.Text = m.V33.ToString();



        }
    }
}
