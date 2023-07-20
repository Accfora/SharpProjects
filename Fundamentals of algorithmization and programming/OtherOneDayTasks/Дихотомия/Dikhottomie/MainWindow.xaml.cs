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

namespace Dikhottomie
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
        Regex regex1 = new Regex(@"^-?\d+(,\d+)?$");
        Regex regex2 = new Regex(@"^-?\d+(,\d+)?( -?\d+(,\d+)?)*$");
        void Check()
        {
            if (regex1.IsMatch(TB_left.Text) && regex1.IsMatch(TB_right.Text) && 
                regex1.IsMatch(TB_tochnost.Text) && Convert.ToDouble(TB_tochnost.Text) > 0 && regex2.IsMatch(TB_els.Text))
                 B.IsEnabled = true;
            else
                B.IsEnabled = false;
        }
        static double f(double x, double[] els)
        {
            double result = 0;
            int power = els.Length;
            for (int i = 0; i < els.Length; i++)
            {
                result += els[i] * Math.Pow(x, power - 1);
                power--;
            }
            return result;
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            result.Content = "";

            double[] els = TB_els.Text.Split(' ').Select(x => double.Parse(x)).ToArray();
            double left = Convert.ToDouble(TB_left.Text);
            double right = Convert.ToDouble(TB_right.Text);
            if (right < left)
            {
                left = right;
                right = Convert.ToDouble(TB_left.Text);
            }
            double tochnost = Convert.ToDouble(TB_tochnost.Text);

            if (f(right, els) * f(left, els) > 0)
            {
                result.Content = "Метод дихтомии не подходит для заданных значений";
                return;
            }

            while (right - left > tochnost)
            {
                double mid = (left + right) / 2;

                if (f(right, els) * f(mid, els) <= 0)
                    left = mid;
                else if (f(left, els) * f(mid, els) <= 0)
                    right = mid;
            }

            result.Content = $"Ваш искомый корень: {Convert.ToDecimal((left + right) / 2)}";
        }

        private void Edited(object sender, TextChangedEventArgs e)
        {
            Check();
        }
    }
}
