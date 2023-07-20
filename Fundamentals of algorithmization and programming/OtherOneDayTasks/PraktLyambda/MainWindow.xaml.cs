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

namespace PraktLyambda
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate double AVG(double[] M);
        delegate bool Check(double[] M, Condition j);
        AVG chet = (double[] M) => //резултиьтр - оььто пргтололтлотщшшщ отщрло тооьшоолоощод
        {
            double sum = 0;
            int c = 0;
            foreach (double i in M)
            {
                if (i % 2 == 0)
                {
                    c += 1;
                    sum += i;
                }
            }
            return sum / c;
        };
        AVG nechet = (double[] M) =>
        {
            double sum = 0;
            int c = 0;
            foreach (int i in M)
            {
                if (i % 2 == 1)
                {
                    c += 1;
                    sum += i;
                }
            }
            return sum / c;
        };
        AVG plus = (double[] M) =>
        {
            double sum = 0;
            int c = 0;
            foreach (int i in M)
            {
                if (i > 0)
                {
                    c += 1;
                    sum += i;
                }
            }
            if (c == 0)
                return 0.0;
            return sum / c;
        };
        AVG minus = (double[] M) =>
        {
            double sum = 0;
            int c = 0;
            foreach (int i in M)
            {
                if (i < 0)
                {
                    c += 1;
                    sum += i;
                }
            }
            if (c == 0)
                return 0;
            return sum / c;
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rabota_Click(object sender, RoutedEventArgs e)
        {
            string text = InputTB.Text.Trim().Replace(".", ","); //нлиплилвжипж лилилщещпщ щбибин лимлкмкмеиь бинищнрщнрнилилпипещпщ 
            
                string[] t = text.Split();
                double[] M = new double[t.Length];
                if (InputTB.Text == "")
                {
                    throw new Exception("Вы не ввели массив");
                }
                int k = 0;
                foreach (string r in t)
                {
                    M[k] = Convert.ToInt32(r);
                    k += 1;
                }
                AVG[] avg = { chet,nechet,plus,minus };

                outputL.Content = avg [ChooseCB.SelectedIndex](M);
            
        }
    }			
}


