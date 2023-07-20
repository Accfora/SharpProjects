using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
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
using System.Windows.Shapes;

namespace Emelina_KS
{
    /// <summary>
    /// Логика взаимодействия для Absent.xaml
    /// </summary>
    public partial class Absent : Window
    {
        string connectionString;
        SqlConnection cnn;
        List<int> students = new List<int>();
        SqlCommand cmd;
        string gn;
        string date = DateTime.Today.ToString("yyyy-MM-dd");

        public Absent(string groupName)
        {
            InitializeComponent();

            gn = groupName;

            lh.Content += groupName + " на "+ DateTime.Today.ToShortDateString();

            connectionString = ConfigurationManager.ConnectionStrings["Emelina_KSEntities"].ConnectionString;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            cmd = cnn.CreateCommand();

            Filling();
        }
        void Filling()
        {
            cmd.CommandText = @"select Студенты.Код_студента, Фамилия_студента + ' ' + Имя_студента as Студент, 
(select case when Дата is NULL then 1 else 0 end) as Присутствует
from Студенты left join " +
$"(select * from Отсутствующие where Дата like '{date}') as Отсутствующие " +
$"on Студенты.Код_студента = Отсутствующие.Код_студента " +
$"where Группа like '{gn}'";

            SqlDataReader r = cmd.ExecuteReader();
            LW.Items.Clear();
            while (r.Read())
            {
                CheckBox c = new CheckBox();
                c.Width = LW.Width - 15;
                c.IsChecked = String.Format(r.GetValue(2).ToString()) == "1" ? true : false;
                students.Add(Convert.ToInt32(String.Format(r.GetValue(0).ToString())));
                c.Content = String.Format(r.GetValue(1).ToString());
                LW.Items.Add(c);
            }
            r.Close();
        }

        private void clo_Click(object sender, RoutedEventArgs e)
        {
            cmd.CommandText = $"delete Отсутствующие where Код_студента in (select Код_студента from Студенты where " +
                $"Группа like '{gn}') and Дата like '{date}'";
            cmd.ExecuteNonQuery();

            foreach (CheckBox checkBox in LW.Items)
                if (checkBox.IsChecked == false)
                {
                    cmd.CommandText = $"insert into Отсутствующие (Дата, Код_студента) values ('{date}'" +
                        $",{students.ElementAt(LW.Items.IndexOf(checkBox))})";
                    cmd.ExecuteNonQuery();
                }
            Close();
        }

        private void LW_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LW.SelectedIndex = -1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try {

            Microsoft.Win32.OpenFileDialog of = new Microsoft.Win32.OpenFileDialog();
            of.Filter = "Jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (of.ShowDialog() == true)
            {
                int Do(bool insert)
                {
                    StreamReader sr = new StreamReader(of.FileName);
                    Regex regex = new Regex(@"^\w+ \w+( \w+)?;[1-2] подгруппа(;отдежурено \d+ циклов)?$");
                    int added = 0;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (regex.IsMatch(line))
                        {
                            if (!insert)
                            {
                                added++;
                                continue;
                            }

                            string[] a = line.Split(';');
                            string[] b = a[0].Split(' ');

                            cmd.CommandText = $"insert into Студенты (Фамилия_студента, Имя_студента, Отчество_студента, Группа, Первая_подгруппа, Отдежурено_циклов) " +
$"values('{b[0]}','{b[1]}',{(b.Length == 3 ? "'" + b[2] + "'" : "NULL")},'{gn}',{(a[1].Substring(0, 1) == "1" ? 1 : 0)},{(a.Length == 3 ? a[2].Substring(11, a[2].LastIndexOf(' ') - 11) : "0")})";
                            cmd.ExecuteNonQuery();
                            added++;
                        }
                    }
                    return added;
                }

                int done = Do(false);
                if (done == 0)
                    MessageBox.Show("Перезапись совершена не будет, так как студентов в файле не найдено", "Чем ужасней убийца, тем безобиднее у него вид");
                else
                    if (MessageBox.Show($"Перезаписать список группы {gn} на {done} найденных студенов из файла?", "Семь раз отмерь один раз отрежь", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    cmd.CommandText = $"delete Отсутствующие where код_студента in (select код_студента from Студенты where Группа like '{gn}')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"delete Дежурство where Группа like '{gn}'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"delete Студенты where Группа like '{gn}'";
                    cmd.ExecuteNonQuery();

                    Do(true);
                }
                Filling();
            }

            } catch { MessageBox.Show("Кажется, проблемы со считыванием файла", "От малой ошибки большая беда"); }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                clo_Click(null, null);
        }
    }
}