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

namespace Prakt5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        University university = new University();
        Military military = new Military();
        Magic magic = new Magic();
        string name_2;
        double current_hero_money_2;
        double current_skill_amount_2;
        double u1; double u3; double u4; //коэффициенты успеваемости
        double diff1; double diff4; double diff3; //оплаты со скидкой
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSave2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                name_2 = TbName2.Text;
                int by0 = 1 / name_2.Length;
                current_hero_money_2 = Convert.ToDouble(TbCurrentHeroMoney2.Text);
                current_skill_amount_2 = Convert.ToDouble(TbCurrentSkillAmount2.Text);
                ButtonSave1.IsEnabled = true; ButtonSave3.IsEnabled = true; ButtonSave4.IsEnabled = true;
                ButtonLearn1.IsEnabled = Convert.ToBoolean((Math.Sign(Convert.ToInt32(current_hero_money_2 - university.Price)) + 1) * university.Price);
                ButtonLearn3.IsEnabled = Convert.ToBoolean((Math.Sign(Convert.ToInt32(current_hero_money_2 - military.Price)) + 1) * military.Price);
                ButtonLearn4.IsEnabled = Convert.ToBoolean((Math.Sign(Convert.ToInt32(current_hero_money_2 - magic.Price)) + 1) * magic.Price);
                if (current_hero_money_2 <= 0)
                {
                    TbCurrentHeroMoney2.Text = "" + 0;
                    current_hero_money_2 = Convert.ToDouble(TbCurrentHeroMoney2.Text);
                }
                if (current_skill_amount_2 < 10)
                {
                    TbCurrentSkillAmount2.Text = "" + 10;
                    current_skill_amount_2 = Convert.ToDouble(TbCurrentSkillAmount2.Text);
                }
                if (current_skill_amount_2 > 100)
                {
                    TbCurrentSkillAmount2.Text = "" + 100;
                    current_skill_amount_2 = Convert.ToDouble(TbCurrentSkillAmount2.Text);
                }
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Некорректное имя!", "Ошибка!");
            }
            catch
            {
                MessageBox.Show("Некорректные данные!", "Ошибка!");
            }
        }

        private void ButtonSave1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                university.Skill = TbSkillName1.Text;
                int by0 = 1 / university.Skill.Length;
                university.Coefficient = Convert.ToDouble(TbPowerSkill1.Text);
                university.Price = Convert.ToDouble(TbCoursePrice1.Text);
                university.Money = Convert.ToDouble(TbCurrentUniversityMoney1.Text);
                if (university.Coefficient <= 0)
                {
                    TbPowerSkill1.Text = "" + 0.1;
                    university.Coefficient = Convert.ToDouble(TbPowerSkill1.Text);
                }
                else if (university.Coefficient > 1)
                {
                    TbPowerSkill1.Text = "" + 1;
                    university.Coefficient = Convert.ToDouble(TbPowerSkill1.Text);
                }
                if (university.Price < 15)
                {
                    TbCoursePrice1.Text = "" + 15;
                    university.Price = Convert.ToDouble(TbCoursePrice1.Text);
                }
                if (university.Money < 0)
                {
                    TbCurrentUniversityMoney1.Text = "" + 0;
                    university.Money = Convert.ToDouble(TbCurrentUniversityMoney1.Text);
                }
                ButtonLearn1.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - university.Price)) + 1);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Некорректное название!", "Ошибка!");
            }
            catch
            {
                MessageBox.Show("Некорректные данные!","Ошибка!");
            }
        }

        private void ButtonSave3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                military.Skill = TbSkillName3.Text;
                int by0 = 1 / military.Skill.Length;
                military.Coefficient = Convert.ToDouble(TbPowerSkill3.Text);
                military.Price = Convert.ToDouble(TbCoursePrice3.Text);
                military.Money = Convert.ToDouble(TbCurrentUniversityMoney3.Text);
                military.Nagrady = Convert.ToInt32(TbNagrady3.Text);
                if (military.Coefficient <= 0)
                {
                    TbPowerSkill3.Text = "" + 0.25;
                    military.Coefficient = Convert.ToDouble(TbPowerSkill3.Text);
                }
                else if (military.Coefficient > 1)
                {
                    TbPowerSkill3.Text = "" + 1;
                    military.Coefficient = Convert.ToDouble(TbPowerSkill3.Text);
                }
                if (military.Price < 20)
                {
                    TbCoursePrice3.Text = "" + 20;
                    military.Price = Convert.ToDouble(TbCoursePrice3.Text);
                }
                if (military.Money < 0)
                {
                    TbCurrentUniversityMoney3.Text = "" + 0;
                    military.Money = Convert.ToDouble(TbCurrentUniversityMoney3.Text);
                }
                if (military.Nagrady < 0)
                {
                    TbNagrady3.Text = "" + 0;
                    military.Nagrady = Convert.ToInt32(TbNagrady3.Text);
                }
                ButtonLearn3.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - military.Price)) + 1);
                nanan.IsEnabled = true;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Некорректное название!", "Ошибка!");
            }
            catch
            {
                MessageBox.Show("Некорректные данные!", "Ошибка!");
            }
        }

        private void ButtonSave4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                magic.Skill = TbSkillName4.Text;
                int by0 = 1 / magic.Skill.Length;
                magic.Coefficient = Convert.ToDouble(TbPowerSkill4.Text);
                magic.Price = Convert.ToDouble(TbCoursePrice4.Text);
                magic.Money = Convert.ToDouble(TbCurrentUniversityMoney4.Text);
                magic.TypeSkill = TbSkillType4.Text;
                int by0_ = 1 / magic.TypeSkill.Length;
                magic.Level = Convert.ToInt32(TbLevel4.Text);
                if (magic.Coefficient <= 0)
                {
                    TbPowerSkill4.Text = "" + 0.5;
                    magic.Coefficient = Convert.ToDouble(TbPowerSkill4.Text);
                }
                else if (magic.Coefficient > 1)
                {
                    TbPowerSkill4.Text = "" + 1;
                    magic.Coefficient = Convert.ToDouble(TbPowerSkill4.Text);
                }
                if (magic.Price < 30)
                {
                    TbCoursePrice4.Text = "" + 30;
                    magic.Price = Convert.ToDouble(TbCoursePrice4.Text);
                }
                if (magic.Money < 0)
                {
                    TbCurrentUniversityMoney4.Text = "" + 0;
                    magic.Money = Convert.ToDouble(TbCurrentUniversityMoney4.Text);
                }
                if (magic.Level < 1 || magic.Level > 5)
                {
                    TbLevel4.Text = "" + 1;
                    magic.Level = Convert.ToInt32(TbLevel4.Text);
                }
                ButtonLearn4.IsEnabled = Convert.ToBoolean(Math.Sign(Convert.ToInt32(current_hero_money_2 - magic.Price)) + 1);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Некорректное название!", "Ошибка!");
            }
            catch
            {
                MessageBox.Show("Некорректные данные!", "Ошибка!");
            }
        }

        private void ButtonLearn1_Click(object sender, RoutedEventArgs e)
        {
            u1 = university.Uspevaemost(current_skill_amount_2);
            double zuwachs = Math.Round(university.FutureSkill(current_skill_amount_2, u1), 2); //изменение навыка
            current_skill_amount_2 = zuwachs;
            TbCurrentSkillAmount2.Text = "" + current_skill_amount_2;
            diff1 = university.PriceWithSale();
            current_hero_money_2 -= diff1;
            TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
            university.Money += diff1;
            TbCurrentUniversityMoney1.Text = "" + university.Money;
            ButtonLearn1.IsEnabled = false;
            ButtonSave1.IsEnabled = false;
            if (u1 < 0.5) ButtonComplain1.IsEnabled = true;
        }

        private void ButtonLearn3_Click(object sender, RoutedEventArgs e)
        {
            u3 = military.Uspevaemost(current_skill_amount_2);
            double zuwachs = Math.Round(military.FutureSkill(current_skill_amount_2, u3), 2);
            current_skill_amount_2 = zuwachs;
            TbCurrentSkillAmount2.Text = "" + current_skill_amount_2;
            diff3 = military.PriceWithSale();
            current_hero_money_2 -= diff3;
            TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
            military.Money += diff3;
            TbCurrentUniversityMoney3.Text = "" + military.Money;
            ButtonLearn3.IsEnabled = false;
            ButtonSave3.IsEnabled = false;
            nanan.IsEnabled = false;
            if (u3 < 0.5) ButtonComplain3.IsEnabled = true;
        }

        private void ButtonLearn4_Click(object sender, RoutedEventArgs e)
        {
            u4 = magic.Uspevaemost(current_skill_amount_2);
            double zuwachs = Math.Round(magic.FutureSkill(current_skill_amount_2, u4), 2);
            current_skill_amount_2 = zuwachs;
            TbCurrentSkillAmount2.Text = "" + current_skill_amount_2;
            diff4 = magic.PriceWithSale();
            current_hero_money_2 -= diff4;
            TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
            magic.Money += diff4;
            TbCurrentUniversityMoney4.Text = "" + magic.Money;
            ButtonLearn4.IsEnabled = false;
            ButtonSave4.IsEnabled = false;
            if (u4 < 0.5) ButtonComplain4.IsEnabled = true;
        }

        private void nanan_Click(object sender, RoutedEventArgs e)
        {
            military.GiveNagrad();
            TbNagrady3.Text = "" + military.Nagrady;
        }

        private void ButtonComplain1_Click(object sender, RoutedEventArgs e)
        {
            double p = Math.Round(university.Reaction(diff1, u1),2);
            if (p == 0) MessageBox.Show("В запросе отказано", "Реакция");
            else
            {
                MessageBox.Show("Удалось вернуть " + p + " из " + diff1 + " рублей", "Реакция");
                current_hero_money_2 += p;
                TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
                university.Money -= p;
                TbCurrentUniversityMoney1.Text = "" + university.Money;
            }
            ButtonComplain1.IsEnabled = false;
        }
        private void ButtonComplain3_Click(object sender, RoutedEventArgs e)
        {
            double p = Math.Round(university.Reaction(diff3, u3),2);
            if (p == 0) MessageBox.Show("В запросе отказано", "Реакция");
            else
            {
                MessageBox.Show("Удалось вернуть " + p + " из " + diff3 + " рублей", "Реакция");
                current_hero_money_2 += p;
                TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
                military.Money -= p;
                TbCurrentUniversityMoney3.Text = "" + military.Money;
            }
            ButtonComplain3.IsEnabled = false;
        }
        private void ButtonComplain4_Click(object sender, RoutedEventArgs e)
        {
            double p = Math.Round(university.Reaction(diff4, u4),2);
            if (p == 0) MessageBox.Show("В запросе отказано", "Реакция");
            else
            {
                MessageBox.Show("Удалось вернуть " + p + " из " + diff4 + " рублей", "Реакция");
                current_hero_money_2 += p;
                TbCurrentHeroMoney2.Text = "" + current_hero_money_2;
                magic.Money -= p;
                TbCurrentUniversityMoney4.Text = "" + magic.Money;
            }
            ButtonComplain4.IsEnabled = false;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

