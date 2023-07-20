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
using UniversityLibrary;

namespace WPF_15Lab
{
    /// <summary>
    /// Логика взаимодействия для NewUniversity.xaml
    /// </summary>
    public partial class NewUniversity : Window
    {
        public NewUniversity()
        {
            InitializeComponent();

            cbOption.SelectedItem = 0;

            EndeInit = new Button();
            EndeInit.IsEnabled = false;
            EndeInit.Content = "Добавить университет!";
            EndeInit.VerticalAlignment = VerticalAlignment.Bottom;
            EndeInit.HorizontalAlignment = HorizontalAlignment.Right;
            EndeInit.Margin = new Thickness(0, 0, 18, 10);
            EndeInit.Width = 144;
            EndeInit.Height = 36;
            EndeInit.Click += Ending;
            begin.Children.Add(EndeInit);
        }
        Button EndeInit;
        public static bool IsNaturalNumber(string input)
        {
            try
            {
                if (Convert.ToInt32(input) > 0) return true; else return false;
            }
            catch { return false; }
        }
        public static bool IsPositiveDoubleNumber(string input)
        {
            try
            {
                if (Convert.ToDouble(input) > 0) return true; else return false;
            }
            catch { return false; }
        }
        public static bool IsNormalProcent(string input)
        {
            try
            {
                if (Convert.ToDouble(input) > 9 && Convert.ToDouble(input) < 201) return true; else return false;
            }
            catch { return false; }
        }
        public static bool IsNormalLevel(string input)
        {
            try
            {
                if (Convert.ToDouble(input) > 0 && Convert.ToDouble(input) < 6) return true; else return false;
            }
            catch { return false; }
        }
        public static bool IsNormalNagrad(string input)
        {
            try
            {
                if (Convert.ToDouble(input) > 0 && Convert.ToDouble(input) < 16) return true; else return false;
            }
            catch { return false; }
        }

        Label l5; 
        TextBox tb5;

        bool notFirstTime = false;

        LinearGradientBrush brush = new LinearGradientBrush();

