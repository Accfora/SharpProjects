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

namespace DistantAuf1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<double> lst = new List<double>();
        public MainWindow()
        {
            InitializeComponent();
        }
        public static double Second(double[] M, ref bool ft)
        {
            ft = false;
            double max = double.MinValue;
            double almost = double.MinValue;
            foreach(double t in M) if (t > max) max = t;
            bool okornot = false;
            foreach (double t in M)
            {
                if (t < max)
                {
                    okornot = true;
                    break;
                }
            }
            if (okornot)
            {
                foreach (double t in M) if (t > almost && t != max) almost = t;
                ft = true;
            }
            return almost;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Regex reg = new Regex(@"^(-|\+)?\d+(,\d+)?$");
            if (reg.IsMatch(tb.Text))
            {
                lst.Add(Convert.ToDouble(tb.Text));
                if (curr.Content == "") curr.Content += ""+lst[lst.Count - 1];
                else curr.Content += "; " + lst[lst.Count - 1];
                tb.Text = "";
            }
            else MessageBox.Show("Число введено некорректно!");
            if (lst.Count > 0) ok.IsEnabled = true;
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb.Text.Length < 1) add.IsEnabled = false;
            else add.IsEnabled = true;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            double[] bM = new double[lst.Count];
            for (int i = 0; i < bM.Length; i++) bM[i] = lst[i];
            bool q = false;
            double second = Second(bM, ref q);
            if (q) l.Content = "Второй по величине элемент массива равен " + second;
            else l.Content = "Второго по величине элемента массива не существует";
            ok.IsEnabled = false;
        }

        private void again_Click(object sender, RoutedEventArgs e)
        {
            lst.Clear(); tb.Text = ""; l.Content = ""; curr.Content = "";
            add.IsEnabled = false; ok.IsEnabled = false;
        }
    }
}