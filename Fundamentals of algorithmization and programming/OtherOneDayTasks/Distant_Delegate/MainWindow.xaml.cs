using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Distant_Delegate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void Calc(double x, double y, ref string s);

        static void Sum(double x, double y, ref string s)
        {
            s += "Результат сложения: " + (x + y) + "\n";
        }
        static void Sub(double x, double y, ref string s)
        {
            s += "Результат вычитания: " + (x - y) + "\n";
        }
        static void Mult(double x, double y, ref string s)
        {
            s += "Результат умножения: " + (x * y) + "\n";
        }
        static void Div(double x, double y, ref string s)
        {
            if (y == 0) s += "Делить на 0 нельзя!\n";
            else s += "Результат деления: " + (x / y) + "\n";
        }
        static void Power(double x, double y, ref string s)
        {
            s += "Результат возведения в степень: " + Math.Pow(x,y) + "\n";
        }
        static void Calculate(Calc calc, double a, double b, ref string s)
        {
            calc(a, b, ref s);
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void equals_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(tb1.Text);
            double b = Convert.ToDouble(tb2.Text);
            string s = "";
            Calc[] calcArray = {Sum, Sub, Mult, Div, Power};
            Calculate(calcArray[operation.SelectedIndex], a, b, ref s);
            result.Content = s;
        }
    }
}
