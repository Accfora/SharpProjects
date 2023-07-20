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
    /// Логика взаимодействия для EditOneParr.xaml
    /// </summary>
    public partial class EditOneParr : Window
    {
        private Пары _currentParr = new Пары();
        string connectionString;
        SqlConnection cnn;
        SqlCommand cmd;
        public EditOneParr(Пары parr)
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString;
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            if (parr != null)
                _currentParr = parr;

            DataContext = _currentParr;

            cbPrepods.ItemsSource = Emelina_KSEntities.GetContext().Преподаватели/*.Select(p=>p.Фамилия_преподавателя)*/.ToList();
            cbDays.ItemsSource = new List<string> { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница" };
            cbNumberParr.ItemsSource = new List<int> { 1, 2, 3, 4, 5 };
            cbGropus.ItemsSource = Emelina_KSEntities.GetContext().Группы.Where(w => w.Номер_группы != "Админ").Select(p => p.Номер_группы).ToList();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            foreach (FrameworkElement cb in g.Children)
                if (cb is ComboBox && ((ComboBox)cb).SelectedIndex == -1)
                {
                    MessageBox.Show("Остались незаполненные поля!", "Любишь кататься - люби и саночки возить");
                    return;
                }

            cmd = cnn.CreateCommand();

            var w = Emelina_KSEntities.GetContext().Пары
                .Where(y => y.День_недели == _currentParr.День_недели && y.Номер_пары == _currentParr.Номер_пары &&
                y.Код_преподавателя == _currentParr.Преподаватели.Код_преподавателя).Select(q => q);

            if (w.Count() > 0 && w.FirstOrDefault() != _currentParr && MessageBox.Show($"Вы уверены, что хотите поставить преподавателю ещё одну группу?\n" +
                $"Преподаватель {_currentParr.Преподаватели.Фамилия_преподавателя} на {_currentParr.Номер_пары} паре ({_currentParr.День_недели.ToLower()}) уже занят",
                $"Для хорошего кота и в феврале март",
                MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;

            cmd.CommandText = $@"select case when Первая_подгруппа is null then 7 else Первая_подгруппа end as v 
from Пары a left join Подгруппы b on a.Код_преподавателя = b.Код_преподавателя
where День_недели like '{_currentParr.День_недели}' 
and Номер_пары = {_currentParr.Номер_пары} and Группа like '{_currentParr.Группа}'";

            var z = Emelina_KSEntities.GetContext().Пары
    .Where(y => y.День_недели == _currentParr.День_недели && y.Номер_пары == _currentParr.Номер_пары &&
    y.Группа == _currentParr.Группа).Select(q => q);

            void Message()
            {
                MessageBox.Show($"{_currentParr.Номер_пары} пара ({_currentParr.День_недели.ToLower()}) занята у группы {_currentParr.Группа}",
                    "Не ошибается тот, кто ничего не делает");
            }

            if (z.Count() == 0) { }
            else if (z.Count() > 1)
            {
                Message();
                return;
            }
            else if (z.FirstOrDefault() == _currentParr) { }
            else if ((int?)cmd.ExecuteScalar() == 7)
            {
                Message();
                return;
            }
            else
            {
                SqlCommand sql = cnn.CreateCommand();
                sql.CommandText = $"select case первая_подгруппа when 0 then 0 when 1 then 1 else Первая_подгруппа end from Подгруппы where код_преподавателя = {_currentParr.Преподаватели.Код_преподавателя}";

                if ((int?)sql.ExecuteScalar() is null || (int)cmd.ExecuteScalar() == (int?)sql.ExecuteScalar())
                {
                    Message();
                    return;
                }
            }

            try
            {
                if (_currentParr.Id == 0)
                    Emelina_KSEntities.GetContext().Пары.Add(_currentParr);

                Emelina_KSEntities.GetContext().SaveChanges();
            }
            catch
            {
                MessageBox.Show("Невозможно добавить запись", "За прощенную вину и Бог не мучит");
                Emelina_KSEntities.GetContext().Пары.Remove(_currentParr);
                return;
            }

            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ok_Click(null, null);
        }
    }
}
