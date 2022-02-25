using Laboratory.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Laboratory
{
    public partial class SearchPatientPage : Page
    {
        public SearchPatientPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.myFrame.GoBack();
        }

        private void Search()
        {
            var currentPatient = IgishevWSEntities6.GetContext().Patients.ToList();

            currentPatient = currentPatient.Where(p => p.FullName.ToLower().Contains(fullNameTB.Text.ToLower())).ToList();
            currentPatient = currentPatient.Where(p => p.DateOfBirth.ToString().ToLower().Contains(birthDayDP.Text.ToLower())).ToList();
            currentPatient = currentPatient.Where(p => p.PassportSeries.ToString().ToLower().Contains(pasSerialTB.Text.ToLower())).ToList();
            currentPatient = currentPatient.Where(p => p.PassportNumbers.ToString().Contains(pasNumberTB.Text)).ToList();

            myGrid.ItemsSource = currentPatient;
        }

        private void fullNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void birthDayDP_CalendarClosed(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            //Manager.myFrame.Navigate(new AddPatientsPage((sender as Button).DataContext as Patient));
        }
    }
}
