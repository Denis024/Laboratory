using Laboratory.Model;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;



namespace Laboratory
{
    public partial class BiomatLabPage : Page
    {   
        public BiomatLabPage()
        {
            InitializeComponent();
            ServicesCB.ItemsSource = IgishevWSEntities6.GetContext().Services.ToList();
        }

        private void GenButton_Click(object sender, RoutedEventArgs e)
        {           
            Random rnd = new Random();

            int codeOrder;
            var orders = IgishevWSEntities6.GetContext().Orders.ToList();
            var lastOrder = orders.Last();
            codeOrder = lastOrder.ID + 1;

            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            var nowDate = $"{day}{month}{year}"; 

            int number = rnd.Next(100000, 999999);
          
            GenTB.Text = $"{codeOrder}{nowDate}{number}".ToString(); 
            barcode1.Content = $"{codeOrder}{nowDate}{number}".ToString();
        }

        private void CodeTB_GotFocus(object sender, RoutedEventArgs e)
        {
            int codeOrder;
            var orders = IgishevWSEntities6.GetContext().Orders.ToList();
            var lastOrder = orders.Last();
            codeOrder = lastOrder.ID + 1;
            CodeTB.Text = codeOrder.ToString();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            LaborantWindow laborantWindow = new LaborantWindow();
            StringBuilder errors = new StringBuilder();

            using (var db = new IgishevWSEntities6())
            {
                string fullname = FullNameTB.Text;
                var authPatient = db.Patients.Where(b => b.FullName == fullname).FirstOrDefault();
                var servCode = db.Services.Where(b => b.Name == ServicesCB.Text).FirstOrDefault();

                Order order = new Order
                {
                    PatientsID = authPatient.ID,
                    Barcode = GenTB.Text,
                    Date = DateTime.Now.Date,
                    UsersID = 7,
                    ServicesCode = servCode.Code
                };

                ExportToWord(order, CodeTB.Text);
                ExportBarcodePdf();

                db.Orders.Add(order);
                db.SaveChanges();
                MessageBox.Show("Заказ сформирован!");
            }

        }

        private void ExportBarcodePdf()
        {
            PrintDialog dialog = new PrintDialog();
            dialog.PrintVisual(barcode1, "123");
        }

        private void ExportToWord(Order order, string codeOrder)
        {
            var application = new Word.Application();
            Word.Document document = application.Documents.Add();

            var styleTitle = Word.WdBuiltinStyle.wdStyleTitle;

            Word.Paragraph orderParagraph = document.Paragraphs.Add();
            Word.Range orderRange = orderParagraph.Range;
            orderRange.Text = $"Заказ №{codeOrder}";
            orderParagraph.set_Style(styleTitle);
            orderRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table orderTable = document.Tables.Add(tableRange, 8, 2);
            orderTable.Borders.InsideLineStyle = orderTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            orderTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            DateTime dateCrreate = (DateTime)order.Date;

            cellRange = orderTable.Cell(1, 2).Range;
            cellRange.Text = dateCrreate.ToShortDateString();
            cellRange = orderTable.Cell(1, 1).Range;
            cellRange.Text = "Дата создания";

            cellRange = orderTable.Cell(2, 2).Range;
            cellRange.Text = codeOrder;
            cellRange = orderTable.Cell(2, 1).Range;
            cellRange.Text = "Код заказа";

            cellRange = orderTable.Cell(3, 2).Range;
            cellRange.Text = codeOrder;
            cellRange = orderTable.Cell(3, 1).Range;
            cellRange.Text = "Код пробирки";

            /*cellRange = orderTable.Cell(4, 2).Range;
            cellRange.Text = ;
            cellRange = orderTable.Cell(3, 1).Range;
            cellRange.Text = "Номер страховой";*/

            /*cellRange = orderTable.Cell(5, 2).Range;
            cellRange.Text = order.laborantWindow.FullNameTB.Text;
            cellRange = orderTable.Cell(5, 1).Range;
            cellRange.Text = "ФИО";*/

            //DateTime birthDay = (DateTime)orders.

            /*cellRange = orderTable.Cell(6, 2).Range;
            cellRange.Text = ;
            cellRange = orderTable.Cell(3, 1).Range;
            cellRange.Text = "Код пробирки";*/

            /*cellRange = orderTable.Cell(7, 2).Range;
            cellRange.Text = order.Service.;
            cellRange = orderTable.Cell(7, 1).Range;
            cellRange.Text = "Процедуры";*/

            /*cellRange = orderTable.Cell(8, 2).Range;
            cellRange.Text = Services ;
            cellRange = orderTable.Cell(8, 1).Range;
            cellRange.Text = "Процедуры";*/


            var fileNameToSave = $"Order #{codeOrder}, Date create {dateCrreate.ToShortDateString()}";
            var pathToSave = $"{AppDomain.CurrentDomain.BaseDirectory}Orders\\{fileNameToSave}";

            document.SaveAs2(pathToSave + ".docx");
            document.SaveAs2(pathToSave + ".pdf");
        }

        private void BtnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            Manager.myFrame.Navigate(new AddPatientsPage());
        }

        private void FullNameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            string fullname = FullNameTB.Text;
            Patient authPatient = null;
            using (IgishevWSEntities6 db = new IgishevWSEntities6())
            {
                authPatient = db.Patients.Where(b => b.FullName == fullname).FirstOrDefault();
            }
            if (authPatient != null)
            {
                MessageBox.Show("Пользователь существует");
            }
            else
            {
                MessageBox.Show("Данного пользователя не существует!");
                BtnAddPatient.Visibility = Visibility.Visible;
            }
        }
    }
}
