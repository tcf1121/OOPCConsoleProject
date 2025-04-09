using OOPCConsoleProject.UI;
using OOPCConsoleProject.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPCConsoleProject.VarioutData
{
    public enum ShapeColor
    {
        검정,
        진회,
        회색,
        흰색,
        빨강,
        진빨,
        파랑,
        진파,
        초록,
        진초,
        노랑,
        진노
    }

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
        public ShapeColor[,] shape;

        public List<Item> items;
        public Monster(string name, int level, int hp, int power, int exp)
        {
            Name = name;
            Level = level;
            Maxhp = hp;
            Hp = Maxhp;
            Power = power;
            Exp = exp;
            OnDie += Die;
            items = new List<Item>();
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
            TextBox.PrintLog(2, $"경험치 {Exp}을 얻습니다", ConsoleColor.Blue);
            GetItem();
        }

        public void GetItem()
        {
            Random random = new Random();
            int num;
            int y = 3;
            foreach(Item item in items)
            {
                num = random.Next(item.Probability);
                if (num == item.Probability - 1)
                {
                    Game.Player.inventory.Add(item);
                    TextBox.PrintLog(y, $"{item.Name}을/를 얻습니다", ConsoleColor.Blue);
                    y++;
                }
                    
            }
        }

        public void PrintMonterInfo(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("├──────────────┤");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("│ {1,-6}", level, name);
            Console.SetCursorPosition(x + 15, y + 1);
            Console.WriteLine("│");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("├───┬──────────┤");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("│ HP│");
            int hppercent = (int)(Math.Round((float)Hp / Maxhp, 1) * 10);
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < 10; i++)
            {
                if (i >= hppercent)
                    Console.ResetColor();
                Console.Write(" ");
            }
            Console.ResetColor();
            Console.Write("│");
            Console.SetCursorPosition(x, y + 4);
            Console.Write("└──┴───────────┘");
        }

        public void SetMonsterShape(string name)
        {
            switch (name)
            {
                case "달팽이":
                    shape = new ShapeColor[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {ShapeColor.노랑, ShapeColor.진노, 0, ShapeColor.노랑, ShapeColor.진노, ShapeColor.초록, ShapeColor.초록, ShapeColor.초록, 0, 0 },
                    {ShapeColor.검정, ShapeColor.흰색, 0, ShapeColor.검정, ShapeColor.흰색, ShapeColor.초록, ShapeColor.진초, ShapeColor.진초, ShapeColor.진초, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.진초, ShapeColor.초록, ShapeColor.진초, ShapeColor.초록, ShapeColor.초록, ShapeColor.진초, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.진초, ShapeColor.초록, ShapeColor.초록, ShapeColor.진초, ShapeColor.초록, ShapeColor.진초, 0 },
                    {0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진초, ShapeColor.초록, ShapeColor.초록, ShapeColor.초록, ShapeColor.진초, 0 },
                    {0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진초, ShapeColor.진초, ShapeColor.진초, 0, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진노, 0, 0, 0 }
                    };
                    break;
                case "스포아":
                    shape = new ShapeColor[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, ShapeColor.진노, ShapeColor.노랑, ShapeColor.노랑, 0, 0, 0, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진노, ShapeColor.진노, ShapeColor.진노, 0, 0, 0 },
                    {0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진노, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, 0, 0 },
                    {0, ShapeColor.진노, ShapeColor.진노, ShapeColor.진노, ShapeColor.진노, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, 0, 0 },
                    {0, ShapeColor.진노, ShapeColor.진회, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.진회, ShapeColor.진노, 0, 0 },
                    {0, 0, ShapeColor.흰색, 0, ShapeColor.흰색, 0, ShapeColor.회색, 0, 0, 0 },
                    {0, ShapeColor.진노, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.진노, ShapeColor.진노, 0, 0 }
                    };
                    break;
                case "파란 달팽이":
                    shape = new ShapeColor[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {ShapeColor.노랑, ShapeColor.진노, 0, ShapeColor.노랑, ShapeColor.진노, ShapeColor.파랑, ShapeColor.파랑, ShapeColor.파랑, 0, 0 },
                    {ShapeColor.검정, ShapeColor.흰색, 0, ShapeColor.검정, ShapeColor.흰색, ShapeColor.파랑, ShapeColor.진파, ShapeColor.진파, ShapeColor.진파, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.진파, ShapeColor.파랑, ShapeColor.진파, ShapeColor.파랑, ShapeColor.파랑, ShapeColor.진파, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.진파, ShapeColor.파랑, ShapeColor.파랑, ShapeColor.진파, ShapeColor.파랑, ShapeColor.진파, 0 },
                    {0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진파, ShapeColor.파랑, ShapeColor.파랑, ShapeColor.파랑, ShapeColor.진파, 0 },
                    {0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진파, ShapeColor.진파, ShapeColor.진파, 0, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진노, 0, 0, 0 }
                    };
                    break;
                case "빨간 달팽이":
                    shape = new ShapeColor[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {ShapeColor.노랑, ShapeColor.진노, 0, ShapeColor.노랑, ShapeColor.진노, ShapeColor.빨강, ShapeColor.빨강, ShapeColor.빨강, 0, 0 },
                    {ShapeColor.검정, ShapeColor.흰색, 0, ShapeColor.검정, ShapeColor.흰색, ShapeColor.빨강, ShapeColor.진빨, ShapeColor.진빨, ShapeColor.진빨, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.진빨, ShapeColor.빨강, ShapeColor.진빨, ShapeColor.빨강, ShapeColor.빨강, ShapeColor.진빨, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.진빨, ShapeColor.빨강, ShapeColor.빨강, ShapeColor.진빨, ShapeColor.빨강, ShapeColor.진빨, 0 },
                    {0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진빨, ShapeColor.빨강, ShapeColor.빨강, ShapeColor.빨강, ShapeColor.진빨, 0 },
                    {0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진빨, ShapeColor.진빨, ShapeColor.진빨, 0, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진노, 0, 0, 0 }
                    };
                    break;
                case "슬라임":
                    shape = new ShapeColor[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, ShapeColor.초록, 0, 0, 0 },
                    {0, 0, 0, 0, 0, ShapeColor.노랑, ShapeColor.초록, 0, 0, 0 },
                    {0, 0, 0, 0, ShapeColor.노랑, ShapeColor.진초, ShapeColor.노랑, ShapeColor.초록, 0, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진초, ShapeColor.노랑, ShapeColor.흰색, ShapeColor.노랑, 0, 0 },
                    {0, ShapeColor.노랑, ShapeColor.초록, ShapeColor.진초, ShapeColor.초록, ShapeColor.초록, ShapeColor.노랑, ShapeColor.초록, ShapeColor.초록, 0 },
                    {0, ShapeColor.노랑, ShapeColor.검정, ShapeColor.초록, ShapeColor.초록, ShapeColor.검정, ShapeColor.초록, ShapeColor.진초, ShapeColor.초록, 0 },
                    {0, ShapeColor.초록, ShapeColor.초록, ShapeColor.초록, ShapeColor.초록, ShapeColor.진초, ShapeColor.진초, ShapeColor.초록, ShapeColor.초록, 0 },
                    {0, 0, ShapeColor.초록, ShapeColor.초록, ShapeColor.초록, ShapeColor.초록, ShapeColor.초록, ShapeColor.초록, 0, 0 }
                    };
                    break;
                case "돼지":
                    shape = new ShapeColor[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, ShapeColor.노랑, 0, 0, ShapeColor.노랑, 0, 0, 0, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, 0, 0, 0 },
                    {0, ShapeColor.진노, ShapeColor.진노, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진노, ShapeColor.노랑, ShapeColor.노랑, 0, 0 },
                    {0, ShapeColor.검정, ShapeColor.흰색, ShapeColor.노랑, ShapeColor.검정, ShapeColor.흰색, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, 0 },
                    {ShapeColor.진빨, ShapeColor.빨강, ShapeColor.빨강, ShapeColor.빨강, ShapeColor.검정, ShapeColor.흰색, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, 0 },
                    {ShapeColor.빨강, ShapeColor.진빨, ShapeColor.진빨, ShapeColor.빨강, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.노랑 },
                    {0, 0, ShapeColor.노랑, ShapeColor.진노, 0, 0, 0, ShapeColor.노랑, ShapeColor.진노, 0 }
                    };
                    break;
                case "주황버섯":
                    shape = new ShapeColor[10, 10]
                    {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, ShapeColor.진노, ShapeColor.노랑, ShapeColor.노랑, 0, 0, 0 },
                    {0, 0, 0, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진노, ShapeColor.진노, ShapeColor.진노, 0, 0 },
                    {0, 0, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진노, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, 0 },
                    {0, ShapeColor.진노, ShapeColor.진노, ShapeColor.진노, ShapeColor.진노, ShapeColor.진노, ShapeColor.노랑, ShapeColor.노랑, ShapeColor.진노, ShapeColor.진노 },
                    {0, ShapeColor.진노, ShapeColor.진노, ShapeColor.회색, ShapeColor.회색, ShapeColor.회색, ShapeColor.회색, ShapeColor.진회, ShapeColor.진노, ShapeColor.진노 },
                    {0, 0, ShapeColor.흰색, ShapeColor.검정, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.검정, ShapeColor.회색, ShapeColor.진회, ShapeColor.진노 },
                    {0, 0, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.회색, ShapeColor.진회, 0 },
                    {0, 0, 0, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.흰색, ShapeColor.회색, ShapeColor.진회, 0, 0 }
                    };
                    break;
            }
        }

        public void PrintMonsterShape()
        {
            for(int y = 0; y < 10; y++)
                for(int  x = 0; x < 10; x++)
                {
                    Console.SetCursorPosition(x + 1, y + 1);
                    switch (shape[y, x])
                    {
                        case ShapeColor.검정: Console.BackgroundColor = ConsoleColor.Black; break;
                        case ShapeColor.진회: Console.BackgroundColor = ConsoleColor.DarkGray; break;
                        case ShapeColor.회색: Console.BackgroundColor = ConsoleColor.Gray; break;
                        case ShapeColor.흰색: Console.BackgroundColor = ConsoleColor.White; break;
                        case ShapeColor.빨강: Console.BackgroundColor = ConsoleColor.Red; break;
                        case ShapeColor.진빨: Console.BackgroundColor = ConsoleColor.DarkRed; break;
                        case ShapeColor.파랑: Console.BackgroundColor = ConsoleColor.Blue; break;
                        case ShapeColor.진파: Console.BackgroundColor = ConsoleColor.DarkBlue; break;
                        case ShapeColor.초록: Console.BackgroundColor = ConsoleColor.Green; break;
                        case ShapeColor.진초: Console.BackgroundColor = ConsoleColor.DarkGreen; break;
                        case ShapeColor.노랑: Console.BackgroundColor = ConsoleColor.Yellow; break;
                        case ShapeColor.진노: Console.BackgroundColor = ConsoleColor.DarkYellow; break;

                    }
                    Console.Write(" ");
                }
            Console.ResetColor();

        }

    }
}
