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
using System.Windows.Shapes;

namespace Emelina_KS
{
    /// <summary>
    /// Логика взаимодействия для DutyWindow.xaml
    /// </summary>
    public partial class DutyWindow : Window
    {
        string headed = "Необходимо\nдежурство\nна ";
        string connectionString;
        SqlConnection cnn;
        string date = DateTime.Today.ToString("yyyy-MM-dd");
        string day;
        List<int> dutyPair = new List<int>();
        List<int> prepods = new List<int>();
        SqlCommand cmd;
        string selectedGroup = "";                                                       
        public DutyWindow(string gruppa)
        {
            InitializeComponent();

            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                cmd = cnn.CreateCommand();
            }
            catch { MessageBox.Show("Кажется, проблемы с подключением", "Кайся, да вперед не ошибайся"); Close(); }

            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    day = "Понедельник";
                    break;
                case DayOfWeek.Tuesday:
                    day = "Вторник";
                    break;
                case DayOfWeek.Wednesday:
                    day = "Среда";
                    break;
                case DayOfWeek.Thursday:
                    day = "Четверг";
                    break;
                case DayOfWeek.Friday:
                    day = "Пятница";
                    break;
                default:
                    day = "";
                    break;
            }

            if (gruppa == "Админ")
            {
                groupHead.Content += "ы";
                this.Title = "Администратор";
            }
            else
            {
                cb.Visibility = Visibility.Hidden;
                editParrs.Visibility = Visibility.Hidden;
                absent.IsEnabled = true;
                groupHead.Content += $"а {gruppa}";
                this.Title = gruppa;
                selectedGroup = gruppa;
                lbFill();
            }

            head.Content = headed + DateTime.Today.ToShortDateString();

