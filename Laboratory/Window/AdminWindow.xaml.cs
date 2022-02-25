using System.Windows;
using System.Windows.Controls;

namespace Laboratory
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            Manager.myFrame = Frame;
            Frame.Navigate(new MenuAdminPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }        
    }
}
