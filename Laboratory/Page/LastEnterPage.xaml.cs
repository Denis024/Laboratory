using Laboratory.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Laboratory
{
    public partial class LastEnterPage : Page
    {        
        public LastEnterPage()
        {
            InitializeComponent();
            myTable.ItemsSource = IgishevWSEntities6.GetContext().LastEnters.ToList();

            var allLogin = IgishevWSEntities6.GetContext().Users.ToList();
            allLogin.Insert(0, new User
            {
                Login = "Все логины"
            });
            SortLoginCB.ItemsSource = allLogin;

            Update();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.myFrame.GoBack();
        }

        private void SortDateCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();           
        }

        private void Update()
        {
            var currentProduct = IgishevWSEntities6.GetContext().LastEnters.ToList();

            switch (SortDateCB.SelectedIndex)
            {
                case 0: { currentProduct = currentProduct.ToList(); break; }
                case 1: { currentProduct = currentProduct.OrderBy(s => s.DateTime).ToList(); break; }
                case 2: { currentProduct = currentProduct.OrderByDescending(s => s.DateTime).ToList(); break; }
            }
            myTable.ItemsSource = currentProduct;
        }

        private void SortLoginCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