            if (gruppa=="Админ")
                beginLoaded();
        }
        void beginLoaded()
        {
            cb.SelectedIndex = -1;
            absent.IsEnabled = false;

            cmd.CommandText = @"select distinct Группа
from
(
    select День_недели, Преподаватели.Код_преподавателя as Код, max(Номер_пары) as Последняя_пара

    from Преподаватели inner join Пары on Преподаватели.Код_преподавателя = Пары.Код_преподавателя

    group by День_недели, Преподаватели.Код_преподавателя
)
as t inner join Пары
    on t.День_недели = Пары.День_недели and t.Последняя_пара = Пары.Номер_пары and t.Код = Пары.Код_преподавателя " +
$"where t.День_недели like '{day}' order by Группа";

            SqlDataReader r = cmd.ExecuteReader();
            cb.Items.Clear();
            while (r.Read())
                cb.Items.Add(new TextBlock().Text = String.Format(r.GetValue(0).ToString()));
            r.Close();
        }

        private void absent_Click(object sender, RoutedEventArgs e)
        {
            Absent ab = new Absent("" + selectedGroup);
            ab.Owner = this;
            ab.ShowDialog();

            SelectCheck();
        }

        void AbsentDutyCheck()
        {
            if (dutyPair.Count() != 2) return;

            cmd.CommandText = $"select * from " +
                                $"(select Код_студента from Отсутствующие where Дата like '{date}') as Отсутствующие " +
                                $"where Код_студента in ({dutyPair.ElementAt(0)},{dutyPair.ElementAt(1)})";

            SqlCommand countsql = cnn.CreateCommand();
            countsql.CommandText = $"select count (*) from ({cmd.CommandText}) as z";

            switch (countsql.ExecuteScalar())
            {
                case 1:
                    if (dutyPair.ElementAt(0) == Convert.ToInt32(cmd.ExecuteScalar()))
                        RedAndVisible(true, false);
                    else
                        RedAndVisible(false, true);
                    break;
                case 2:
                    RedAndVisible(true, true);
                    break;
                default:
                    RedAndVisible(false, false);
                    break;
            }
        }
        void RedAndVisible(bool firstIntoRV, bool secondIntoRV)
        {
            duty1.Background = firstIntoRV ? Brushes.Red : Brushes.White;
            duty2.Background = secondIntoRV ? Brushes.Red : Brushes.White;
            ch1.Visibility = firstIntoRV ? Visibility.Visible : Visibility.Hidden;
            ch2.Visibility = secondIntoRV ? Visibility.Visible : Visibility.Hidden;
        }
        bool SelectCheck()
        {
            bool withPrepod = lb.SelectedIndex != -1;

            SqlCommand sql = cnn.CreateCommand();
            sql.CommandText = $"select count(*) " +
                                $"from Студенты where Группа like '{selectedGroup}' and Код_студента " +
                                $"not in (select Код_студента from Отсутствующие where Дата like '{date}')" + (withPrepod ?
                $"and(not exists(select Код_преподавателя from Подгруппы where Код_преподавателя = {lb.SelectedItem.ToString().Substring(0, lb.SelectedItem.ToString().IndexOf('.'))})" +
                $"or(select Первая_подгруппа from Подгруппы where Код_преподавателя = {lb.SelectedItem.ToString().Substring(0, lb.SelectedItem.ToString().IndexOf('.'))}) = Студенты.Первая_подгруппа)" : "");

            if ((int)sql.ExecuteScalar() > 1)
            {
                AbsentDutyCheck();
                wenig.Visibility = Visibility.Hidden;

                return true;
            }
            else
            {
                DutiesClear();

                cmd.CommandText = $"delete Дежурство " +
                                    $"where Дата like '{date}' and Группа like '{selectedGroup}' " + (withPrepod ?
                                    $"and Код_преподавателя = {lb.SelectedItem.ToString().Substring(0, lb.SelectedItem.ToString().IndexOf('.'))}" : "");
                cmd.ExecuteNonQuery();

                lb.SelectedIndex = -1;
                wenig.Visibility = Visibility.Visible;
                return false;
            }
        }
        private void DutyChange(object sender, RoutedEventArgs e)
        {
            if ((Button)sender == ch1)
            {
                duty1.Background = Brushes.White;
                DutyChangeNumberAt(0);
            }
            else
            {
                duty2.Background = Brushes.White;
                DutyChangeNumberAt(1);
            }
            ((Button)sender).Visibility = Visibility.Hidden;
        }
        void DutyChangeNumberAt(int number)
        {
            if (number != 0 && number != 1) return;

            UpdateStudent(dutyPair.ElementAt(number), -1);

            cmd.CommandText = @"select top 1 Код_студента
                                from Студенты " +
        $"where Группа like '{selectedGroup}' " +
        $"and (not exists (select Код_преподавателя from Подгруппы where Код_преподавателя " +
        $"= {lb.SelectedItem.ToString().Substring(0, lb.SelectedItem.ToString().IndexOf('.'))}) or (select Первая_подгруппа from Подгруппы " +
        $"where Код_преподавателя = {lb.SelectedItem.ToString().Substring(0, lb.SelectedItem.ToString().IndexOf('.'))}) = Студенты.Первая_подгруппа) " +
        $"and Код_студента not in (select Код_студента from Отсутствующие where Дата like '{date}') " +
        $"and Код_студента not in ({dutyPair[0]},{dutyPair[1]}) " +
        "order by Отдежурено_циклов";
            dutyPair[number] = (int)cmd.ExecuteScalar();

            cmd.CommandText = @"select Фамилия_студента + ' ' + Имя_студента
                                from Студенты
                                where Код_студента = " + dutyPair.ElementAt(number);

            if (number == 0)
                duty1.Text = cmd.ExecuteScalar().ToString();
            else
                duty2.Text = cmd.ExecuteScalar().ToString();

            UpdateStudent(dutyPair.ElementAt(number), 1);

            cmd.CommandText = $"update Дежурство " +
                                $"set {(number == 0 ? "Код_дежурного1" : "Код_дежурного2")} = {dutyPair.ElementAt(number)} " +
                                $"where Код_преподавателя = {lb.SelectedItem.ToString().Substring(0, lb.SelectedItem.ToString().IndexOf('.'))} and Дата like '{date}' and Группа like '{selectedGroup}'";
            cmd.ExecuteNonQuery();
        }
        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DutiesClear();
            prepods.Clear();
            lb.SelectedIndex = -1;
            selectedGroup = "";
            lb.Items.Clear();

            if (cb.SelectedIndex == -1) return;

            selectedGroup = cb.SelectedValue.ToString();
            absent.IsEnabled = true;
            SelectCheck();

            lbFill();
        }
        void lbFill()
        {
            cmd.CommandText = $@"select Код, Фамилия_преподавателя, Пара from
        (
        	select Код, Последняя_пара as Пара from
        	(
        		select День_недели, Преподаватели.Код_преподавателя as Код, max(Номер_пары) as Последняя_пара
        		from Преподаватели inner join Пары on Преподаватели.Код_преподавателя = Пары.Код_преподавателя
        		group by День_недели, Преподаватели.Код_преподавателя
        	)
        	as t inner join Пары 
        		on t.День_недели = Пары.День_недели and t.Последняя_пара = Пары.Номер_пары and t.Код = Пары.Код_преподавателя
        	where t.День_недели like '{day}' and Группа like '{selectedGroup}'
        )
        as t2 inner join Преподаватели on t2.Код = Преподаватели.Код_преподавателя order by Пара";

            SqlDataReader r = cmd.ExecuteReader();
            lb.Items.Clear();
            while (r.Read())
            {
                prepods.Add(Convert.ToInt32(String.Format("{0}", r.GetValue(0).ToString())));
                lb.Items.Add(String.Format("{2}. {0} ({1} пара)", r.GetValue(1).ToString(), r.GetValue(2), r.GetValue(0)));
            }
            r.Close();
        }

        void DutiesClear()
        {
            duty1.Text = ""; duty2.Text = "";
            setDuty.IsEnabled = false;
            dutyPair.Clear();
            RedAndVisible(false, false);
        }
        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb.SelectedIndex == -1 || !SelectCheck()) return;

            DutiesClear();

            cmd.CommandText = @"select 
