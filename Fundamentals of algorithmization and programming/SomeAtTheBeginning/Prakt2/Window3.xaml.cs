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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void ukbback_Click(object sender, RoutedEventArgs e)
        {
            MainWindow uk1 = new MainWindow();
            uk1.Show();
            Close();
        }

        private void ukb1_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            ukb1.Margin = new Thickness(r.Next(600), r.Next(350), 0, 0);
        }
    }
}
