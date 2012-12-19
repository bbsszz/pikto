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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AForge.Math;
namespace Pikto.Position3DForm
{
    /// <summary>
    /// Interaction logic for SimpleMatrix44.xaml
    /// </summary>
    public partial class SimpleMatrix44 : UserControl
    {
        public SimpleMatrix44()
        {
            InitializeComponent();
        }
        public void setMtx(Matrix4x4 mtx){
            m00.Text = mtx.V00.ToString();
            m01.Text = mtx.V01.ToString();
            m02.Text = mtx.V02.ToString();
            m03.Text = mtx.V03.ToString();

            m10.Text = mtx.V10.ToString();
            m11.Text = mtx.V11.ToString();
            m12.Text = mtx.V12.ToString();
            m13.Text = mtx.V13.ToString();
            
            m20.Text = mtx.V20.ToString();
            m21.Text = mtx.V21.ToString();
            m22.Text = mtx.V22.ToString();
            m23.Text = mtx.V23.ToString();

            m30.Text = mtx.V30.ToString();
            m31.Text = mtx.V31.ToString();
            m32.Text = mtx.V32.ToString();
            m33.Text = mtx.V33.ToString();
        
        }
    }
}
