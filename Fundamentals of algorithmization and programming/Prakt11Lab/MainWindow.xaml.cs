using System;
using System.Collections.Generic;
using System.IO;
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

namespace Prakt11Lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Pathing = @"";
        public bool first_or = true;
        public string for_tb1 = "";
        public ComboBox cb; 
        public Button ReadOpi;
        Label mainL;
        public MainWindow()
        {
            InitializeComponent();
            Directory.Delete(@"C:\Users\borod\OneDrive\Рабочий стол\Dust_21-22\Основы алгоритмизации и программирования\Labs\Prakt11Lab\For11_Описания_Университетов",true);
            Directory.CreateDirectory(@"C:\Users\borod\OneDrive\Рабочий стол\Dust_21-22\Основы алгоритмизации и программирования\Labs\Prakt11Lab\For11_Описания_Университетов");
        }
        List<University> lstUn = new List<University>();
        //List<string> lstSkills = new List<string>();
        //Button[] bM;
        //Button ok;
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
                    MessageBox.Show("Поле названия университета не заполнено!","Погодите-ка..");
                    int feh = 1 / o;
                }
                foreach (University u in lstUn)
                    if (u.Name == TbName1.Text)
                    {
                        MessageBox.Show("Университет с таким названием уже существует!", "Погодите-ка..");
                        int feh = 1 / o;
                    }
                if (TbSkill1.Text == "")
                {
                    MessageBox.Show("Поле названия навыка не заполнено!", "Погодите-ка..");
                    int feh = 1 / o;
                }
                if (Convert.ToInt32(TbCoursePrice1.Text) < 1)
                {
                    MessageBox.Show("Стоимость курса не может быть меньше 1!", "Погодите-ка..");
                    int feh = 1 / o;
                }
                if (Convert.ToInt32(TbLevel1.Text) < 0)
                {
                    MessageBox.Show("Текущее кол-во денег университета не может быть меньше 0!", "Погодите-ка..");
                    int feh = 1 / o;
                }
                if (first_or)
                {
                    MessageBox.Show("Необходимо осуществить описание!", "Погодите-ка..");
                    int feh = 1 / o;
                }
                switch (cbOption.SelectedIndex)
                {
                    case 0:
                        University university = new University();
                        university.Skill = TbSkill1.Text;
                        university.Price = Convert.ToDouble(TbCoursePrice1.Text);
                        university.Name = TbName1.Text;
                        university.Money = Convert.ToDouble(TbLevel1.Text);
                        university.Link = Pathing;
                        lstUn.Add(university);
                        break;
                    case 1:
                        Military military = new Military();
                        military.Skill = TbSkill1.Text;
                        military.Price = Convert.ToDouble(TbCoursePrice1.Text);
                        military.Name = TbName1.Text;
                        military.Money = Convert.ToDouble(TbLevel1.Text);
                        military.Link = Pathing;
                        lstUn.Add(military);
                        break;
                    case 2:
                        Magic magic = new Magic();
                        magic.Skill = TbSkill1.Text;
                        magic.Price = Convert.ToDouble(TbCoursePrice1.Text);
                        magic.Name = TbName1.Text;
                        magic.Money = Convert.ToDouble(TbLevel1.Text);
                        magic.Link = Pathing;
                        lstUn.Add(magic);
                        break;
                }
                //if (lstSkills.IndexOf(TbSkill1.Text) == -1) lstSkills.Add(TbSkill1.Text);
                cbOption.SelectedIndex = 0;
                TbCoursePrice1.Text = ""; TbLevel1.Text = ""; TbName1.Text = ""; TbSkill1.Text = "";
                ToOpisanie.Content = "Записать"; ToOpisanie.Background = Brushes.White;
                first_or = true; Pathing = @""; for_tb1 = "";
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
            ga.Background = Brushes.WhiteSmoke;
            ga.Children.Clear();
            begin.Children.Remove(ymgn);
            //Rectangle rr = new Rectangle();
            //rr.VerticalAlignment = VerticalAlignment.Top;
            //rr.HorizontalAlignment = HorizontalAlignment.Left;
            //rr.Width = 299; rr.Height = 297;
            //rr.Stroke = Brushes.Black;
            //rr.Margin = new Thickness(0, 34, 0, 0);
            //ga.Children.Add(rr);
            cb = new ComboBox();
            cb.Width = 120; cb.Height = 23;
            //cb.Content = "Выберите необходимые навыки для осуществления поиска:";
            ga.Children.Add(cb);
            cb.VerticalAlignment = VerticalAlignment.Top;
            cb.HorizontalAlignment = HorizontalAlignment.Left;
            cb.Margin = new Thickness(167, 92, 0, 0);
            cb.SelectionChanged += CbLstUn;
            //cb.IsEditable = true;
            foreach (University u in lstUn)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = u.Name;
                cb.Items.Add(textBlock);
            }
            ReadOpi = new Button(); Button clo = new Button();
            ReadOpi.VerticalAlignment = VerticalAlignment.Top; clo.VerticalAlignment = VerticalAlignment.Bottom;
            ReadOpi.HorizontalAlignment = HorizontalAlignment.Left; clo.HorizontalAlignment = HorizontalAlignment.Right;
            ReadOpi.Margin = new Thickness(167, 291, 0, 0); clo.Margin = new Thickness(0,0,10,10);
            ReadOpi.Click += ToOpisanie_Click; clo.Click += Clo;
            ReadOpi.Content = "Просмотреть"; clo.Content = "Закрыть";
            ReadOpi.Width = 120; ReadOpi.Height = 23; clo.Width = 120; clo.Height = 22;
            ReadOpi.IsEnabled = false;
            mainL = new Label(); Label pr = new Label();
            mainL.VerticalAlignment = VerticalAlignment.Top; pr.VerticalAlignment = VerticalAlignment.Top;
            mainL.HorizontalAlignment = HorizontalAlignment.Left; pr.HorizontalAlignment = HorizontalAlignment.Left;
            mainL.Margin = new Thickness(19, 47, 0, 0); pr.Margin = new Thickness(19, 3, 0, 0);
            pr.Content = "Просмотр списка университетов"; pr.FontWeight = FontWeights.Bold;
            a.Fill = Brushes.WhiteSmoke;
            uhuhi.Text = "Выберите университет:";
            ga.Children.Add(begin); 
            begin.Children.Remove(cbOption); begin.Children.Remove(ButtonComplete); ga.Children.Add(clo);
            ga.Children.Remove(cb); begin.Children.Add(cb); begin.Children.Add(ReadOpi); begin.Children.Add(mainL); begin.Children.Add(pr);
            begin.Children.Remove(ButtonSave1); begin.Children.Remove(ToOpisanie); begin.Children.Remove(TbName1);
            TbCoursePrice1.IsEnabled = false; TbLevel1.IsEnabled = false; TbSkill1.IsEnabled = false;
            //    bM = new Button[lstSkills.Count];
            //    for (int i = 0; i < lstSkills.Count; i++)
            //    {
            //        bM[i] = new Button();
            //        bM[i].Width = 120;
            //        bM[i].Height = 22;
            //        bM[i].Content = lstSkills[i];
            //        bM[i].Background = Brushes.LightGray;
            //        ga.Children.Add(bM[i]);
            //        bM[i].VerticalAlignment = VerticalAlignment.Top;
            //        bM[i].HorizontalAlignment = HorizontalAlignment.Left;
            //        Thickness th = new Thickness(10, 43 + 30 * i, 0, 0);
            //        bM[i].Margin = th;
            //        //bM[i].Click += Green;
            //    }
            //    ok = new Button(); ok.Width = 120; ok.Height = 22;
            //    ok.VerticalAlignment = VerticalAlignment.Top;
            //    ok.HorizontalAlignment = HorizontalAlignment.Left;
            //    ok.Margin = new Thickness(164, 313, 0, 0); ok.Background = Brushes.LightGray;
            //    //ok.IsEnabled = false; ok.Click += ok_Click; ok.Content = "Готово";
            //    ga.Children.Add(ok);
        }
        private void Clo(object sender, RoutedEventArgs e) { Close(); }
        private void CbLstUn(object sender, SelectionChangedEventArgs e)
        {
            if (!ReadOpi.IsEnabled) ReadOpi.IsEnabled = true;
            if (uhuhi.Text == "Выберите университет:") uhuhi.Text = "Название университета";
            TbCoursePrice1.Text = ""+lstUn[cb.SelectedIndex].Price;
            TbLevel1.Text = "" + lstUn[cb.SelectedIndex].Money;
            TbSkill1.Text = lstUn[cb.SelectedIndex].Skill;
            switch (lstUn[cb.SelectedIndex].Id)
            {
                case 0:
                    a.Fill = Brushes.AliceBlue;
                    mainL.Content = "Обычный университет";
                    break;
                case 1:
                    a.Fill = Brushes.PaleGreen;
                    mainL.Content = "Военная академия";
                    break;
                case 2:
                    a.Fill = Brushes.Pink;
                    mainL.Content = "Магическая академия";
                    break;
            }
        }
        private void ToOpisanie_Click(object sender, RoutedEventArgs e)
        {
            if ((Button)sender == ReadOpi)
            {
                ReadOpisanie readOpisanie = new ReadOpisanie(lstUn[cb.SelectedIndex].Link, false, true);
                readOpisanie.Owner = this;
                readOpisanie.Show();
                ReadOpi.IsEnabled = false; cb.IsEnabled = false;
            }
            else
            {
                if (first_or)
                {
                    string for_forTb1 = "Unnamed.txt";
                    int i = 1;
                    while (File.Exists(@"C:\Users\borod\OneDrive\Рабочий стол\Dust_21-22\Основы алгоритмизации и программирования\Labs\Prakt11Lab\For11_Описания_Университетов\" + for_forTb1))
                        for_forTb1 = "Unnamed" + i++ + ".txt";
                    for_tb1 = for_forTb1;
                }
                ReadOpisanie readOpisanie = new ReadOpisanie(for_tb1, first_or, false);
                readOpisanie.Owner = this;
                readOpisanie.Show();
            }
        }

        //private void ForOp(object sender, TextChangedEventArgs e)
        //{
        //    if (TbName1.Text != "" && TbSkill1.Text != "") ToOpisanie.IsEnabled = true;
        //    else ToOpisanie.IsEnabled = false;
        //}
    }
}