(select Фамилия_студента + ' ' + Имя_студента from Студенты where Код_дежурного1 = Код_студента) as Дежурный1,
(select Фамилия_студента + ' ' + Имя_студента from Студенты where Код_дежурного2 = Код_студента) as Дежурный2,
Код_дежурного1, Код_дежурного2 from Дежурство " +
$"where Код_преподавателя = {lb.SelectedItem.ToString().Substring(0, lb.SelectedItem.ToString().IndexOf('.'))} and Дата like '{date}'" +
$" and Группа like '{selectedGroup}'";

            if (cmd.ExecuteScalar() != null)
            {
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    dutyPair.Add(Convert.ToInt32(String.Format(r.GetValue(2).ToString())));
                    dutyPair.Add(Convert.ToInt32(String.Format(r.GetValue(3).ToString())));
                    duty1.Text = String.Format(r.GetValue(0).ToString());
                    duty2.Text = String.Format(r.GetValue(1).ToString());
                }
                r.Close();
                AbsentDutyCheck();
            }
            else
                setDuty.IsEnabled = true;
        }
        void UpdateStudent(int studentCode, int cycle)
        {
            cmd.CommandText = $"update Студенты " +
                                $"set Отдежурено_циклов += {cycle}" +
                                $"where Код_студента = {studentCode}";
            cmd.ExecuteNonQuery();
        }

        private void setDuty_Click(object sender, RoutedEventArgs e)
        {
            cmd.CommandText = @"select top 2 Код_студента
                                from Студенты " +
                                $"where Группа like '{selectedGroup}' and (not exists (select Код_преподавателя from Подгруппы where Код_преподавателя " +
                                $"= {lb.SelectedItem.ToString().Substring(0, lb.SelectedItem.ToString().IndexOf('.'))}) or (select Первая_подгруппа from Подгруппы " +
                                $"where Код_преподавателя = {lb.SelectedItem.ToString().Substring(0, lb.SelectedItem.ToString().IndexOf('.'))}) = Студенты.Первая_подгруппа) " +
                                $"and Код_студента not in (select Код_студента from Отсутствующие where Дата like '{date}')" +
                                "order by Отдежурено_циклов";
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
                dutyPair.Add(Convert.ToInt32(String.Format(r.GetValue(0).ToString())));
            r.Close();

            cmd.CommandText = @"select Фамилия_студента + ' ' + Имя_студента
                                from Студенты
                                where Код_студента = " + dutyPair.ElementAt(0);
            duty1.Text = cmd.ExecuteScalar().ToString();
            cmd.CommandText = @"select Фамилия_студента + ' ' + Имя_студента
                                from Студенты
                                where Код_студента = " + dutyPair.ElementAt(1);
            duty2.Text = cmd.ExecuteScalar().ToString();

            AbsentDutyCheck();

            UpdateStudent(dutyPair.ElementAt(0), 1);
            UpdateStudent(dutyPair.ElementAt(1), 1);

            cmd.CommandText = @"insert into Дежурство (Код_преподавателя, Дата, Группа, Код_дежурного1, Код_дежурного2) " +
                                $"values({lb.SelectedItem.ToString().Substring(0, lb.SelectedItem.ToString().IndexOf('.'))}, '{date}', '{selectedGroup}'," +
                                $"{dutyPair.ElementAt(0)}, {dutyPair.ElementAt(1)})";
            cmd.ExecuteNonQuery();

            setDuty.IsEnabled = false;
        }

        private void editParrs_Click(object sender, RoutedEventArgs e)
        {
            ParrEditing ab = new ParrEditing();
            ab.Owner = this;
            ab.ShowDialog();
            beginLoaded();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
    }
}
