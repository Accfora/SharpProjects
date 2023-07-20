using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace Emelina_KS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlConnection cnn;
        SqlCommand cmd;
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                connectionString = ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                cmd = cnn.CreateCommand();

                cmd.CommandText = @"select distinct Номер_группы
from Группы order by Номер_группы";

                SqlDataReader r = cmd.ExecuteReader();
                groups.Items.Clear();
                while (r.Read())
                    groups.Items.Add(new TextBlock().Text = String.Format(r.GetValue(0).ToString()));
                r.Close();
            }
            catch { MessageBox.Show("Что-то пошло не так с подключением базы данных","От малой ошибки большая беда"); }
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            cmd.CommandText = $@"select Пароль from Группы where Номер_группы = '{groups.SelectedItem}'";

            if (cmd.ExecuteScalar().ToString() == password.Password)
            {
                DutyWindow dutyWindow = new DutyWindow(groups.SelectedItem.ToString());
                dutyWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль", "Без труда не выловишь и рыбку из пруда");
                password.Clear();
            }
        }

        private void groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            enter.IsEnabled = true;
            password.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                enter_Click(null, null);
        }
    }
}
