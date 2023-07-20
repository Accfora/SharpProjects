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
using System.Windows.Shapes;

namespace aaa
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void sbback_Click(object sender, RoutedEventArgs e)
        {
            MainWindow s1 = new MainWindow();
            s1.Show();
            Close();
        }

        private void sb1_Click(object sender, RoutedEventArgs e)
        {
            se1.Fill = Brushes.Red;
            se2.Fill = Brushes.White;
            se3.Fill = Brushes.White;
        }

        private void sb2_Click(object sender, RoutedEventArgs e)
        {
            se1.Fill = Brushes.White;
            se2.Fill = Brushes.Yellow;
            se3.Fill = Brushes.White;
        }

        private void sb3_Click(object sender, RoutedEventArgs e)
        {
            se1.Fill = Brushes.White;
            se2.Fill = Brushes.White;
            se3.Fill = Brushes.Green;
        }
    }
}
