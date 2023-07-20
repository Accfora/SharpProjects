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

namespace SomethingMilitaryAndMagic
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
        string name_2;
        double current_hero_money_2;
        double current_skill_amount_2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSave2_Click(object sender, RoutedEventArgs e)
        {
            name_2 = TbName2.Text;
            current_hero_money_2 = Convert.ToDouble(TbCurrentHeroMoney2.Text);
            current_skill_amount_2 = Convert.ToDouble(TbCurrentSkillAmount2.Text);
            ButtonSave1.IsEnabled = true; ButtonSave3.IsEnabled = true; ButtonSave4.IsEnabled = true;
            ButtonLearn1.IsEnabled = Convert.ToBoolean((Math.Sign(Convert.ToInt32(current_hero_money_2 - university.Price)) + 1) * university.Price);
            ButtonLearn3.IsEnabled = Convert.ToBoolean((Math.Sign(Convert.ToInt32(current_hero_money_2 - military.Price)) + 1) * military.Price);
            ButtonLearn4.IsEnabled = Convert.ToBoolean((Math.Sign(Convert.ToInt32(current_hero_money_2 - magic.Price)) + 1) * magic.Price);
        }

        private void ButtonSave1_Click(object sender, RoutedEventArgs e)
        {
            university.Skill = TbSkillName1.Text;
            university.Coefficient = Convert.ToDouble(TbPowerSkill1.Text);
            university.Price = Convert.ToDouble(TbCoursePrice1.Text);
            university.Money = Convert.ToDouble(TbCurrentUniversityMoney1.Text);
            ButtonLearn1.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - university.Price)) + 1);
        }

        private void ButtonSave3_Click(object sender, RoutedEventArgs e)
        {
            military.Skill = TbSkillName3.Text;
            military.Coefficient = Convert.ToDouble(TbPowerSkill3.Text);
            military.Price = Convert.ToDouble(TbCoursePrice3.Text);
            military.Money = Convert.ToDouble(TbCurrentUniversityMoney3.Text);
            military.Nagrady = Convert.ToInt32(TbNagrady3.Text);
            ButtonLearn3.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - military.Price)) + 1);
            nanan.IsEnabled = true;
        }

        private void ButtonSave4_Click(object sender, RoutedEventArgs e)
        {
            magic.Skill = TbSkillName4.Text;
            magic.Coefficient = Convert.ToDouble(TbPowerSkill4.Text);
            magic.Price = Convert.ToDouble(TbCoursePrice4.Text);
            magic.Money = Convert.ToDouble(TbCurrentUniversityMoney4.Text);
            magic.TypeSkill = TbSkillType4.Text;
            magic.Level = Convert.ToInt32(TbLevel4.Text);
            ButtonLearn4.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - magic.Price)) + 1);
        }

        private void ButtonLearn1_Click(object sender, RoutedEventArgs e)
        {
            double zuwachs = Math.Round(university.FutureSkill(current_skill_amount_2), 2);
            lstEdu.Add("Персонаж " + name_2 + " повысил навык " + TbSkillName1.Text + " на " +(zuwachs - current_skill_amount_2)+" в Университете");
            current_skill_amount_2 = zuwachs;
            TbCurrentSkillAmount2.Text = "" + current_skill_amount_2;
            double diff = university.PriceWithSale();
            current_hero_money_2 -= diff;
            TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
            university.Money += diff;
            TbCurrentUniversityMoney1.Text = "" + university.Money;
            ButtonLearn1.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - university.Price)) + 1);
        }

        private void ButtonLearn3_Click(object sender, RoutedEventArgs e)
        {
            double zuwachs = Math.Round(military.FutureSkill(current_skill_amount_2), 2);
            lstEdu.Add("Персонаж " + name_2 + " повысил навык " + TbSkillName3.Text + " на " + (zuwachs - current_skill_amount_2) + " в Военной академии");
            current_skill_amount_2 = zuwachs;
            TbCurrentSkillAmount2.Text = "" + current_skill_amount_2;
            double diff = military.PriceWithSale();
            current_hero_money_2 -= diff;
            TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
            military.Money += diff;
            TbCurrentUniversityMoney3.Text = "" + military.Money;
            ButtonLearn3.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - military.Price)) + 1);
        }

        private void ButtonLearn4_Click(object sender, RoutedEventArgs e)
        {
            double zuwachs = Math.Round(magic.FutureSkill(current_skill_amount_2), 2);
            lstEdu.Add("Персонаж " + name_2 + " повысил навык " + TbSkillName4.Text + " стихии " + magic.TypeSkill + " на " + (zuwachs - current_skill_amount_2) + " в Магической академии");
            current_skill_amount_2 = zuwachs;
            TbCurrentSkillAmount2.Text = "" + current_skill_amount_2;
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
    }
}
