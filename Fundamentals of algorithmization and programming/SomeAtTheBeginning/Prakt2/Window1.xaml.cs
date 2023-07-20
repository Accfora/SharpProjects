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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void kdnibback_Click(object sender, RoutedEventArgs e)
        {
            MainWindow kdni1 = new MainWindow();
            kdni1.Show();
            Close();
        }

        private void kdnib1_Click(object sender, RoutedEventArgs e)
        {
            kdnit1.Text = "Ну и что я говорил?!";
            kdnib1.Opacity = 0;
            kdnib1.IsEnabled = false;
            kdnib1.Content = "";
        }
    }
}
