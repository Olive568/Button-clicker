using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Threading;

namespace Button
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _timerStatus = false;
        DispatcherTimer _dt = null;
        public MainWindow()
        {
            InitializeComponent();
            _dt = new DispatcherTimer();
            _dt.Tick += _dt_Tick;
            _dt.Interval = new TimeSpan(0, 0, 0, 1, 0);
        }

        private void _dt_Tick(object sender, EventArgs e)
        {
            int sec = int.Parse(lblTimerDisplay.Content.ToString());
            sec++;
            if (sec > 59)
            {
                sec = 0;
                lblTimerDisplay_Min.Content =
                    int.Parse(lblTimerDisplay_Min.Content.ToString()) + 1;
            }
            lblTimerDisplay.Content = sec.ToString();
        }


        private void Btnmoving_MouseEnter(object sender, MouseEventArgs e)
        {
            if (_timerStatus) 
            {
                Random rnd = new Random();
                int height = rnd.Next(1, 351);
                int width = rnd.Next(1, 701);
                Btnmoving.Margin = new Thickness(width, height, 0, 0);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_timerStatus)
                _dt.Stop();
            else
                _dt.Start();

            _timerStatus = !_timerStatus;
            if (_timerStatus)
                Btnmoving.Content = "Click me :3";
            else
            {
                Btnmoving.Content = "Start";
                MessageBox.Show("you win. it took you " + lblTimerDisplay_Min.Content + " minutes and " + lblTimerDisplay.Content +" seconds");
            }

        }
    }
}
