using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prakt10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^\d{2}/([а-я]{3}|\d{2})/\d{4}$");
            if (regex.IsMatch(t1.Text.ToLower())) MessageBox.Show("Всё хорошо! :)))))))))))");
            else MessageBox.Show("НЕТ!", "Ошибка(((");
        }

        //private void b31_Click(object sender, RoutedEventArgs e)
        //{
        //    Regex regex1 = new Regex(@"(\+|-|\*|/)(\+|-|\*|/)");
        //    Regex regex2 = new Regex(@"^\d.*(\+|-|\*|/).*\d$");
        //    Regex regex3 = new Regex(@"^(\d|\+|-|\*|/)*$");
        //    if (regex1.IsMatch(t31.Text.ToLower()) == false 
        //        && regex2.IsMatch(t31.Text)
        //        && regex3.IsMatch(t31.Text)) MessageBox.Show("Всё хорошо! :)))))))))))");
        //    else MessageBox.Show("НЕТ!", "Ошибка(((");
        //}
    }
}
