using System.Windows;

namespace Laboratory
{
    public partial class ByxWindow : Window
    {
        public ByxWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
