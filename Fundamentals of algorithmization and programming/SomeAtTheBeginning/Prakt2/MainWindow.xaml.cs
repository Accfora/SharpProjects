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

namespace aaa
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

        private void b1pj_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.Show();
            Close();
        }

        private void bpj2_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.Show();
            Close();
        }

        private void bpj3_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            w3.Show();
            Close();
        }
    }
}
