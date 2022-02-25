using Laboratory.Model;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace Laboratory
{
    public partial class AddPatientsPage : Page
    {
        private Patient patient = new Patient();
        public AddPatientsPage()
        {
            InitializeComponent();
            SocialTypeCB.ItemsSource = IgishevWSEntities6.GetContext().SocialTypes.ToList();
            InsuranceCB.ItemsSource = IgishevWSEntities6.GetContext().Insurances.ToList();
            DataContext = patient;

            var rt = IgishevWSEntities6.GetContext().SocialTypes.ToList();
            rt.Insert(0, new SocialType
            {
                Type = "Выберите тип"
            });
            SocialTypeCB.ItemsSource = rt;
        }

        private void BtnAddPatients_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(patient.FullName))
                errors.AppendLine("Укажите ФИО");
            if (patient.DateOfBirth == null)
                errors.AppendLine("Укажите дату рождения");
            if (BirthDayDP.SelectedDate > DateTime.Now)
                errors.AppendLine("Дата рождения не может быть позже сегодняшнего дня");
            if (patient.PassportSeries == null)
                errors.AppendLine("Укажите серию паспорта");
            if (patient.PassportNumbers == null)
                errors.AppendLine("Укажите номер паспорта");
            if (patient.Phone == null)
                errors.AppendLine("Укажите номер телефона");
            if (string.IsNullOrWhiteSpace(patient.Email))
                errors.AppendLine("Укажите Email");
            if (patient.SocialNumber == null)
                errors.AppendLine("Укажите номер страхового полиса");
            /*if (patient.SocialType == null)
                errors.AppendLine("выберите тип страхового полиса");
            if (patient.InsuranceID == null)
                errors.AppendLine("выберите страховую компанию");*/

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (patient.ID == 0)
               IgishevWSEntities6.GetContext().Patients.Add(patient);

            try
            {
                IgishevWSEntities6.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.myFrame.Navigate(new BiomatLabPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.myFrame.GoBack();
        }
    }
}
