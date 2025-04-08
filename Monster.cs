using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPCConsoleProject
{
    public class Monster
    {
        public event Action OnDamage;
        public event Action OnDie;

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private int level;
        public int Level { get { return level; } set { level = value; } }

        private int hp;
        public int Hp { get { return hp; } set { hp = value; } }
        private int maxhp;
        public int Maxhp { get { return maxhp; } set { maxhp = value; } }
        private int power;
        public int Power { get { return power; } set { power = value; } }
        private int exp;
        public int Exp { get { return exp; } set { exp = value; } }

        public Monster(string name, int level, int hp, int power, int exp)
        {
            Name = name;
            Level = level;
            Maxhp = hp;
            Hp = Maxhp;
            Power = power;
            Exp = exp;
            OnDie += Die;
        }

        public void Hit(int damage)
        {
            Hp -= damage;
            OnDamage?.Invoke();
            if (Hp < 0)
                OnDie?.Invoke();
        }

        public void Die()
        {
            Console.WriteLine("경험치 {0}을 얻습니다", Exp);
        }

        public void PrintMonterInfo()
        {
            Console.WriteLine("[Lv{0}. {1}]", Level, Name);
            Console.ForegroundColor = ConsoleColor.Red;
            int hppercent = (int)(((float)Hp / Maxhp) * 10);
            for (int i = 0; i < 10; i++)
            {
                if (i < hppercent)
                    Console.Write("■");
                else
                    Console.Write("□");
            }
            Console.ResetColor();
            Console.WriteLine("\n----------------------------------");
        }

    }
}
