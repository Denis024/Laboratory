using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Laboratory
{
    public partial class LaborantWindow : Window
    {
        DispatcherTimer _timer;
        TimeSpan _time, _time2;

        public LaborantWindow()
        {
            InitializeComponent();
  
            Manager.myFrame = Frame;
            Frame.Navigate(new BiomatLabPage());

            // Таймер
            _time = TimeSpan.FromSeconds(600);
            _time2 = TimeSpan.FromSeconds(300);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = _time.ToString("c");
                if (_time == _time2)
                {
                    MessageBox.Show("До выхода осталось " + _time);
                }
                else if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    this.Close();
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timer.Start();  
            

        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Manager.myFrame.Navigate(new SearchPatientPage());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Process.GetCurrentProcess().Kill();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            _timer.Stop();
            this.Close();      
        }    
    }
}
