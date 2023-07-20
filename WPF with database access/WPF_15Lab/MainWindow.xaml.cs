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
using Knights;
using DragonLib;
using UniversityLibrary;
using System.ComponentModel;

namespace WPF_15Lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            work = true;
        }

        public List<Knight> lstKnights = new List<Knight>();
        public List<Dragon> lstDragons = new List<Dragon>();
        public List<University> lstUniversities = new List<University>();
        public List<Knight> lstKnightsAtBegin = new List<Knight>();
        public List<Dragon> lstDragonsAtBegin = new List<Dragon>();
        Grid InitCharacter; Grid InitUniversity;
        Label l; CheckBox c;
        private void AddCharacter(object sender, RoutedEventArgs e)
        {
            NewCharacter newCharacter = new NewCharacter();
            newCharacter.Owner = this;
            newCharacter.ShowDialog();
            if ((lstKnights.Count > 0 || lstDragons.Count > 0) && lstUniversities.Count > 0) bLearn.IsEnabled = true;
        }

        private void AddUniversity(object sender, RoutedEventArgs e)
        {
            NewUniversity newUniversity = new NewUniversity();
            newUniversity.Owner = this;
            newUniversity.ShowDialog();
            if ((lstKnights.Count > 0 || lstDragons.Count > 0) && lstUniversities.Count > 0) bLearn.IsEnabled = true;
        }
        private int DefineCharacter(Knight knight)
        {
            try
            {
                Christ christ = (Christ)knight;
                //MessageBox.Show("DefineCharacter: Knight, return 1");
                return 1;
            }
            catch
            {
                try
                {
                    Knight_Of_Ball knight_Of_Ball = (Knight_Of_Ball)knight;
                    //MessageBox.Show("DefineCharacter: Knight, return 2");
                    return 2;
                }
                catch { /*MessageBox.Show("DefineCharacter: Knight, return 0");*/ return 0; }
            }
        }
        private int DefineCharacter(Dragon dragon)
        {
            try
            {
                AirDragon airDragon = (AirDragon)dragon;
                //MessageBox.Show("DefineCharacter: Dragon, return 4");
                return 4;
            }
            catch
            {
                try
                {
                    SeaDragon seaDragon = (SeaDragon)dragon;
                    //MessageBox.Show("DefineCharacter: Dragon, return 5");
                    return 5;
                }
                catch
                {
                    //MessageBox.Show("DefineCharacter: Dragon, return 3");
                    return 3; }
            }
        }
        private string Whos(int n)
        {
            //MessageBox.Show("Whos");
            switch (n)
            {
                case 0:
                    return "Обычный рыцарь";
                case 1:
                    return "Крестоносец";
                case 2:
                    return "Рыцарь круглого стола";
                case 3:
                    return "Обычный дракон";
                case 4:
                    return "Воздушный дракон";
                case 5:
                    return "Морской дракон";
                default: return "";
            }
        }
        ComboBox combo;
        ComboBox box;
        Button doLearn;
        private void bLearn_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("bLearn_Click");
            myw.Height = 580;
            g.Children.Clear();

            InitCharacter = new Grid();
            InitCharacter.HorizontalAlignment = HorizontalAlignment.Left;
            InitCharacter.Height = 433;
            InitCharacter.Margin = new Thickness(30, 30, 0, 0);
            InitCharacter.VerticalAlignment = VerticalAlignment.Top;
            InitCharacter.Width = 356;
            g.Children.Add(InitCharacter);

            InitUniversity = new Grid();
            InitUniversity.HorizontalAlignment = HorizontalAlignment.Left;
            InitUniversity.Height = 433;
            InitUniversity.Margin = new Thickness(30 + 30 + InitCharacter.Width, 30, 0, 0);
            InitUniversity.VerticalAlignment = VerticalAlignment.Top;
            InitUniversity.Width = 356;
            g.Children.Add(InitUniversity);

            combo = new ComboBox();
            foreach(Knight knight in lstKnights)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = Whos(DefineCharacter(knight))+" "+knight.Truename;
                combo.Items.Add(textBlock);
            }
            foreach (Dragon dragon in lstDragons)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = Whos(DefineCharacter(dragon)) + " " + dragon.Name;
                combo.Items.Add(textBlock);
            }
            combo.Margin = new Thickness(10, 10, 0, 0);
            combo.VerticalAlignment = VerticalAlignment.Top;
            combo.HorizontalAlignment = HorizontalAlignment.Left;
            combo.SelectionChanged += combo_SChanged;

            doLearn = new Button();
            doLearn.Content = "Обучиться!";
            doLearn.VerticalAlignment = VerticalAlignment.Bottom;
            doLearn.HorizontalAlignment = HorizontalAlignment.Right;
            doLearn.Margin = new Thickness(0, 0, 18, 10);
            doLearn.Width = 144;
            doLearn.Height = 30;
            doLearn.Click += DoLearn;

            Button toMain = new Button();
            toMain.Content = "На главную";
            toMain.VerticalAlignment = VerticalAlignment.Bottom;
            toMain.HorizontalAlignment = HorizontalAlignment.Left;
            toMain.Margin = new Thickness(30, 0, 0, 20);
            toMain.Width = 144;
            toMain.Height = 30;
            toMain.Click += ToMain;
            g.Children.Add(toMain);

            Button itogs = new Button();
            itogs.Content = "Итоги";
            itogs.VerticalAlignment = VerticalAlignment.Bottom;
            itogs.HorizontalAlignment = HorizontalAlignment.Right;
            itogs.Margin = new Thickness(0, 0, 30, 20);
            itogs.Width = 144;
            itogs.Height = 30;
            itogs.Click += GoingToClose;
            g.Children.Add(itogs);

            //infAboutCharacter.VerticalAlignment = VerticalAlignment.Bottom;
            //infAboutCharacter.HorizontalAlignment = HorizontalAlignment.Left;
            //infAboutCharacter.Margin = new Thickness(10, 0, 0, 10);
            //infAboutCharacter.Height = 70;
            //infAboutCharacter.Width = InitCharacter.Width - 20;
            //infAboutCharacter.TextWrapping = TextWrapping.Wrap;
            //infAboutCharacter.FontStyle = FontStyles.Italic;

            combo.SelectedIndex = 0;
        }
        private void ToMain(object sender, RoutedEventArgs e)
        {
            g.Children.Clear();
            g.Children.Add(g2);
            myw.Height = 450; myw.Width = 800;
        }
        private void GoingToClose(object sender, RoutedEventArgs e)
        {
            myw.Height += 20;
            work = false;

            ForLastThing();
            g.Children.Clear();
            g.Children.Add(InitCharacter);
            myw.Width = 50 + 30 + 356;
            myw.Height = 100 + 30 + 433;
            combo.SelectionChanged += LastThing;

            Button clos = new Button();
            clos.Content = "Спасибо";
            clos.VerticalAlignment = VerticalAlignment.Bottom;
            clos.HorizontalAlignment = HorizontalAlignment.Right;
            clos.Margin = new Thickness(0, 0, 30, 20);
            clos.Width = 144;
            clos.Height = 30;
            clos.Click += Clos;
            g.Children.Add(clos);

            if (combo.SelectedIndex == 0) DoCombo();
            else combo.SelectedIndex = 0;
        }
        private void Clos(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LastThing(object sender, SelectionChangedEventArgs e)
        {
            ForLastThing();
        }
        private void ForLastThing()
        {
            foreach (FrameworkElement fe in InitCharacter.Children)
                if (fe is TextBox)
                {
                    TextBox textBox = (TextBox)fe;
                    textBox.Background = Brushes.White;
                }
        }

        bool IsKnightNow;
        Knight knightNow;
        Dragon dragonNow;
        University universityNow;
        private void RemoveSmthFromBox(ref List<University>lst,int id = -1)
        {
            //MessageBox.Show($"RemoveSmthFromBox: id = {id}\nbox.SelectedIndex = {box.SelectedIndex}");
            box.Items.Clear();
            //MessageBox.Show("Clearing items is passed.");
            foreach (University university in lstUniversities)
            {
                if (university.Id != id)
                {
                    lst.Add(university);
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = university.FullName();
                    box.Items.Add(textBlock);
                }
            }
            //MessageBox.Show($"Items? {box.Items.Count}");
        }
        TextBlock la;
        private void CreateForCombo(ref List<Knight> lstK, ref List<Dragon> lstD)
        {
            //MessageBox.Show($"combo_SChanged");
            InitCharacter.Children.Clear();
            lstTextBox.Clear();
            InitCharacter.Children.Add(combo);

            box = new ComboBox();
            box.Margin = new Thickness(10, 10, 0, 0);
            box.VerticalAlignment = VerticalAlignment.Top;
            box.HorizontalAlignment = HorizontalAlignment.Left;
            box.SelectionChanged += box_SChanged;

            if (combo.SelectedIndex >= lstK.Count)
            {
                IsKnightNow = false;
                dragonNow = lstD[combo.SelectedIndex - lstK.Count];
            }
            else
            {
                IsKnightNow = true;
                knightNow = lstK[combo.SelectedIndex];
            }

            int amountL = 0;
            for (int i = 0; i < 4; i++)
            {
                string[] lT = { "Кол-во денег", "Макс. кол-во ХП", "Текущее кол-во ХП", "Макс. сила атаки" };
                Label l = new Label();
                l.Content = lT[i];
                l.HorizontalAlignment = HorizontalAlignment.Left;
                l.Margin = new Thickness(10, 77 + (i * 37), 0, 0);
                l.VerticalAlignment = VerticalAlignment.Top;
                l.Width = 144;
                amountL++;
                InitCharacter.Children.Add(l);
            }

            if (IsKnightNow)
            {
                InitCharacter.Background = Brushes.SandyBrown;
                if (DefineCharacter(knightNow) == 1)
                {
                    string[] lT = { "Возраст рыцаря", "Возраст артефакта" };
                    for (int i = 0; i < 2; i++)
                    {
                        l = new Label();
                        l.Content = lT[i];
                        l.HorizontalAlignment = HorizontalAlignment.Left;
                        l.Margin = new Thickness(10, 80 + ((4 + i) * 37), 0, 0);
                        l.VerticalAlignment = VerticalAlignment.Top;
                        l.Width = 144;
                        amountL++;
                        InitCharacter.Children.Add(l);
                    }
                }
                if (DefineCharacter(knightNow) == 2)
                {
                    l = new Label();
                    l.Content = "Кол-во походов";
                    l.HorizontalAlignment = HorizontalAlignment.Left;
                    l.Margin = new Thickness(10, 80 + (4 * 37), 0, 0);
                    l.VerticalAlignment = VerticalAlignment.Top;
                    l.Width = 144;
                    amountL++;
                    InitCharacter.Children.Add(l);
                }
            }
            else
            {
                InitCharacter.Background = Brushes.LightPink;
                if (DefineCharacter(dragonNow) == 4)
                {
                    l = new Label();
                    l.Content = "Видимость";
                    l.HorizontalAlignment = HorizontalAlignment.Left;
                    l.Margin = new Thickness(10, 80 + (4 * 37), 0, 0);
                    l.VerticalAlignment = VerticalAlignment.Top;
                    l.Width = 144;
                    InitCharacter.Children.Add(l);
                }

                if (DefineCharacter(dragonNow) == 5)
                {
                    l = new Label();
                    l.Content = "Кол-во морских боёв";
                    l.HorizontalAlignment = HorizontalAlignment.Left;
                    l.Margin = new Thickness(10, 80 + (4 * 37), 0, 0);
                    l.VerticalAlignment = VerticalAlignment.Top;
                    l.Width = 144;
                    amountL++;
                    InitCharacter.Children.Add(l);
                }
            }
            for (int i = 0; i < amountL; i++)
            {
                TextBox t = new TextBox();
                t.HorizontalAlignment = HorizontalAlignment.Left;
                t.Margin = new Thickness(194, 80 + (i * 37), 0, 0);
                t.VerticalAlignment = VerticalAlignment.Top;
                t.Width = 144;
                t.IsReadOnly = true;
                InitCharacter.Children.Add(t); lstTextBox.Add(t);
            }
            if (IsKnightNow)
            {
                lstTextBox[1].Text = "" + Math.Ceiling(knightNow.Max_HP);
                lstTextBox[2].Text = "" + Math.Ceiling(knightNow.Current_HP);
                lstTextBox[3].Text = "" + Math.Ceiling(knightNow.Max_attack);
                lstTextBox[0].Text = "" + Math.Ceiling(knightNow.Money);
                switch (DefineCharacter(knightNow))
                {
                    case 0:
                        break;
                    case 1:
                        Christ christ = (Christ)knightNow;
                        lstTextBox[4].Text = "" + christ.Years;
                        lstTextBox[5].Text = "" + christ.Art_year;
                        break;
                    case 2:
                        Knight_Of_Ball knight_Of_Ball = (Knight_Of_Ball)knightNow;
                        lstTextBox[4].Text = "" + knight_Of_Ball.Pohod;
                        break;
                }
            }
            else
            {
                lstTextBox[1].Text = "" + dragonNow.MaxHealth;
                lstTextBox[2].Text = "" + dragonNow.NowHealth;
                lstTextBox[3].Text = "" + dragonNow.MaxDamage;
                lstTextBox[0].Text = "" + '\u221E';
                switch (DefineCharacter(dragonNow))
                {
                    case 3:
                        break;
                    case 4:
                        AirDragon airDragon = (AirDragon)dragonNow;
                        c = new CheckBox();
                        c.HorizontalAlignment = HorizontalAlignment.Left;
                        c.Margin = new Thickness(194, 80 + (4 * 37), 0, 0);
                        c.VerticalAlignment = VerticalAlignment.Top;
                        c.IsChecked = airDragon.Visibility;
                        c.IsEnabled = false;
                        InitCharacter.Children.Add(c);
                        break;
                    case 5:
                        SeaDragon seaDragon = (SeaDragon)dragonNow;
                        lstTextBox[4].Text = "" + seaDragon.BattleCount;
                        break;
                }
            }
        }
        bool work;
        private void ForWorking()
        {
            lstForWorking.Clear();
            if (!IsKnightNow)
                switch (DefineCharacter(dragonNow))
                {
                    case 3:
                        RemoveSmthFromBox(ref lstForWorking, 1);
                        break;
                    case 4:
                        AirDragon airDragon = (AirDragon)dragonNow;
                        if (!airDragon.Visibility) RemoveSmthFromBox(ref lstForWorking, 1); else RemoveSmthFromBox(ref lstForWorking);
                        break;
                    case 5:
                        SeaDragon seaDragon = (SeaDragon)dragonNow;
                        if (seaDragon.BattleCount < 3) RemoveSmthFromBox(ref lstForWorking, 1); else RemoveSmthFromBox(ref lstForWorking);
                        break;
                }
            else
            {
                switch (DefineCharacter(knightNow))
                {
                    case 0:
                        RemoveSmthFromBox(ref lstForWorking, 2);
                        break;
                    case 1:
                        Christ christ = (Christ)knightNow;
                        if (christ.Art_year <= christ.Years) RemoveSmthFromBox(ref lstForWorking, 2); else RemoveSmthFromBox(ref lstForWorking);
                        break;
                    case 2:
                        Knight_Of_Ball knight_Of_Ball = (Knight_Of_Ball)knightNow;
                        if (knight_Of_Ball.Pohod != 0) RemoveSmthFromBox(ref lstForWorking, 2); else RemoveSmthFromBox(ref lstForWorking);
                        break;
                }
                foreach (University uni in lstUniversities)
                {   
                    if (uni.Id == 2 && ((Magic)uni).Level == 5 && !lstForWorking.Contains(uni))
                    {
                        lstForWorking.Add(uni);
                        TextBlock textBlock = new TextBlock();
                        textBlock.Text = uni.FullName();
                        box.Items.Add(textBlock);
                    }
                }
            }

            if (box.Items.Count > 0)
            {
                //MessageBox.Show("box.Items.Count > 0", "Yes");
                InitUniversity.Children.Remove(la);
                box.SelectedIndex = 0;
            }
            else
            {
                InitUniversity.Children.Clear();
                //MessageBox.Show("(else) !box.Items.Count > 0", "Nothing");
                la = new TextBlock();
                la.Text = "Сожалеем, но для этого персонажа нет подходящих университетов";
                InitUniversity.Background = Brushes.LightGray;
                la.FontSize = 20;
                la.Margin = new Thickness(30, 30, 30, 30);
                la.TextWrapping = TextWrapping.Wrap;
                InitUniversity.Children.Add(la);
            }
        }
        private async void DoCombo()
        {
            if (work)
            {
                CreateForCombo(ref lstKnights, ref lstDragons);
                ForWorking();
            }
            else
            {
                CreateForCombo(ref lstKnightsAtBegin, ref lstDragonsAtBegin);
                await Task.Delay(500);
                if (!IsKnightNow)
                {
                    lstTextBox[1].Text += " + " + ((lstDragons[combo.SelectedIndex - lstKnights.Count].MaxHealth) - dragonNow.MaxHealth);
                    lstTextBox[2].Text += " + " + ((lstDragons[combo.SelectedIndex - lstKnights.Count].NowHealth) - dragonNow.NowHealth);
                    lstTextBox[3].Text += " + " + ((lstDragons[combo.SelectedIndex - lstKnights.Count].MaxDamage) - dragonNow.MaxDamage);
                }
                else
                {
                    lstTextBox[1].Text += " + " + (Math.Ceiling(lstKnights[combo.SelectedIndex].Max_HP) - Math.Ceiling(knightNow.Max_HP));
                    lstTextBox[2].Text += " + " + (Math.Ceiling(lstKnights[combo.SelectedIndex].Current_HP) - Math.Ceiling(knightNow.Current_HP));
                    lstTextBox[3].Text += " + " + (Math.Ceiling(lstKnights[combo.SelectedIndex].Max_attack) - Math.Ceiling(knightNow.Max_attack));
                    lstTextBox[0].Text += " - " + (Math.Ceiling(knightNow.Money) - Math.Ceiling(lstKnights[combo.SelectedIndex].Money));
                }
                await Task.Delay(2000);
                CreateForCombo(ref lstKnights, ref lstDragons);
            }
        }
        private void combo_SChanged(object sender, SelectionChangedEventArgs e)
        {
            DoCombo();
        }
        ComboBox cmbBx;
        List<University> lstForWorking = new List<University>();
        private void box_SChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show($"box_SChanged\nbox.SelectedIndex = {box.SelectedIndex}");
            InitUniversity.Children.Clear();
            lstTextBoxU.Clear();
            InitUniversity.Children.Add(box);
            InitUniversity.Children.Add(doLearn);

            universityNow = lstForWorking[box.SelectedIndex];

            int amountLu = 0;
            for (int i = 0; i < 5; i++)
            {
                string[] lT = { "Название университета", "Текущая сумма денег на счету университета", "Стоимость курса", "Степень прокачки навыка (в %)", "Прокачиваемый навык" };
                TextBlock l = new TextBlock();
                l.Text = lT[i];
                l.HorizontalAlignment = HorizontalAlignment.Left;
                l.Margin = new Thickness(10, 80 + (i * 37), 0, 0);
                l.VerticalAlignment = VerticalAlignment.Top;
                l.Width = 144;
                l.TextWrapping = TextWrapping.Wrap;
                amountLu++;
                InitUniversity.Children.Add(l);
            }
            cmbBx = new ComboBox();
            cmbBx.Margin = new Thickness(194, 80 + (4 * 37), 0, 0);
            cmbBx.VerticalAlignment = VerticalAlignment.Top;
            cmbBx.HorizontalAlignment = HorizontalAlignment.Left;
            cmbBx.SelectionChanged += SkillChanged;
            cmbBx.Width = 144; cmbBx.Height = 20;
            InitUniversity.Children.Add(cmbBx);
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Макс. кол-во ХП";
                cmbBx.Items.Add(textBlock);
            }
            LinearGradientBrush brush = new LinearGradientBrush();
            TextBlock l5;
            TextBox tb5 = new TextBox();
            //MessageBox.Show($"universityNow.Id = {universityNow.Id}");
            switch (universityNow.Id)
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

                    l5 = new TextBlock();
                    l5.VerticalAlignment = VerticalAlignment.Top;
                    l5.HorizontalAlignment = HorizontalAlignment.Left;
                    l5.Margin = new Thickness(10, 80 + (5 * 37), 0, 0);
                    l5.Text = "Число наград";

                    InitUniversity.Children.Add(l5); 
                    amountLu++;

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = "Макс. сила атаки";
                    cmbBx.Items.Add(textBlock);

                    if (DefineCharacter(knightNow) == 1)
                    {
                        Christ christ = (Christ)knightNow;
                        if (christ.Years < 21) cmbBx.Items.RemoveAt(1);
                    }

                    break;
                case 2:
                    brush.GradientStops.Add(new GradientStop(Colors.SkyBlue, 0.05));
                    brush.GradientStops.Add(new GradientStop(Colors.SeaGreen, 0.15));
                    brush.GradientStops.Add(new GradientStop(Colors.SeaGreen, 0.15));
                    brush.GradientStops.Add(new GradientStop(Colors.Orchid, 0.25));

                    l5 = new TextBlock();
                    l5.VerticalAlignment = VerticalAlignment.Top;
                    l5.HorizontalAlignment = HorizontalAlignment.Left;
                    l5.Margin = new Thickness(10, 80 + (5 * 37), 0, 0);
                    l5.Text = "Уровень академии";

                    InitUniversity.Children.Add(l5); 
                    amountLu++;

                    if (((Magic)universityNow).Level == 5)
                    {
                        TextBlock ty = new TextBlock();
                        ty.Text = "Макс. сила атаки";
                        cmbBx.Items.Add(ty);
                    }

                    TextBlock textBlock1 = new TextBlock();
                    textBlock1.Text = "Текущее кол-во ХП";
                    cmbBx.Items.Add(textBlock1);

                    break;
            }
            for (int i = 0; i < amountLu; i++)
            {
                if (i == 4) continue;
                TextBox t = new TextBox();
                t.HorizontalAlignment = HorizontalAlignment.Left;
                t.Margin = new Thickness(194, 80 + (i * 37), 0, 0);
                t.VerticalAlignment = VerticalAlignment.Top;
                t.Width = 144;
                t.IsReadOnly = true;
                InitUniversity.Children.Add(t); lstTextBoxU.Add(t);
            }
            tb5.IsReadOnly = true;
            InitUniversity.Background = brush;
            lstTextBoxU[0].Text = universityNow.Name;
            lstTextBoxU[1].Text = ""+universityNow.Money;
            lstTextBoxU[2].Text = ""+universityNow.Price;
            lstTextBoxU[3].Text = ""+universityNow.Coefficient+"%";
            switch (universityNow.Id)
            {
                case 1:
                    lstTextBoxU.Add(tb5);
                    SetNagrady();
                    break;
                case 2:
                    lstTextBoxU.Add(tb5);
                    lstTextBoxU[4].Text = "" + ((Magic)universityNow).Level;
                    lstTextBoxU[3].Text += ((Magic)universityNow).Level == 1?"": " (+" + ((((Magic)universityNow).Level - 1) * 5) + "%)";
                    break;
            }
            CheckCheck();
            cmbBx.SelectedIndex = 0;
        }
        private void SetNagrady()
        {
            lstTextBoxU[3].Text = "" + universityNow.Coefficient + "%";
            lstTextBoxU[4].Text = "" + ((Military)universityNow).Nagrady;
            lstTextBoxU[3].Text += " (+" + lstTextBoxU[4].Text + "%)";
        }
        List<TextBox> lstTextBox = new List<TextBox>();
        List<TextBox> lstTextBoxU = new List<TextBox>();
        private void CheckCheck()
        {
            if (IsKnightNow)
                if (knightNow.Money >= universityNow.Price)
                {
                    doLearn.IsEnabled = true;
                    lstTextBox[0].Background = Brushes.LimeGreen;
                }
                else
                {
                    doLearn.IsEnabled = false;
                    lstTextBox[0].Background = Brushes.OrangeRed;
                }
            else
            {
                doLearn.IsEnabled = true;
                lstTextBox[0].Background = Brushes.LimeGreen;
            }
        }
        private void SkillChanged (object sender, SelectionChangedEventArgs e)
        {
            CheckCheck();
            switch (((TextBlock)cmbBx.SelectedItem).Text)
            {
                case "Макс. кол-во ХП":
                    lstTextBox[1].Background = Brushes.PaleTurquoise;
                    lstTextBox[2].Background = Brushes.White;
                    lstTextBox[3].Background = Brushes.White;
                    break;
                case "Текущее кол-во ХП":
                    lstTextBox[2].Background = Brushes.PaleTurquoise;
                    lstTextBox[1].Background = Brushes.White;
                    lstTextBox[3].Background = Brushes.White;
                    break;
                case "Макс. сила атаки":
                    lstTextBox[3].Background = Brushes.PaleTurquoise;
                    lstTextBox[2].Background = Brushes.White;
                    lstTextBox[1].Background = Brushes.White;
                    break;
            }
            ChechGold();
        }
        private void ChechGold()
        {
            if (IsKnightNow)
            {
                if (((TextBlock)cmbBx.SelectedItem).Text == "Текущее кол-во ХП" && (knightNow.Current_HP == knightNow.Max_HP))
                {
                    doLearn.IsEnabled = false;
                    lstTextBox[1].Background = Brushes.Gold;
                    lstTextBox[2].Background = Brushes.Gold;
                }
            }
            else
            {
                if (((TextBlock)cmbBx.SelectedItem).Text == "Текущее кол-во ХП" && (dragonNow.NowHealth == dragonNow.MaxHealth))
                {
                    doLearn.IsEnabled = false;
                    lstTextBox[1].Background = Brushes.Gold;
                    lstTextBox[2].Background = Brushes.Gold;
                }
            }
        }
        private void DoLearn (object sender, RoutedEventArgs e)
        {
            if (IsKnightNow)
            {
                switch (((TextBlock)cmbBx.SelectedItem).Text)
                {
                    case "Макс. кол-во ХП":
                        knightNow.Max_HP = Math.Ceiling(universityNow.FutureSkill(knightNow.Max_HP));
                        lstTextBox[1].Text = ""+ knightNow.Max_HP;
                        break;
                    case "Текущее кол-во ХП":
                        double plus = Math.Ceiling(universityNow.FutureSkill(knightNow.Current_HP));
                        if 
                            (plus > knightNow.Max_HP) knightNow.Current_HP = knightNow.Max_HP;
                        else 
                            knightNow.Current_HP = plus;
                        lstTextBox[2].Text = "" + knightNow.Current_HP;
                        break;
                    case "Макс. сила атаки":
                        knightNow.Max_attack = Math.Ceiling(universityNow.FutureSkill(knightNow.Max_attack));
                        lstTextBox[3].Text = "" + knightNow.Max_attack;
                        break;
                }
                knightNow.Money -= universityNow.Price;
                lstTextBox[0].Text = ""+knightNow.Money;
                universityNow.Money += universityNow.Price;
                lstTextBoxU[1].Text = "" + universityNow.Money;
            }
            else
            {
                switch (((TextBlock)cmbBx.SelectedItem).Text)
                {
                    case "Макс. кол-во ХП":
                        dragonNow.MaxHealth = (int)Math.Ceiling(universityNow.FutureSkill(dragonNow.MaxHealth));
                        lstTextBox[1].Text = "" + dragonNow.MaxHealth;
                        break;
                    case "Текущее кол-во ХП":
                        int plus = (int)Math.Ceiling(universityNow.FutureSkill(dragonNow.NowHealth));
                        if (plus > dragonNow.MaxHealth) 
                            dragonNow.NowHealth = dragonNow.MaxHealth;
                        else 
                            dragonNow.NowHealth = plus;
                        lstTextBox[2].Text = "" + dragonNow.NowHealth;
                        break;
                    case "Макс. сила атаки":
                        dragonNow.MaxDamage = (int)Math.Ceiling(universityNow.FutureSkill(dragonNow.MaxDamage));
                        lstTextBox[3].Text = "" + dragonNow.MaxDamage;
                        break;
                }
                universityNow.Money += universityNow.Price;
                lstTextBoxU[1].Text = "" + universityNow.Money;
            }
            if (universityNow.Id == 1)
            {
                ((Military)universityNow).GiveNagrad();
                SetNagrady();
            }
            CheckCheck();
            ChechGold();
        }
    }
}
