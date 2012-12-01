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
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Runtime.InteropServices;
using System.Windows.Threading;
namespace Pikto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        MarkerDetector md;
        Capture c;
        ImageViewer v;
        Image<Bgr, Byte> img;
        public MainWindow()
        {
            InitializeComponent();
            md = new MarkerDetector();
            c = new Capture();
            v = new ImageViewer();

        }

        private void TimerHandler(object sender, EventArgs e)
        {
            md.findMarkers(c.QueryGrayFrame());
            img = c.QueryFrame();
            if (md.getMarkerCount() == 1) {
                EmguTools.draw4ContourAndCircle(img, 
                    md.getMarkers().First().getContourExternal());
          }
            v.Image = img;
            
        }

        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           timer = new DispatcherTimer();
            timer.Interval = System.TimeSpan.FromMilliseconds(25);
            timer.Tick += new EventHandler(TimerHandler);
            timer.Start(); 
            v.Show();
           
        }

    }
}
