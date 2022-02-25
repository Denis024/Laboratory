using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Laboratory
{
    public partial class Lab_islWindow : Window
    {
        DispatcherTimer _timer;
        TimeSpan _time, _time2;

        public Lab_islWindow()
        {
            InitializeComponent();

            Manager.myFrame = Frame;
            Frame.Navigate(new AnalyzerPage());

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

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            _timer.Stop();
        }
    }
}
