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
using System.Windows.Shapes;

namespace Prakt11Lab
{
    /// <summary>
    /// Логика взаимодействия для ReadOpisanie.xaml
    /// </summary>
    public partial class ReadOpisanie : Window
    {
        string path = @"";
        Button cl;
        public ReadOpisanie(string name, bool raz, bool workNo)
        {
            InitializeComponent();

            if (name.Length > 3 && name.Substring(name.Length - 4) == ".txt") Path.Text = name.Substring(0, name.Length - 4);
            else Path.Text = name;
            path = @"C:\Users\borod\OneDrive\Рабочий стол\Dust_21-22\Основы алгоритмизации и программирования\Labs\Prakt11Lab\For11_Описания_Университетов\" + name;
            Path.IsEnabled = raz;
            if (!raz)
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    OpText.Text = sr.ReadToEnd();
                }
            }
            if (workNo)
            {
                cl = new Button();
                cl.Width = 100; cl.Height = 23; cl.Content = "ОК";
                cl.VerticalAlignment = VerticalAlignment.Top;
                cl.HorizontalAlignment = HorizontalAlignment.Left;
                cl.Margin = new Thickness(455, 253, 0, 0);
                op_g.Children.Add(cl); op_g.Children.Remove(OpSave);
                OpText.IsEnabled = false;
                cl.Click += Cl;
            }
        }
        private void Cl(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void OpSave_Click(object sender, RoutedEventArgs e)
        {
            Path.Text = Path.Text.Trim(); while (Path.Text.IndexOf("  ") > -1) Path.Text = Path.Text.Replace("  ", " ");
            path = @"C:\Users\borod\OneDrive\Рабочий стол\Dust_21-22\Основы алгоритмизации и программирования\Labs\Prakt11Lab\For11_Описания_Университетов\" + Path.Text + ".txt";
            string op_opisanie = OpText.Text;
            string op_copy = op_opisanie;
            string znOkonch = ".?!";
            string znNoch = ",;";
            string bukvi = "ЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            op_opisanie = op_opisanie.Trim();
            while (op_opisanie.IndexOf("  ") > -1) op_opisanie = op_opisanie.Replace("  ", " ");
            while (op_opisanie.Length > 0 && bukvi.IndexOf(("" + op_opisanie[0]).ToUpper()) == -1 && op_opisanie[0] != '\"')
                op_opisanie = op_opisanie.Substring(1);
            op_opisanie = op_opisanie.Length > 0 ? ("" + op_opisanie[0]).ToUpper() + (op_opisanie.Length > 1 ? op_opisanie.Substring(1) : "") : "";
            for (int i = 0; i < op_opisanie.Length; i++)
            {
                if (znOkonch.IndexOf(op_opisanie[i]) > -1 || znNoch.IndexOf(op_opisanie[i]) > -1)
                {
                    if (op_opisanie[i - 1] == ' ')
                    {
                        op_opisanie = op_opisanie.Substring(0, i - 1) + op_opisanie.Substring(i);
                        i--;
                    }
                    if (i + 1 < op_opisanie.Length && op_opisanie[i + 1] != ' ')
                        op_opisanie = op_opisanie.Substring(0, i + 1) + " " + op_opisanie.Substring(i + 1);
                }
                if (i + 1 < op_opisanie.Length && znOkonch.IndexOf(op_opisanie[i]) > -1)
                {
                    string for_op;
                    for_op = op_opisanie.Substring(0, i + 2) + ("" + op_opisanie[i + 2]).ToUpper();
                    //MessageBox.Show(i + 3 + "  " + op_opisanie.Length);
                    for_op += (i + 3 < op_opisanie.Length) ? op_opisanie.Substring(i + 3) : "";
                    op_opisanie = for_op;
                }
            }
            OpText.Text = op_opisanie;
            if (op_opisanie == "")
            {
                if (op_copy == "")
                    MessageBox.Show("Описание не может остаться пустым!", "Ошибка!");
                else MessageBox.Show("В результате форматирования в описании не осталось символов. Описание не может остаться пустым!", "Ошибка!");
            }
            else
            {
                if (File.Exists(path) && Path.IsEnabled)
                    MessageBox.Show("По какой-то причине файл с таким названием уже существует! Пожлалуйста, переименуйте файл", "Ошибка!");
                else
                {
                    try {
                    if (Path.Text.Trim() == "") path = "";
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        sw.Write(OpText.Text);
                    }
                    //MessageBox.Show("Описание успешно записано в " + path);
                    MainWindow mw = (MainWindow)this.Owner;
                    mw.Pathing = Path.Text + ".txt";
                    mw.for_tb1 = Path.Text + ".txt";
                    mw.ToOpisanie.Content = "Изменить";
                    mw.ToOpisanie.Background = Brushes.LightGray;
                    mw.first_or = false;
                    Close();
                    }
                    catch { MessageBox.Show("Имя файла не заполнено или содержит недопустимые символы", "Погодите-ка.."); }
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mw = (MainWindow)this.Owner;
            if (mw.begin.Children.Contains(mw.ReadOpi)) mw.ReadOpi.IsEnabled = true; 
            if (mw.begin.Children.Contains(mw.cb)) mw.cb.IsEnabled = true;
        }
    }
}
