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
        public event Action OnDamage;
        public event Action OnDie;
        public Vector2 position;
        public Vector2 targetPos;
        public Inventory inventory;
        public Equipped equipped;
        public bool[,] mapInNPC;
        public Map map;
        private string name;
        private int level;
        private int power;
        public int Power { get { return power; } }
        private int curHP;
        public int CurHP { get { return curHP; } }
        private int maxHP;
        public int MaxHP { get { return maxHP; } }
        private int curEXP;
        public int CurEXP { get { return curEXP; } }
        private int maxEXP;
        public int MaxEXP { get { return maxEXP; } }

        public Player(string name)
        {
            inventory = new Inventory();
            equipped = new Equipped();
            this.name = name;
            level = 1;

            maxHP = 20;
            curHP = maxHP;
            curEXP = 0;
            maxEXP = 15;
            power = 5;
            OnDie += Die;
        }

        public void Heal(int amount)
        {
            curHP += amount;
            if (curHP > maxHP)
                curHP = maxHP;
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
                if (map.map[targetPos.y, targetPos.x] != 0 && map.map[targetPos.y, targetPos.x] != 6 &&
                map.map[targetPos.y, targetPos.x] != 5 && mapInNPC[targetPos.y, targetPos.x] == false)
                {
                    position = targetPos;
                }
            }

                
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
            Console.Write("│ Lv.{0,-2} {1,-6}", level, name);
            Console.SetCursorPosition(x + 15, y + 1);
            Console.WriteLine("│");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("├───┬──────────┤");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("│ HP│");
            int hppercent = (int)((Math.Round((float)curHP / maxHP, 1)) * 10);
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
            int exppercent = (int)((Math.Round((float)curEXP / maxEXP, 1)) * 10);
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

            if (map.MapType == MapType.마을)
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            else if (map.MapType == MapType.사냥터)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Util.Print(x + 1, y + 7, 20, $"{map.Name}");
            Console.ResetColor();
        }


        public void getExp(int exp)
        {
            curEXP += exp;
            if (curEXP >= maxEXP)
                LevelUp(level);
        }

        public void LevelUp(int level)
        {
            this.level++;
            power += 3;
            maxHP += 15;
            curHP = maxHP;
            curEXP -= maxEXP;
            switch (level)
            {
                case 2:
                    maxEXP = 34;
                    break;
                case 3:
                    maxEXP = 57;
                    break;
                case 4:
                    maxEXP = 92;
                    break;
                case 5:
                    maxEXP = 135;
                    break;
                case 6:
                    maxEXP = 372;
                    break;
                case 7:
                    maxEXP = 560;
                    break;
                case 8:
                    maxEXP = 840;
                    break;
                case 9:
                    maxEXP = 1242;
                    break;
                case 10:
                    maxEXP = 1716;
                    break;
            }
        }

        public void Equip(Equipment equipment)
        {
            if (equipment.Part == Part.무기)
                power += equipment.Ability;
            else
                maxHP += equipment.Ability;
        }

        public void UnEquip(Equipment equipment)
        {
            if (equipment.Part == Part.무기)
                power -= equipment.Ability;
            else
                maxHP -= equipment.Ability;
        }

        public void Hit(int damage)
        {
            curHP -= damage;
            OnDamage?.Invoke();
            if (curHP <= 0)
            {
                OnDie?.Invoke();
            }
        }
        public void Die()
        {
            curEXP -= (int)((float)maxEXP / 10);
            if (curEXP < 0)
                curEXP = 0;
        }
    }

}
