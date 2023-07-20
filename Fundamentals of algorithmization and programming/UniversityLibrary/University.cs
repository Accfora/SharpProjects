using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    public class University
    {
        string bukvi = "ЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
        protected string skill; //прокачиваемый навык
        protected int coefficient; //степень прокачивания навыка за курс в процентах
        protected double price; //стоимость курса
        protected double money; //кол-во денег университета
        protected string name; //название университета
        protected int id;
        protected static Random rnd = new Random();
        protected string link;
        public string Skill
        {
            get { return skill; }
            set { skill = value; }
        }
        public int Coefficient
        {
            get { return coefficient; }
            set
            {
                if (value < 10)
                    coefficient = 10;
                else if (value > 200)
                    coefficient = 200;
                else coefficient = value;
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 1)
                    price = 1;
                else price = value;
            }
        }
        public double Money
        {
            get { return money; }
            set 
            {
                if (value < 0)
                    money = 0;
                else money = value;
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Link
        {
            get { return link; }
            set { link = value; }
        }
        public virtual int Id 
        {
            get { return 0; }
        }
        /// <summary>
        /// Метод определяет значение навыка персонажа после изучения курса
        /// </summary>
        /// <returns>Возвращает значение навыка персонажа после изучения курса</returns>
        public virtual double FutureSkill(double current, double multiplier = 1) 
        {
            return current + (current * coefficient * 0.01) * multiplier;
        }
        /// <summary>
        /// Метод определяет стоимость курса со скидкой
        /// </summary>
        /// <returns>Возвращает стоимость курса со скидкой от 5 до 20 процентов (50%, что она будет)</returns>
        public double PriceWithSale()
        {
            return price - (price * (rnd.Next(50, 201) * 0.001 * rnd.Next(0, 2)));
        }
        public double Uspevaemost(double current)
        {
            if (current > 30 & current < 70)
                    return rnd.Next(40,101)*0.01;
            else return rnd.Next(10, 101) * 0.01;
        }
        public double Reaction(double dengi, double uspev)
        {
            if (uspev > 0.4) return dengi;
            else if (uspev < 0.2) return 0; else return uspev * 2 * dengi;
        }
        public virtual string Info()
        {
            return "Университет \"" + name + "\" с " + money + " единиц валюты на счету, стоимостью " + price + " за курс и степенью прокачки навыка " + coefficient + " %";
        }
        public virtual string FullName()
        {
            return "Университет \"" + name + "\"";
        }
        public virtual void ToFormat()
        {
            name = name.Trim();
            while (name.IndexOf("  ") > -1) name = name.Replace("  ", " ");
            name = name.ToLower(); name = " " + name;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ') name = name.Substring(0, i + 1) + ("" + name[i + 1]).ToUpper() + name.Substring(i + 2);
            }
            name = name.Trim();
            int rarinbukvi = rnd.Next(bukvi.Length);
            int rarintext = rnd.Next(name.Length + 1);
            name = name.Substring(0, rarintext) + bukvi[rarinbukvi] + name.Substring(rarintext);
        }
    }
    public class Military : University
    {
        int nagrady; //число наград
        public override int Id
        {
            get { return 1; }
        }
        public int Nagrady
        {
            get { return nagrady; }
            set
            {
                if (value < 0)
                    nagrady = 0;
                else if (value > 15)
                    nagrady = 15;
                else nagrady = value;
            }
        }
        /// <summary>
        /// Метод выдаёт награду
        public void GiveNagrad()
        {
            Nagrady += 1;
        }
        /// <summary>
        /// Метод определяет значение навыка персонажа после изучения курса
        /// </summary>
        /// <returns>Возвращает значение навыка персонажа после изучения курса</returns>
        public override double FutureSkill(double current, double multiplier = 1)
        {
            return current + (current * (coefficient * 0.01 + nagrady * 0.01)) * multiplier;
        }
        public override string Info()
        {
            return "Военная академия \"" + name + "\" с" + nagrady + " наградами с "+money+" единиц валюты на счету, стоимостью " + price + " за курс и степенью прокачки навыка "+coefficient+" %";
        }
        public override string FullName()
        {
            return "Военная академия \"" + name + "\"";
        }
        public override void ToFormat()
        {
            name = name.Trim();
            while (name.IndexOf("  ") > -1) name = name.Replace("  ", " ");
            name = name.ToLower(); name = " " + name;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ') name = name.Substring(0, i + 1) + ("" + name[i + 1]).ToUpper() + name.Substring(i + 2);
            }
            name = name.Trim();
            name = name.ToUpper();
        }
    }
    public class Magic : University
    {
        string typeSkill;
        int level;
        public override int Id
        {
            get { return 2; }
        }
        public string TypeSkill
        {
            get { return typeSkill; }
            set { typeSkill = value; }
        }
        public int Level
        {
            get { return level; }
            set
            {
                if (value < 1)
                    level = 1;
                else if (value > 5)
                    level = 5;
                else level = value;
            }
        }
        public override double FutureSkill(double current, double multiplier = 1)
        {
            return current + (current * (coefficient * 0.01 + (level - 1) * 0.05))* multiplier;
        }
        public override string Info()
        {
            return "Магическая академия \"" + name + "\" " + level + " уровня, стоимостью " + price + " за курс";
        }
        public override string FullName()
        {
            return "Магическая академия \"" + name + "\"";
        }
        public override void ToFormat()
        {
            name = name.Trim();
            while (name.IndexOf("  ") > -1) name = name.Replace("  ", " ");
            string[] Array = name.Split();
            int rarnik = rnd.Next(Array.Length);
            string arb = Array[rarnik];
            Array[rarnik] = new string(Array[rarnik].Reverse().ToArray());
            //Array[rarnik] = Array[rarnik].ToLower(); Array[rarnik] = ("" + Array[rarnik][0]).ToUpper() + Array[rarnik].Substring(1);
            name = String.Join(" ", Array);
            name = name.ToLower(); name = " " + name;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ') name = name.Substring(0, i + 1) + ("" + name[i + 1]).ToUpper() + name.Substring(i + 2);
            }
            name = name.Trim();
        }
    }
}
