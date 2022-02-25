using Laboratory.Model;
using System;
using System.Linq;
using System.Windows;

namespace Laboratory
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text;
            string pass = PassTB.Password;
            User authUser = null;
            using (IgishevWSEntities6 db = new IgishevWSEntities6())
            {
                authUser = db.Users.Where(b => b.Login == login && b.Password == pass).FirstOrDefault();
            }

            if (authUser != null)
                if (authUser.Position == "Лаборант")
                {
                    LaborantWindow laborantWindow = new LaborantWindow();
                    laborantWindow.Show();
                    this.Close();
                    laborantWindow.FullNameTB.Text = authUser.FullName;                   
                    AddHistory(login, "Успех");
                }
                else
                if (authUser.Position == "Бухгалтер")
                {
                    ByxWindow byxWindow = new ByxWindow();
                    byxWindow.Show();
                    this.Close();
                    byxWindow.FullNameTB.Text = authUser.FullName;
                    AddHistory(login, "Успех");
                }
                else
                if (authUser.Position == "Администратор")
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                    adminWindow.FullNameTB.Text = authUser.FullName;
                    AddHistory(login, "Успех");
                }
                else
                if (authUser.Position == "Лаборант-исследователь")
                {
                    Lab_islWindow lab_Isl= new Lab_islWindow();
                    lab_Isl.Show();
                    this.Close();
                    lab_Isl.FullNameTB.Text = authUser.FullName;
                    AddHistory(login, "Успех");
                }
                else
                {
                    MessageBox.Show("Для данной должности вход не предусмотрен!");
                    AddHistory(login, "Отказ");
                }                    
            else            
                MessageBox.Show("Данного пользователя не существует");
        }

        private void AddHistory(string login, string attempttologin)
        {
            DateTime nowDate = DateTime.Now;

            using (var db = new IgishevWSEntities6())
            {
                User user = db.Users.Where(u => u.Login.ToLower() == login.ToLower()).FirstOrDefault();

                LastEnter history = new LastEnter
                {
                    DateTime = nowDate,
                    AttemptToLogin = attempttologin,
                    UsersID = user.ID
                };

                db.LastEnters.Add(history);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
