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

namespace SomethingWithUniversity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        University university1 = new University();
        string name_2;
        double current_hero_money_2;
        double current_skill_amount_2;
        double beginning;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSave1_Click(object sender, RoutedEventArgs e)
        {
            university1.Skill = TbSkillName1.Text;
            university1.Coefficient = 0.1;
            university1.Price = Convert.ToDouble(TbCoursePrice1.Text);
            university1.Money = Convert.ToDouble(TbCurrentUniversityMoney1.Text);
            ButtonSave2.IsEnabled = true;
            ButtonLearn.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - university1.Price)) + 1);
        }

        private void ButtonSave2_Click(object sender, RoutedEventArgs e)
        {
            name_2 = TbName2.Text;
            current_hero_money_2 = Convert.ToDouble(TbCurrentHeroMoney2.Text);
            current_skill_amount_2 = Convert.ToDouble(TbCurrentSkillAmount2.Text);
            beginning = current_skill_amount_2;
            ButtonLearn.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - university1.Price)) + 1);
        }

        private void ButtonLearn_Click(object sender, RoutedEventArgs e)
        {
            current_skill_amount_2 = Math.Round(university1.FutureSkill(current_skill_amount_2),2);
            TbCurrentSkillAmount2.Text = "" + current_skill_amount_2;
            double diff = university1.PriceWithSale();
            current_hero_money_2 -= diff;
            TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
            university1.Money += diff;
            TbCurrentUniversityMoney1.Text = "" + university1.Money;
            L.Content = "";
            ButtonLearn.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - university1.Price)) + 1);
        }

        private void ButtonProgress_Click(object sender, RoutedEventArgs e)
        {
            L.Content = "Персонаж \"" + TbName2.Text + "\" повысил свой навык \"" + TbSkillName1.Text + "\" на " + (current_skill_amount_2 - beginning);
        }
    }
}
