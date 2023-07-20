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

namespace Prakt9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        University current = new University();
        private void ButtonSave1_Click(object sender, RoutedEventArgs e)
        {
            //TbName1.Text = TbName1.Text.Trim();
            //while (TbName1.Text.IndexOf("  ") > -1) TbName1.Text = TbName1.Text.Replace("  ", " ");
            //TbName1.Text = TbName1.Text.ToLower(); TbName1.Text = " " + TbName1.Text;
            //for (int i = 0; i < TbName1.Text.Length; i++)
            //{
            //    if (TbName1.Text[i] == ' ') TbName1.Text = TbName1.Text.Substring(0, i + 1) + ("" + TbName1.Text[i + 1]).ToUpper() + TbName1.Text.Substring(i + 2);
            //}
            //TbName1.Text = TbName1.Text.Trim();
            switch (cbOption.SelectedIndex)
            {
                case 0:
                    University university = new University();
                    university.Name = TbName1.Text;
                    current = university;
                    break;
                case 1:
                    Military military = new Military();
                    military.Name = TbName1.Text;
                    current = military;
                    break;
                case 2:
                    Magic magic = new Magic();
                    magic.Name = TbName1.Text;
                    current = magic;
                    break;
            }
            //current.Name = current.Name.Trim();
            //while (current.Name.IndexOf("  ") > -1) current.Name = current.Name.Replace("  ", " ");
            //current.Name = current.Name.ToLower(); current.Name = " " + current.Name;
            //for (int i =0; i < current.Name.Length; i++)
            //{
            //    if (current.Name[i] == ' ') current.Name = current.Name.Substring(0, i+1) + ("" + current.Name[i + 1]).ToUpper() + current.Name.Substring(i + 2);
            //}
            //current.Name = current.Name.Trim();

            //switch (cbOption.SelectedIndex)
            //{
            //    case 0:
            //        int rarinbukvi = r.Next(bukvi.Length);
            //        int rarintext = r.Next(current.Name.Length + 1);
            //        current.Name = current.Name.Substring(0, rarintext) + bukvi[rarinbukvi] + current.Name.Substring(rarintext);
            //        break;
            //    case 1:
            //        current.Name = current.Name.ToUpper();
            //        break;
            //    case 2:
            //        string[] Array = current.Name.Split();
            //        int rarnik = r.Next(Array.Length);
            //        string arb = Array[rarnik];
            //        Array[rarnik] = new string(Array[rarnik].Reverse().ToArray());
            //        //Array[rarnik] = Array[rarnik].ToLower(); Array[rarnik] = ("" + Array[rarnik][0]).ToUpper() + Array[rarnik].Substring(1);
            //        current.Name = String.Join(" ", Array);
            //        break;
            //}
            current.ToFormat();
            Labelu.Text = current.FullName();
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

        private void TbName1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbName1.Text.Length > 0) Sform.IsEnabled = true;
            else Sform.IsEnabled = false;
        }

        private void Remeow_Click(object sender, RoutedEventArgs e)
        {
            cbOption.SelectedIndex = 0;
            TbName1.Text = "";
            Labelu.Text = "";
        }
    }
}
