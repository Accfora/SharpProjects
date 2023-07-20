using DragonLib;
using Knights;
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
    /// Логика взаимодействия для NewCharacter.xaml
    /// </summary>
    public partial class NewCharacter : Window
    {
        public NewCharacter()
        {
            InitializeComponent();
        }

        public static bool IsNaturalNumber(string input)
        {
            try
            {
                if (Convert.ToInt32(input) > 0) return true; else return false;
            }
            catch { return false; }
        }
        public static bool IsNormalAge(string input)
        {
            try
            {
                if (Convert.ToInt32(input) > 5 && Convert.ToInt32(input) < 151) return true; else return false;
            }
            catch { return false; }
        }
        public static bool IsNotNegativeNumber(string input)
        {
            try
            {
                if (Convert.ToInt32(input) >= 0) return true; else return false;
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

        Image image = new Image();

        List<TextBox> lstTextBox = new List<TextBox>();

        Label l; CheckBox c = new CheckBox(); public Grid InitCharacter; Button EndeInit;

        int who; string toHead;
        private void InitNumber(object sender, RoutedEventArgs e)
        {
            who = Convert.ToInt32("" + ((Button)sender).Name.ToString()[((Button)sender).Name.Length - 1]);
            toHead = "" + ((Button)sender).Content;
            switch (who)
            {
                case 0:
                    image = kn0ph;
                    image.Width = 143;
                    break;
                case 1:
                    image = kn1ph;
                    image.Width = 166;
                    break;
                case 2:
                    image = kn2ph;
                    image.Width = 175;
                    break;
                case 3:
                    image = dr0ph;
                    image.Width = 167;
                    break;
                case 4:
                    image = dr1ph;
                    image.Width = 201;
                    break;
                case 5:
                    image = dr2ph;
                    image.Width = 219;
                    break;
            }
            image.Height = 128;
            Chosen(sender, e);
        }
        private void Chosen(object sender, RoutedEventArgs e)
        {
            myw.Width = 50 + 30 + 356;
            myw.Height = 100 + 30 + 433;

            g.Children.Clear();

            InitCharacter = new Grid();
            InitCharacter.HorizontalAlignment = HorizontalAlignment.Left;
            InitCharacter.Height = 473;
            InitCharacter.Margin = new Thickness(30, 30, 0, 0);
            InitCharacter.VerticalAlignment = VerticalAlignment.Top;
            InitCharacter.Width = 356;

            if (who == 0 | who == 1 | who == 2)
                InitCharacter.Background = Brushes.SandyBrown;
            else InitCharacter.Background = Brushes.LightPink;

            g.Children.Add(InitCharacter);

            InitCharacter.Children.Add(image);
            //image.Margin = new Thickness(image.Margin.Right + image.Margin.Left - 18 - InitCharacter.Margin.Left, 10, 18, image.Margin.Bottom + image.Margin.Top - 10 - InitCharacter.Margin.Top);
            image.Margin = new Thickness(0, 10, 10, 0);
            image.HorizontalAlignment = HorizontalAlignment.Right;
            image.VerticalAlignment = VerticalAlignment.Top;

            Label headInit = new Label();
            headInit.HorizontalAlignment = HorizontalAlignment.Left;
            headInit.Margin = new Thickness(10, 10, 0, 0);
            headInit.VerticalAlignment = VerticalAlignment.Top;
            headInit.FontSize = 20;
            headInit.Width = 305;
            headInit.Content = toHead;
            InitCharacter.Children.Add(headInit);

            int amountL = 0;
            for (int i = 0; i < 4; i++)
            {
                string[] lT = { "Имя", "Макс. кол-во ХП", "Текущее кол-во ХП", "Макс. сила атаки" };
                Label l = new Label();
                l.Content = lT[i];
                l.HorizontalAlignment = HorizontalAlignment.Left;
                l.Margin = new Thickness(10, 154 + (i * 37), 0, 0);
                l.VerticalAlignment = VerticalAlignment.Top;
                l.Width = 144;
                amountL++;
                InitCharacter.Children.Add(l);
            }

            if (who == 0 | who == 1 | who == 2)
            {
                l = new Label();
                l.Content = "Кол-во денег";
                l.HorizontalAlignment = HorizontalAlignment.Left;
                l.Margin = new Thickness(10, 154 + (4 * 37), 0, 0);
                l.VerticalAlignment = VerticalAlignment.Top;
                l.Width = 144;
                amountL++;
                InitCharacter.Children.Add(l);
            }

            if (who == 1)
            {
                string[] lT = { "Возраст рыцаря", "Возраст артефакта" };
                for (int i = 0; i < 2; i++)
                {
                    l = new Label();
                    l.Content = lT[i];
                    l.HorizontalAlignment = HorizontalAlignment.Left;
                    l.Margin = new Thickness(10, 154 + ((5 + i) * 37), 0, 0);
                    l.VerticalAlignment = VerticalAlignment.Top;
                    l.Width = 144;
                    amountL++;
                    InitCharacter.Children.Add(l);
                }
            }

            if (who == 2)
            {
                l = new Label();
                l.Content = "Кол-во походов";
                l.HorizontalAlignment = HorizontalAlignment.Left;
                l.Margin = new Thickness(10, 154 + (5 * 37), 0, 0);
                l.VerticalAlignment = VerticalAlignment.Top;
                l.Width = 144;
                amountL++;
                InitCharacter.Children.Add(l);
            }

            if (who == 4)
            {
                l = new Label();
                l.Content = "Видимость";
                l.HorizontalAlignment = HorizontalAlignment.Left;
                l.Margin = new Thickness(10, 154 + (4 * 37), 0, 0);
                l.VerticalAlignment = VerticalAlignment.Top;
                l.Width = 144;
                InitCharacter.Children.Add(l);
                c.HorizontalAlignment = HorizontalAlignment.Left;
                c.Margin = new Thickness(194, 157 + (4 * 37), 0, 0);
                c.VerticalAlignment = VerticalAlignment.Top;
                c.IsChecked = true;
                c.Width = 144;
                InitCharacter.Children.Add(c);
            }

            if (who == 5)
            {
                l = new Label();
                l.Content = "Кол-во морских боёв";
                l.HorizontalAlignment = HorizontalAlignment.Left;
                l.Margin = new Thickness(10, 154 + (4 * 37), 0, 0);
                l.VerticalAlignment = VerticalAlignment.Top;
                l.Width = 144;
                amountL++;
                InitCharacter.Children.Add(l);
            }

            for (int i = 0; i < amountL; i++)
            {
                TextBox t = new TextBox();
                t.HorizontalAlignment = HorizontalAlignment.Left;
                t.Margin = new Thickness(194, 157 + (i * 37), 0, 0);
                t.VerticalAlignment = VerticalAlignment.Top;
                t.Width = 144;
                t.TextChanged += Checking;
                InitCharacter.Children.Add(t); lstTextBox.Add(t);
            }

            EndeInit = new Button();
            EndeInit.IsEnabled = false;
            EndeInit.Content = "Добавить персонажа!";
            EndeInit.VerticalAlignment = VerticalAlignment.Bottom;
            EndeInit.HorizontalAlignment = HorizontalAlignment.Right;
            EndeInit.Margin = new Thickness(0, 0, 18, 10);
            EndeInit.Width = 144;
            EndeInit.Height = 36;
            EndeInit.Click += Ending;
            InitCharacter.Children.Add(EndeInit);
        }

        private void Checking(object sender, TextChangedEventArgs e)
        {
            EndeInit.IsEnabled = true;
            if (IsNaturalNumber(lstTextBox[1].Text) | lstTextBox[1].Text == "") lstTextBox[1].Background = Brushes.White;
            else
            {
                lstTextBox[1].Background = Brushes.Crimson;
                EndeInit.IsEnabled = false;
            }
            if (IsNaturalNumber(lstTextBox[2].Text) | lstTextBox[2].Text == "") lstTextBox[2].Background = Brushes.White;
            else
            {
                lstTextBox[2].Background = Brushes.Crimson;
                EndeInit.IsEnabled = false;
            }
            if (EndeInit.IsEnabled && lstTextBox[2].Text != "" && lstTextBox[1].Text != "")
                if (Convert.ToInt32(lstTextBox[2].Text) > Convert.ToInt32(lstTextBox[1].Text))
                {
                    lstTextBox[2].Background = Brushes.Crimson;
                    EndeInit.IsEnabled = false;
                }
            if (IsNaturalNumber(lstTextBox[3].Text) | lstTextBox[3].Text == "") lstTextBox[3].Background = Brushes.White;
            else
            {
                lstTextBox[3].Background = Brushes.Crimson;
                EndeInit.IsEnabled = false;
            }
            MainWindow mw = (MainWindow)this.Owner;
            if (who == 0 || who == 1 || who == 2)
            {
                if (IsPositiveDoubleNumber(lstTextBox[4].Text) | lstTextBox[4].Text == "") lstTextBox[4].Background = Brushes.White;
                else
                {
                    lstTextBox[4].Background = Brushes.Crimson;
                    EndeInit.IsEnabled = false;
                }
                lstTextBox[0].Background = Brushes.White;
                foreach (Knight knight in mw.lstKnights)
                {
                    if (knight.Truename == lstTextBox[0].Text)
                    {
                        lstTextBox[0].Background = Brushes.Crimson;
                        EndeInit.IsEnabled = false;
                        break;
                    }
                }
            }
            else
            {
                lstTextBox[0].Background = Brushes.White;
                foreach (Dragon dragon in mw.lstDragons)
                {
                    if (dragon.Name == lstTextBox[0].Text)
                    {
                        lstTextBox[0].Background = Brushes.Crimson;
                        EndeInit.IsEnabled = false;
                        break;
                    }
                }
            }
            if (who == 1)
            {
                if (IsNormalAge(lstTextBox[5].Text) | lstTextBox[5].Text == "") lstTextBox[5].Background = Brushes.White;
                else
                {
                    lstTextBox[5].Background = Brushes.Crimson;
                    EndeInit.IsEnabled = false;
                }
                if (IsNaturalNumber(lstTextBox[6].Text) | lstTextBox[6].Text == "") lstTextBox[6].Background = Brushes.White;
                else
                {
                    lstTextBox[6].Background = Brushes.Crimson;
                    EndeInit.IsEnabled = false;
                }
            }
            if (who == 2)
                if (IsNotNegativeNumber(lstTextBox[5].Text) | lstTextBox[5].Text == "") lstTextBox[5].Background = Brushes.White;
                else
                {
                    lstTextBox[5].Background = Brushes.Crimson;
                    EndeInit.IsEnabled = false;
                }
            if (who == 5)
                if (IsNotNegativeNumber(lstTextBox[4].Text) | lstTextBox[4].Text == "") lstTextBox[4].Background = Brushes.White;
                else
                {
                    lstTextBox[4].Background = Brushes.Crimson;
                    EndeInit.IsEnabled = false;
                }

            foreach (TextBox tb in lstTextBox)
                if (tb.Text == "" || tb.Background == Brushes.Crimson)
                {
                    EndeInit.IsEnabled = false;
                    break;
                }
        }
        public void Ending(object sender, RoutedEventArgs e)
        {
            MainWindow m = (MainWindow)this.Owner;
            switch (who)
            {
                case 0:
                    Knight kn0 = new Knight();
                    kn0.Truename = lstTextBox[0].Text.Trim();
                    kn0.Max_HP = Convert.ToDouble(lstTextBox[1].Text);
                    kn0.Current_HP = Convert.ToDouble(lstTextBox[2].Text);
                    kn0.Max_attack = Convert.ToDouble(lstTextBox[3].Text);
                    kn0.Money = Convert.ToDouble(lstTextBox[4].Text);
                    m.lstKnights.Add(kn0);
                    kn0 = new Knight();
                    kn0.Truename = lstTextBox[0].Text.Trim();
                    kn0.Max_HP = Convert.ToDouble(lstTextBox[1].Text);
                    kn0.Current_HP = Convert.ToDouble(lstTextBox[2].Text);
                    kn0.Max_attack = Convert.ToDouble(lstTextBox[3].Text);
                    kn0.Money = Convert.ToDouble(lstTextBox[4].Text);
                    m.lstKnightsAtBegin.Add(kn0);
                    break;
                case 1:
                    Christ kn1 = new Christ(); 
                    kn1.Truename = lstTextBox[0].Text.Trim();
                    kn1.Max_HP = Convert.ToDouble(lstTextBox[1].Text);
                    kn1.Current_HP = Convert.ToDouble(lstTextBox[2].Text);
                    kn1.Max_attack = Convert.ToDouble(lstTextBox[3].Text);
                    kn1.Money = Convert.ToDouble(lstTextBox[4].Text);
                    kn1.Years = Convert.ToInt32(lstTextBox[5].Text);
                    kn1.Art_year = Convert.ToInt32(lstTextBox[6].Text);
                    m.lstKnights.Add(kn1);
                    kn1 = new Christ();
                    kn1.Truename = lstTextBox[0].Text.Trim();
                    kn1.Max_HP = Convert.ToDouble(lstTextBox[1].Text);
                    kn1.Current_HP = Convert.ToDouble(lstTextBox[2].Text);
                    kn1.Max_attack = Convert.ToDouble(lstTextBox[3].Text);
                    kn1.Money = Convert.ToDouble(lstTextBox[4].Text);
                    kn1.Years = Convert.ToInt32(lstTextBox[5].Text);
                    kn1.Art_year = Convert.ToInt32(lstTextBox[6].Text);
                    m.lstKnightsAtBegin.Add(kn1);
                    break;
                case 2:
                    Knight_Of_Ball kn2 = new Knight_Of_Ball();
                    kn2.Truename = lstTextBox[0].Text.Trim();
                    kn2.Max_HP = Convert.ToDouble(lstTextBox[1].Text);
                    kn2.Current_HP = Convert.ToDouble(lstTextBox[2].Text);
                    kn2.Max_attack = Convert.ToDouble(lstTextBox[3].Text);
                    kn2.Money = Convert.ToDouble(lstTextBox[4].Text);
                    kn2.Pohod = Convert.ToInt32(lstTextBox[5].Text);
                    m.lstKnights.Add(kn2);
                    kn2 = new Knight_Of_Ball();
                    kn2.Truename = lstTextBox[0].Text.Trim();
                    kn2.Max_HP = Convert.ToDouble(lstTextBox[1].Text);
                    kn2.Current_HP = Convert.ToDouble(lstTextBox[2].Text);
                    kn2.Max_attack = Convert.ToDouble(lstTextBox[3].Text);
                    kn2.Money = Convert.ToDouble(lstTextBox[4].Text);
                    kn2.Pohod = Convert.ToInt32(lstTextBox[5].Text);
                    m.lstKnightsAtBegin.Add(kn2);
                    break;
                case 3:
                    Dragon dr0 = new Dragon();
                    dr0.Name = lstTextBox[0].Text.Trim();
                    dr0.MaxHealth = Convert.ToInt32(lstTextBox[1].Text);
                    dr0.NowHealth = Convert.ToInt32(lstTextBox[2].Text);
                    dr0.MaxDamage = Convert.ToInt32(lstTextBox[3].Text);
                    m.lstDragons.Add(dr0);
                    dr0 = new Dragon();
                    dr0.Name = lstTextBox[0].Text.Trim();
                    dr0.MaxHealth = Convert.ToInt32(lstTextBox[1].Text);
                    dr0.NowHealth = Convert.ToInt32(lstTextBox[2].Text);
                    dr0.MaxDamage = Convert.ToInt32(lstTextBox[3].Text);
                    m.lstDragonsAtBegin.Add(dr0);
                    break;
                case 4:
                    AirDragon dr1 = new AirDragon(); 
                    dr1.Name = lstTextBox[0].Text.Trim();
                    dr1.MaxHealth = Convert.ToInt32(lstTextBox[1].Text);
                    dr1.NowHealth = Convert.ToInt32(lstTextBox[2].Text);
                    dr1.MaxDamage = Convert.ToInt32(lstTextBox[3].Text);
                    dr1.Visibility = Convert.ToBoolean(c.IsChecked);
                    m.lstDragons.Add(dr1);
                    dr1 = new AirDragon();
                    dr1.Name = lstTextBox[0].Text.Trim();
                    dr1.MaxHealth = Convert.ToInt32(lstTextBox[1].Text);
                    dr1.NowHealth = Convert.ToInt32(lstTextBox[2].Text);
                    dr1.MaxDamage = Convert.ToInt32(lstTextBox[3].Text);
                    dr1.Visibility = Convert.ToBoolean(c.IsChecked);
                    m.lstDragonsAtBegin.Add(dr1);
                    break;
                case 5:
                    SeaDragon dr2 = new SeaDragon();
                    dr2.Name = lstTextBox[0].Text.Trim();
                    dr2.MaxHealth = Convert.ToInt32(lstTextBox[1].Text);
                    dr2.NowHealth = Convert.ToInt32(lstTextBox[2].Text);
                    dr2.MaxDamage = Convert.ToInt32(lstTextBox[3].Text);
                    dr2.BattleCount = Convert.ToInt32(lstTextBox[4].Text);
                    m.lstDragons.Add(dr2);
                    dr2 = new SeaDragon();
                    dr2.Name = lstTextBox[0].Text.Trim();
                    dr2.MaxHealth = Convert.ToInt32(lstTextBox[1].Text);
                    dr2.NowHealth = Convert.ToInt32(lstTextBox[2].Text);
                    dr2.MaxDamage = Convert.ToInt32(lstTextBox[3].Text);
                    dr2.BattleCount = Convert.ToInt32(lstTextBox[4].Text);
                    m.lstDragonsAtBegin.Add(dr2);
                    break;
            }
            Close();
        }
    }
}
