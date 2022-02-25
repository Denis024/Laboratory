using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace Laboratory
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenButton_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            int codeOrder = 1234;

            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            var nowDate = $"{day}{month}{year}";

            int number = rnd.Next(100000, 999999);

            GenTB.Text = $"{codeOrder}{nowDate}{number}".ToString();
            barcode.Content = $"{codeOrder}{nowDate}{number}".ToString();
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            Export();
        }

        private void ExportToPdf()
        {

        }

        private void Export()
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() != true)
                return;
            dialog.PrintVisual();
        }
        
    }
}
