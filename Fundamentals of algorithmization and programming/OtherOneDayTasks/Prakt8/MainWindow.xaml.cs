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
using UniversityLibrary;

namespace Prakt8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<University> lstUn = new List<University>();
        List<string> lstSkills = new List<string>();
        Button[] bM;
        Button ok;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cbOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbOption.SelectedIndex)
            {
                case 0:
                    a.Fill = Brushes.LightBlue;
                    break;
                case 1:
                    a.Fill = Brushes.ForestGreen;
                    break;
                case 2:
                    a.Fill = Brushes.DeepPink;
                    break;
            }
        }
        private void ButtonSave1_Click(object sender, RoutedEventArgs e)
        {
            int o = 0;
            TbName1.Text = TbName1.Text.Trim(); TbSkill1.Text = TbSkill1.Text.Trim();
            TbLevel1.Text = TbLevel1.Text.Trim(); TbCoursePrice1.Text = TbCoursePrice1.Text.Trim();
            try
            {
                if (TbName1.Text == "")
                {
                    MessageBox.Show("Поле названия университета не заполнено!");
                    int feh = 1 / o;
                }
                if (TbSkill1.Text == "")
                {
                    MessageBox.Show("Поле названия навыка не заполнено!");
                    int feh = 1 / o;
                }
                if (Convert.ToInt32(TbCoursePrice1.Text) < 15)
                {
                    MessageBox.Show("Стоимость курса не может быть меньше 15!");
                    int feh = 1 / o;
                }
                if (Convert.ToInt32(TbLevel1.Text) < 1 || Convert.ToInt32(TbLevel1.Text) > 5)
                {
                    MessageBox.Show("Уровень университета должен быть в диапазоне от 1  до 5!");
                    int feh = 1 / o;
                }

                switch (cbOption.SelectedIndex)
                {
                    case 0:
                        University university = new University();
                        university.Skill = TbSkill1.Text;
                        university.Price = Convert.ToDouble(TbCoursePrice1.Text);
                        university.Name = TbName1.Text;
                        university.Level = Convert.ToInt32(TbLevel1.Text);
                        lstUn.Add(university);
                        break;
                    case 1:
                        Military military = new Military();
                        military.Skill = TbSkill1.Text;
                        military.Price = Convert.ToDouble(TbCoursePrice1.Text);
                        military.Name = TbName1.Text;
                        military.Level = Convert.ToInt32(TbLevel1.Text);
                        lstUn.Add(military);
                        break;
                    case 2:
                        Magic magic = new Magic();
                        magic.Skill = TbSkill1.Text;
                        magic.Price = Convert.ToDouble(TbCoursePrice1.Text);
                        magic.Name = TbName1.Text;
                        magic.Level = Convert.ToInt32(TbLevel1.Text);
                        lstUn.Add(magic);
                        break;
                }
                if (lstSkills.IndexOf(TbSkill1.Text) == -1) lstSkills.Add(TbSkill1.Text);
                cbOption.SelectedIndex = 0;
                TbCoursePrice1.Text = ""; TbLevel1.Text = ""; TbName1.Text = ""; TbSkill1.Text = "";
                ButtonComplete.IsEnabled = true;
            }
            catch (DivideByZeroException) { }
            catch
            {
                MessageBox.Show("Формат данных некорректен!");
            }
        }

        private void ButtonComplete_Click(object sender, RoutedEventArgs e)
        {
            ga.Children.Clear();
            Label titl = new Label();
            titl.Height = 25;
            titl.Content = "Выберите необходимые навыки для осуществления поиска:";
            ga.Children.Add(titl);
            titl.VerticalAlignment = VerticalAlignment.Top;
            titl.HorizontalAlignment = HorizontalAlignment.Left;
            titl.Margin = new Thickness(10, 10, 0, 0);
            bM = new Button[lstSkills.Count];
            for (int i = 0; i < lstSkills.Count; i++)
            {
                bM[i] = new Button();
                bM[i].Width = 120;
                bM[i].Height = 22;
                bM[i].Content = lstSkills[i];
                bM[i].Background = Brushes.LightGray;
                ga.Children.Add(bM[i]);
                bM[i].VerticalAlignment = VerticalAlignment.Top;
                bM[i].HorizontalAlignment = HorizontalAlignment.Left;
                Thickness th = new Thickness(10, 43 + 30 * i, 0, 0);
                bM[i].Margin = th;
                bM[i].Click += Green;
            }
            ok = new Button(); ok.Width = 120; ok.Height = 22;
            ok.VerticalAlignment = VerticalAlignment.Top;
            ok.HorizontalAlignment = HorizontalAlignment.Left;
            ok.Margin = new Thickness(164, 313, 0, 0); ok.Background = Brushes.LightGray;
            ok.IsEnabled = false; ok.Click += ok_Click; ok.Content = "Готово";
            ga.Children.Add(ok); 
        }
        private void Green(object sender, RoutedEventArgs e)
        {
            ok.IsEnabled = false;
            if (((Button)sender).Background == Brushes.LightGray)
            ((Button)sender).Background = Brushes.LightGreen;
            else ((Button)sender).Background = Brushes.LightGray;
            foreach (Button b in bM)
            {
                if (b.Background == Brushes.LightGreen)
                {
                    ok.IsEnabled = true; break;
                }
            }
        }
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button b in bM)
            {
                if (b.Background == Brushes.LightGray)
                {
                    lstSkills.Remove("" + b.Content);
                }
            }
            ga.Children.Clear();
            Label titl = new Label();
            titl.Height = 25;
            titl.Content = "Результат:";
            ga.Children.Add(titl);
            titl.VerticalAlignment = VerticalAlignment.Top;
            titl.HorizontalAlignment = HorizontalAlignment.Left;
            titl.Margin = new Thickness(10, 10, 0, 0);
            Label itog = new Label();
            itog.VerticalAlignment = VerticalAlignment.Top;
            itog.HorizontalAlignment = HorizontalAlignment.Left;
            itog.Margin = new Thickness(10, 43, 0, 0);
            ga.Children.Add(itog);
            foreach (string skill in lstSkills)
            {
                University fit = lstUn[0];
                foreach (University university in lstUn)
                {
                    if ((university.Skill == skill && fit.Skill != skill)||(university.Skill == skill && (university.Level > fit.Level || (university.Level == fit.Level && university.Price < fit.Price))))
                        fit = university;
                }
                itog.Content += "По навыку " + skill + " подойдёт " + fit.Info()+"\n";
            }
            Button renew = new Button();
            renew.Width = 120;
            renew.Height = 25;
            renew.Content = "Заново!";
            ga.Children.Add(renew);
            renew.VerticalAlignment = VerticalAlignment.Bottom;
            renew.HorizontalAlignment = HorizontalAlignment.Right;
            renew.Margin = new Thickness(0,0,10,10);
            renew.Click += Renew;
            Button closer = new Button();
            closer.Width = 120;
            closer.Height = 25;
            closer.Content = "Закрыть!";
            ga.Children.Add(closer);
            closer.VerticalAlignment = VerticalAlignment.Bottom;
            closer.HorizontalAlignment = HorizontalAlignment.Left;
            closer.Margin = new Thickness(10, 0, 0, 10);
            closer.Click += Closer;
        }
        private void Renew(object sender, RoutedEventArgs e)
        {
            ga.Children.Clear(); lstSkills.Clear(); lstUn.Clear();
            ga.Children.Add(begin); ButtonComplete.IsEnabled = false;
        }
        private void Closer(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
