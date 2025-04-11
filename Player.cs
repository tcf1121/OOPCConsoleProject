using OOPCConsoleProject.GameObjects;
using OOPCConsoleProject.UI;
using OOPCConsoleProject.VarioutData;
using OOPCConsoleProject.VarioutData.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOPCConsoleProject
{
    public class Player
    {
        public event Action? OnDamage;
        public event Action? OnDie;
        public Vector2 position;
        public Vector2 targetPos;
        public Inventory inventory;
        public Equipped equipped;
        public Ability ability;
        public bool[,]? mapInNPC;
        public Map? map;
        private readonly string name;
        private int meso;
        private int Meso { get { return meso; } }
        public Player(string name)
        {
            inventory = new Inventory();
            equipped = new Equipped();
            ability = new Ability();
            this.name = name;  
            meso = 0;
            OnDie += ability.Die;
            inventory.Add(VariousData.ItemDic["검"]);
        }


        public void Print(ConsoleColor color)
        {
            Console.SetCursorPosition(position.x + 1, position.y + 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = color;
            Console.Write("♀");
            Console.ResetColor();
        }

        public void Action(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    Move(input);
                    break;
                case ConsoleKey.I:
                    inventory.Open();
                    break;
                case ConsoleKey.E:
                    equipped.Open();
                    break;
                case ConsoleKey.S:
                    ability.Open();
                    break;
            }
        }

        public void Move(ConsoleKey input)
        {
            targetPos = position;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    targetPos.y--;
                    break;
                case ConsoleKey.DownArrow:
                    targetPos.y++;
                    break;
                case ConsoleKey.LeftArrow:
                    targetPos.x--;
                    break;
                case ConsoleKey.RightArrow:
                    targetPos.x++;
                    break;
            }
            
            if((targetPos.x >= 0 && targetPos.x <10) &&
                (targetPos.y >= 0 && targetPos.y < 10))
            {
                if ((map!.map![targetPos.y, targetPos.x] >= 1 && map.map[targetPos.y, targetPos.x] <= 4)
                    && mapInNPC![targetPos.y, targetPos.x] == false)
                    position = targetPos;
            }

                
        }


        public void GetMeso(int meso)
        {
            this.meso += meso;
        }

        public void UseMeso(int meso)
        {
            this.meso -= meso;
        }

        public void PrintInfo(int x, int y)
        {
            PrintPlayerInfo(x, y);
            PrintMapInfo(x, y);
        }
        public void PrintPlayerInfo(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("┬──────────────┐");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("│ Lv.{0,-2} {1,-6}", ability.Level, name);
            Console.SetCursorPosition(x + 15, y + 1);
            Console.WriteLine("│");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("├───┬──────────┤");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("│ HP│");
            int hppercent = (int)((Math.Round((float)ability.CurHP / ability.MaxHP, 1)) * 10);
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
            Console.Write("├───┼──────────┤");
            Console.SetCursorPosition(x, y + 5);
            Console.Write("│EXP│");
            int exppercent = (int)((Math.Round((float)ability.CurEXP / ability.MaxEXP, 1)) * 10);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < 10; i++)
            {
                if (i >= exppercent)
                    Console.ResetColor();
                Console.Write(" ");
            }
            Console.ResetColor();
            Console.Write("│");
            Console.SetCursorPosition(x, y + 6);
            Console.Write("├───┴──────────┤");
        }

        public void PrintMapInfo(int x, int y)
        {
            
            Console.SetCursorPosition(x, y + 7);
            Console.Write("│              │");
            Console.SetCursorPosition(x, y + 8);
            Console.Write("│              │");
            Console.SetCursorPosition(x, y + 9);
            Console.Write("│              │");
            Console.SetCursorPosition(x, y + 10);
            Console.Write("│              │");
            Console.SetCursorPosition(x, y + 11);
            Console.Write("┴──────────────┤");
            Console.SetCursorPosition(x + 1, y + 7);
            Util.Print(x + 1, y + 7, 20, $"{meso}메소");
            if (map!.MapType == MapType.마을)
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            else if (map.MapType == MapType.사냥터)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Util.Print(x + 1, y + 8, 20, $"{map.Name}");
            Console.ResetColor();
        }

        public void Hit(int damage)
        {
            ability.Hit(damage);
            OnDamage?.Invoke();
            if (ability.CurHP == 0)
            {
                OnDie?.Invoke();
            }
        }
    }

}