        private void cbOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            brush.GradientStops.Clear(); begin.Children.Remove(l5); begin.Children.Remove(tb5);
            brush.GradientStops.Add(new GradientStop(Colors.SkyBlue, 0.0));
            brush.GradientStops.Add(new GradientStop(Colors.Orchid, 1.0));
            switch (cbOption.SelectedIndex)
            {
                case 0:
                    brush.GradientStops.Add(new GradientStop(Colors.SkyBlue, 0.75));
                    brush.GradientStops.Add(new GradientStop(Colors.SeaGreen, 0.85));
                    brush.GradientStops.Add(new GradientStop(Colors.SeaGreen, 0.85));
                    brush.GradientStops.Add(new GradientStop(Colors.Orchid, 0.95));
                    break;
                case 1:
                    brush.GradientStops.Add(new GradientStop(Colors.SkyBlue, 0.075));
                    brush.GradientStops.Add(new GradientStop(Colors.SeaGreen, 0.175));
                    brush.GradientStops.Add(new GradientStop(Colors.SeaGreen, 0.825));
                    brush.GradientStops.Add(new GradientStop(Colors.Orchid, 0.925));

                    l5 = new Label();
                    l5.VerticalAlignment = VerticalAlignment.Top;
                    l5.HorizontalAlignment = HorizontalAlignment.Left;
                    l5.Margin = new Thickness(24, 290, 0, 0);
                    l5.Content = "Число наград";

                    tb5 = new TextBox();
                    tb5.VerticalAlignment = VerticalAlignment.Top;
                    tb5.HorizontalAlignment = HorizontalAlignment.Left;
                    tb5.Margin = new Thickness(166, 290, 0, 0);
                    tb5.Width = 120; tb5.Height = 20;
                    tb5.TextChanged += Checking;

                    begin.Children.Add(l5); begin.Children.Add(tb5);

                    break;
                case 2:
                    brush.GradientStops.Add(new GradientStop(Colors.SkyBlue, 0.05));
                    brush.GradientStops.Add(new GradientStop(Colors.SeaGreen, 0.15));
                    brush.GradientStops.Add(new GradientStop(Colors.SeaGreen, 0.15));
                    brush.GradientStops.Add(new GradientStop(Colors.Orchid, 0.25));

                    l5 = new Label();
                    l5.VerticalAlignment = VerticalAlignment.Top;
                    l5.HorizontalAlignment = HorizontalAlignment.Left;
                    l5.Margin = new Thickness(24, 290, 0, 0);
                    l5.Content = "Уровень академии";

                    tb5 = new TextBox();
                    tb5.VerticalAlignment = VerticalAlignment.Top;
                    tb5.HorizontalAlignment = HorizontalAlignment.Left;
                    tb5.Margin = new Thickness(166, 290, 0, 0);
                    tb5.Width = 120; tb5.Height = 20;
                    tb5.TextChanged += Checking;

                    begin.Children.Add(l5); begin.Children.Add(tb5);
                    break;
            }
            a.Fill = brush;
            if (notFirstTime) Chechingeg(); else notFirstTime = true;
        }
        private void Chechingeg()
        {
            EndeInit.IsEnabled = true;
            if (IsPositiveDoubleNumber(TbAmountOfMoney1.Text) | TbAmountOfMoney1.Text == "") TbAmountOfMoney1.Background = Brushes.White;
            else
            {
                TbAmountOfMoney1.Background = Brushes.Crimson;
                EndeInit.IsEnabled = false;
            }
            if (IsPositiveDoubleNumber(TbCoursePrice1.Text) | TbCoursePrice1.Text == "") TbCoursePrice1.Background = Brushes.White;
            else
            {
                TbCoursePrice1.Background = Brushes.Crimson;
                EndeInit.IsEnabled = false;
            }
            if (IsNormalProcent(TbPowerSkill1.Text) | TbPowerSkill1.Text == "") TbPowerSkill1.Background = Brushes.White;
            else
            {
                TbPowerSkill1.Background = Brushes.Crimson;
                EndeInit.IsEnabled = false;
            }
            if (cbOption.SelectedIndex == 1)
                if (IsNormalNagrad(tb5.Text) || tb5.Text == "") tb5.Background = Brushes.White;
                else
                {
                    tb5.Background = Brushes.Crimson;
                    EndeInit.IsEnabled = false;
                }
            if (cbOption.SelectedIndex == 2)
                if (IsNormalLevel(tb5.Text) || tb5.Text == "") tb5.Background = Brushes.White;
                else
                {
                    tb5.Background = Brushes.Crimson;
                    EndeInit.IsEnabled = false;
                }
            MainWindow mw = (MainWindow)this.Owner;
            TbName1.Background = Brushes.White;
            foreach (University university in mw.lstUniversities)
            {
                if (university.Name == TbName1.Text)
                {
                    TbName1.Background = Brushes.Crimson;
                    EndeInit.IsEnabled = false;
                    break;
                }
            }
            foreach (FrameworkElement i in begin.Children)
                if (i is TextBox)
                {
                    TextBox tb = (TextBox)i;
                    if (tb.Text == "" || tb.Background == Brushes.Crimson)
                    {
                        EndeInit.IsEnabled = false;
                        break;
                    }
                }
        }
        private void Checking(object sender, TextChangedEventArgs e)
        {
            Chechingeg();
        }
        public void Ending(object sender, RoutedEventArgs e)
        {
            MainWindow m = (MainWindow)this.Owner;
            switch (cbOption.SelectedIndex)
            {
                case 0:
                    University university = new University();
                    university.Price = Convert.ToDouble(TbCoursePrice1.Text);
                    university.Name = TbName1.Text.Trim();
                    university.Coefficient = Convert.ToInt32(TbPowerSkill1.Text);
                    university.Money = Convert.ToDouble(TbAmountOfMoney1.Text);
                    m.lstUniversities.Add(university);
                    break;
                case 1:
                    Military military = new Military();
                    military.Price = Convert.ToDouble(TbCoursePrice1.Text);
                    military.Name = TbName1.Text.Trim();
                    military.Nagrady = Convert.ToInt32(tb5.Text);
                    military.Coefficient = Convert.ToInt32(TbPowerSkill1.Text);
                    military.Money = Convert.ToDouble(TbAmountOfMoney1.Text);
                    m.lstUniversities.Add(military);
                    break;
                case 2:
                    Magic magic = new Magic();
                    magic.Price = Convert.ToDouble(TbCoursePrice1.Text);
                    magic.Name = TbName1.Text.Trim();
                    magic.Level = Convert.ToInt32(tb5.Text);
                    magic.Coefficient = Convert.ToInt32(TbPowerSkill1.Text);
                    magic.Money = Convert.ToDouble(TbAmountOfMoney1.Text);
                    m.lstUniversities.Add(magic);
                    break;
            }
            Close();
        }
    }
}
