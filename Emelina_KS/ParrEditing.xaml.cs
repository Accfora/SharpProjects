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

namespace Emelina_KS
{
    /// <summary>
    /// Логика взаимодействия для ParrEditing.xaml
    /// </summary>
    public partial class ParrEditing : Window
    {
        public ParrEditing()
        {
            try
            {
                InitializeComponent();
                ReloadAndItemSource();
            }
            catch { MessageBox.Show("Кажется, что-то не с подключением", "Кайся, да вперед не ошибайся"); Close(); }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditOneParr ab = new EditOneParr((sender as Button).DataContext as Пары);
            ab.Owner = this;
            ab.ShowDialog();
            ReloadAndItemSource();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditOneParr ab = new EditOneParr(null);
            ab.Owner = this;
            ab.ShowDialog();
            ReloadAndItemSource();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = dg.SelectedItems.Cast<Пары>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {hotelsForRemoving.Count()} пар из расписания?", "Временем кто дорожит, тот зря в постели не лежит",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    Emelina_KSEntities.GetContext().Пары.RemoveRange(hotelsForRemoving);
                    Emelina_KSEntities.GetContext().SaveChanges();

                    ReloadAndItemSource();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        void ReloadAndItemSource()
        {
            Emelina_KSEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dg.ItemsSource = Emelina_KSEntities.GetContext().Пары.OrderBy(x => x.День_недели).ThenBy(x => x.Код_преподавателя).ThenBy(x => x.Номер_пары).ToList();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ok_Click(null, null);
        }
    }
}