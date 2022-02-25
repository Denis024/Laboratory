using System.Windows;
using System.Windows.Controls;

namespace Laboratory
{
    public partial class MenuAdminPage : Page
    {
        public MenuAdminPage()
        {
            InitializeComponent();
        }

        private void LastEnter_Click(object sender, RoutedEventArgs e)
        {
            Manager.myFrame.Navigate(new LastEnterPage());
        }
    }
}
