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

namespace Prakt6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> lstEdu = new List<string>();
        University university = new University();
        Military military = new Military();
        Magic magic = new Magic();
        Random r = new Random();
        string name_2;
        double current_hero_money_2;
        double current_skill_amount_21;
        double current_skill_amount_22;
        double current_skill_amount_23;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSave2_Click(object sender, RoutedEventArgs e)
        {
            name_2 = TbName2.Text;
            current_hero_money_2 = Convert.ToDouble(TbCurrentHeroMoney2.Text);
            current_skill_amount_21 = Convert.ToDouble(TbCurrentSkillAmount21.Text);
            current_skill_amount_22 = Convert.ToDouble(TbCurrentSkillAmount22.Text);
            current_skill_amount_23 = Convert.ToDouble(TbCurrentSkillAmount23.Text);
            ButtonSave1.IsEnabled = true; ButtonSave3.IsEnabled = true; ButtonSave4.IsEnabled = true;
            ButtonLearn1.IsEnabled = Convert.ToBoolean((Math.Sign(Convert.ToInt32(current_hero_money_2 - university.Price)) + 1) * university.Price);
            ButtonLearn3.IsEnabled = Convert.ToBoolean((Math.Sign(Convert.ToInt32(current_hero_money_2 - military.Price)) + 1) * military.Price);
            ButtonLearn4.IsEnabled = Convert.ToBoolean((Math.Sign(Convert.ToInt32(current_hero_money_2 - magic.Price)) + 1) * magic.Price);
        }

        private void ButtonSave1_Click(object sender, RoutedEventArgs e)
        {
            //university.Skill = TbSkillName1.Text;
            university.Coefficient = Convert.ToDouble(TbPowerSkill1.Text);
            university.Price = Convert.ToDouble(TbCoursePrice1.Text);
            university.Money = Convert.ToDouble(TbCurrentUniversityMoney1.Text);
            ButtonLearn1.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - university.Price)) + 1);
            switch (noch1.SelectedIndex)
            {
                case 0:
                    university.Skill = "Ум";
                    break;
                case 1:
                    university.Skill = "Сила";
                    break;
                case 2:
                    university.Skill = "Шторм";
                    break;
                case 3:
                    university.Skill = "Мана";
                    break;
                case 4:
                    university.Skill = "Броня";
                    break;
            }
        }

        private void ButtonSave3_Click(object sender, RoutedEventArgs e)
        {
            //military.Skill = TbSkillName3.Text;
            military.Coefficient = Convert.ToDouble(TbPowerSkill3.Text);
            military.Price = Convert.ToDouble(TbCoursePrice3.Text);
            military.Money = Convert.ToDouble(TbCurrentUniversityMoney3.Text);
            military.Nagrady = Convert.ToInt32(TbNagrady3.Text);
            ButtonLearn3.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - military.Price)) + 1);
            nanan.IsEnabled = true;
            switch (noch3.SelectedIndex)
            {
                case 0:
                    military.Skill = "Ум";
                    break;
                case 1:
                    military.Skill = "Сила";
                    break;
                case 2:
                    military.Skill = "Шторм";
                    break;
                case 3:
                    military.Skill = "Мана";
                    break;
                case 4:
                    military.Skill = "Броня";
                    break;
            }
        }

        private void ButtonSave4_Click(object sender, RoutedEventArgs e)
        {
            //magic.Skill = TbSkillName4.Text;
            magic.Coefficient = Convert.ToDouble(TbPowerSkill4.Text);
            magic.Price = Convert.ToDouble(TbCoursePrice4.Text);
            magic.Money = Convert.ToDouble(TbCurrentUniversityMoney4.Text);
            magic.TypeSkill = TbSkillType4.Text;
            magic.Level = Convert.ToInt32(TbLevel4.Text);
            ButtonLearn4.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - magic.Price)) + 1);
            switch (noch4.SelectedIndex)
            {
                case 0:
                    magic.Skill = "Ум";
                    break;
                case 1:
                    magic.Skill = "Сила";
                    break;
                case 2:
                    magic.Skill = "Шторм";
                    break;
                case 3:
                    magic.Skill = "Мана";
                    break;
                case 4:
                    magic.Skill = "Броня";
                    break;
            }
        }

        private void ButtonLearn1_Click(object sender, RoutedEventArgs e)
        {
            //double zuwachs = Math.Round(university.FutureSkill(current_skill_amount_2), 2);
            //lstEdu.Add("Персонаж " + name_2 + " повысил навык " + university.Skill + " на " + (zuwachs - current_skill_amount_2) + " в Университете");
            //current_skill_amount_2 = zuwachs;
            switch (university.Skill)
            {
                case "Ум":
                    {
                        double zuwachs = Math.Round(university.FutureSkill(current_skill_amount_21), 2);
                        lstEdu.Add("Персонаж " + name_2 + " повысил навык " + university.Skill + " на " + (zuwachs - current_skill_amount_21) + " в Университете");
                        current_skill_amount_21 = zuwachs;
                        TbCurrentSkillAmount21.Text = "" + current_skill_amount_21;
                        break;
                    }
                case "Сила":
                    {
                        double zuwachs = Math.Round(university.FutureSkill(current_skill_amount_22), 2);
                        lstEdu.Add("Персонаж " + name_2 + " повысил навык " + university.Skill + " на " + (zuwachs - current_skill_amount_22) + " в Университете");
                        current_skill_amount_22 = zuwachs;
                        TbCurrentSkillAmount22.Text = "" + current_skill_amount_22;

                        break;
                    }
                case "Шторм":
                    {
                        double zuwachs = Math.Round(university.FutureSkill(current_skill_amount_23), 2);
                        lstEdu.Add("Персонаж " + name_2 + " повысил навык " + university.Skill + " на " + (zuwachs - current_skill_amount_23) + " в Университете");
                        current_skill_amount_23 = zuwachs;
                        TbCurrentSkillAmount23.Text = "" + current_skill_amount_23;
                        break;
                    }
            }
            double diff = university.PriceWithSale();
            current_hero_money_2 -= diff;
            TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
            university.Money += diff;
            TbCurrentUniversityMoney1.Text = "" + university.Money;
            ButtonLearn1.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - university.Price)) + 1);
        }

        private void ButtonLearn3_Click(object sender, RoutedEventArgs e)
        {
            //double zuwachs = Math.Round(military.FutureSkill(current_skill_amount_2), 2);
            //lstEdu.Add("Персонаж " + name_2 + " повысил навык " + military.Skill + " на " + (zuwachs - current_skill_amount_2) + " в Военной академии");
            //current_skill_amount_2 = zuwachs;
            //TbCurrentSkillAmount2.Text = "" + current_skill_amount_2;
            switch (military.Skill)
            {
                case "Ум":
                    {
                        double zuwachs = Math.Round(military.FutureSkill(current_skill_amount_21), 2);
                        lstEdu.Add("Персонаж " + name_2 + " повысил навык " + military.Skill + " на " + (zuwachs - current_skill_amount_21) + " в Военной академии");
                        current_skill_amount_21 = zuwachs;
                        TbCurrentSkillAmount21.Text = "" + current_skill_amount_21;
                        break;
                    }
                case "Сила":
                    {
                        double zuwachs = Math.Round(military.FutureSkill(current_skill_amount_22), 2);
                        lstEdu.Add("Персонаж " + name_2 + " повысил навык " + military.Skill + " на " + (zuwachs - current_skill_amount_22) + " в Военной академии");
                        current_skill_amount_22 = zuwachs;
                        TbCurrentSkillAmount22.Text = "" + current_skill_amount_22;
                        break;
                    }
                case "Шторм":
                    {
                        double zuwachs = Math.Round(military.FutureSkill(current_skill_amount_23), 2);
                        lstEdu.Add("Персонаж " + name_2 + " повысил навык " + military.Skill + " на " + (zuwachs - current_skill_amount_23) + " в Военной академии");
                        current_skill_amount_22 = zuwachs;
                        TbCurrentSkillAmount23.Text = "" + current_skill_amount_23;
                        break;
                    }
            }
            double diff = military.PriceWithSale();
            current_hero_money_2 -= diff;
            TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
            military.Money += diff;
            TbCurrentUniversityMoney3.Text = "" + military.Money;
            ButtonLearn3.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - military.Price)) + 1);
        }

        private void ButtonLearn4_Click(object sender, RoutedEventArgs e)
        {
            //double zuwachs = Math.Round(magic.FutureSkill(current_skill_amount_2), 2);
            //lstEdu.Add("Персонаж " + name_2 + " повысил навык " + magic.Skill + " стихии " + magic.TypeSkill + " на " + (zuwachs - current_skill_amount_2) + " в Магической академии");
            //current_skill_amount_2 = zuwachs;
            //TbCurrentSkillAmount2.Text = "" + current_skill_amount_2;
            switch (magic.Skill)
            {
                case "Ум":
                    {
                        double zuwachs = Math.Round(military.FutureSkill(current_skill_amount_21), 2);
                        lstEdu.Add("Персонаж " + name_2 + " повысил навык " + magic.Skill + " стихии " + magic.TypeSkill + " на " + (zuwachs - current_skill_amount_21) + " в Магической академии");
                        current_skill_amount_21 = zuwachs;
                        TbCurrentSkillAmount21.Text = "" + current_skill_amount_21;
                        break;
                    }
                case "Сила":
                    {
                        double zuwachs = Math.Round(military.FutureSkill(current_skill_amount_22), 2);
                        lstEdu.Add("Персонаж " + name_2 + " повысил навык " + magic.Skill + " стихии " + magic.TypeSkill + " на " + (zuwachs - current_skill_amount_22) + " в Магической академии");
                        current_skill_amount_22 = zuwachs;
                        TbCurrentSkillAmount22.Text = "" + current_skill_amount_22;
                        break;
                    }
                case "Шторм":
                    {
                        double zuwachs = Math.Round(military.FutureSkill(current_skill_amount_23), 2);
                        lstEdu.Add("Персонаж " + name_2 + " повысил навык " + magic.Skill + " стихии " + magic.TypeSkill + " на " + (zuwachs - current_skill_amount_23) + " в Магической академии");
                        current_skill_amount_22 = zuwachs;
                        TbCurrentSkillAmount23.Text = "" + current_skill_amount_23;
                        break;
                    }
            }
            double diff = magic.PriceWithSale();
            current_hero_money_2 -= diff;
            TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
            magic.Money += diff;
            TbCurrentUniversityMoney4.Text = "" + magic.Money;
            ButtonLearn4.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - magic.Price)) + 1);
        }

        private void ButtonList_Click(object sender, RoutedEventArgs e)
        {
            Edu.Content = "";
            foreach (string r in lstEdu)
                Edu.Content += r + "\n";
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Edu.Content = "";
        }

        private void nanan_Click(object sender, RoutedEventArgs e)
        {
            military.GiveNagrad();
            TbNagrady3.Text = "" + military.Nagrady;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (cbOption.SelectedIndex)
            {
                case 0:
                        ga.Opacity = 100; ga.Margin = new Thickness(8, 144, 0, 0); ga.IsEnabled = true;
                        gb.Opacity = 0; gb.Margin = new Thickness(317, 144, 0, 0); gb.IsEnabled = false;
                        gc.Opacity = 0; gc.Margin = new Thickness(317, 144, 0, 0); gc.IsEnabled = false;
                    break;
                case 1:
                    
                        gb.Opacity = 100; gb.Margin = new Thickness(8, 144, 0, 0); gb.IsEnabled = true;
                        ga.Opacity = 0; ga.Margin = new Thickness(317, 144, 0, 0); ga.IsEnabled = false;
                        gc.Opacity = 0; gc.Margin = new Thickness(317, 144, 0, 0); gc.IsEnabled = false;
                    
                    break;
                case 2:
                    
                        gc.Opacity = 100; gc.Margin = new Thickness(8, 144, 0, 0); gc.IsEnabled = true;
                        ga.Opacity = 0; ga.Margin = new Thickness(317, 144, 0, 0); ga.IsEnabled = false;
                        gb.Opacity = 0; gb.Margin = new Thickness(317, 144, 0, 0); gb.IsEnabled = false;
                    break;
                    
            }
        }

        private void ButtonTheme_Click(object sender, RoutedEventArgs e)
        {
            switch (theme.SelectedIndex)
            {
                case 0:
                ButtonClear.Background = Brushes.LightGray; ButtonList.Background = Brushes.LightGray; ButtonSave4.Background = Brushes.LightGray;
                ButtonLearn1.Background = Brushes.LightGray; ButtonSave1.Background = Brushes.LightGray; ButtonTheme.Background = Brushes.LightGray;
                ButtonLearn3.Background = Brushes.LightGray; ButtonSave2.Background = Brushes.LightGray; nanan.Background = Brushes.LightGray;
                ButtonLearn4.Background = Brushes.LightGray; ButtonSave3.Background = Brushes.LightGray;
                 a.Fill = Brushes.LightBlue;
                 b.Fill = Brushes.Cyan;
                  c.Fill = Brushes.Violet;
                    aaa.Fill = Brushes.White;
                    f.Fill = Brushes.Red;

                    break;
                case 1:
                    ButtonClear.Background = Brushes.White; ButtonList.Background = Brushes.White; ButtonSave4.Background = Brushes.White;
                    ButtonLearn1.Background = Brushes.White; ButtonSave1.Background = Brushes.White; ButtonTheme.Background = Brushes.White;
                    ButtonLearn3.Background = Brushes.White; ButtonSave2.Background = Brushes.White; nanan.Background = Brushes.White;
                    ButtonLearn4.Background = Brushes.White; ButtonSave3.Background = Brushes.White;
                    a.Fill = Brushes.LightBlue;
                    b.Fill = Brushes.Cyan;
                    c.Fill = Brushes.Violet;
                    aaa.Fill = Brushes.Black;
                    f.Fill = Brushes.Red;
                    break;
                case 2:
                    ButtonClear.Background = Brushes.Lime; ButtonList.Background = Brushes.Lime; ButtonSave4.Background = Brushes.White;
                    ButtonLearn1.Background = Brushes.Purple; ButtonSave1.Background = Brushes.White; ButtonTheme.Background = Brushes.Red;
                    ButtonLearn3.Background = Brushes.Cyan; ButtonSave2.Background = Brushes.White; nanan.Background = Brushes.Blue ;
                    ButtonLearn4.Background = Brushes.LightPink; ButtonSave3.Background = Brushes.Green;
                    a.Fill = Brushes.White;
                    b.Fill = Brushes.White;
                    c.Fill = Brushes.White;
                    aaa.Fill = Brushes.Yellow;
                    f.Fill = Brushes.Pink;
                    break;
            }
            

        }
    }
}

