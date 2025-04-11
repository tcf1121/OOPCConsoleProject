using OOPCConsoleProject.VarioutData.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.UI
{
    public class Ability
    {
        private int level;
        public int Level { get { return level; } }
        
        private int power;
        public int Power { get { return power; } }
        private int defense;
        public int Defense { get { return defense; } }
        private int speed;
        public int Speed { get { return speed; } }
        private int curHP;
        public int CurHP { get { return curHP; } }
        private int maxHP;
        public int MaxHP { get { return maxHP; } }
        private int curEXP;
        public int CurEXP { get { return curEXP; } }
        private int maxEXP;
        public int MaxEXP { get { return maxEXP; } }

        private Stack<string> stack;
        private int selectIndex;
        private int haveAp;
        private int curhaveAp;
        private int upAp;
        private int chooseOX;

        private int upPower;
        private int upDefense;
        private int upMaxHp;
        private int upSpeed;

        private Random random;
        public Ability()
        {
            stack = new Stack<string>();
            random = new();
            level = 1;
            maxHP = 50;
            curHP = maxHP;
            power = 2;
            defense = 2;
            speed = 1;
            curEXP = 0;
            maxEXP = 15;
            haveAp = 0;

        }

        public void Heal(int amount)
        {
            curHP += amount;
            if (curHP > maxHP)
                curHP = maxHP;
        }

        public void GetExp(int exp)
        {
            curEXP += exp;
            if (curEXP >= maxEXP)
                LevelUp(level);
        }

        public void LevelUp(int level)
        {
            this.level++;
            power += 4;
            maxHP += random.Next(12,17);
            haveAp += 5;
            curhaveAp = haveAp;
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
            switch (equipment.Part)
            {
                case Part.머리:
                    maxHP += equipment.Ability;
                    break;
                case Part.전신:
                    defense += equipment.Ability;
                    break;
                case Part.신발:
                    speed += equipment.Ability;
                    break;
                case Part.무기:
                    power += equipment.Ability;
                    break;
            }
        }

        public void UnEquip(Equipment equipment)
        {
            switch (equipment.Part)
            {
                case Part.머리:
                    maxHP -= equipment.Ability;
                    break;
                case Part.전신:
                    defense -= equipment.Ability;
                    break;
                case Part.신발:
                    speed -= equipment.Ability;
                    break;
                case Part.무기:
                    power -= equipment.Ability;
                    break;
            }
        }

        public void Hit(int damage)
        {
            curHP -= damage;
            if (curHP < 0)
                curHP = 0;
        }

        public void Die()
        {
            curEXP -= (int)((float)maxEXP / 10);
            if (curEXP < 0)
                curEXP = 0;
        }
        public void selectCursor(int selectNum)
        {
            int x = 12;
            int y = 6;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine(" ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine(" ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine(" ");
            Console.SetCursorPosition(x, y - 1 + selectNum);
            Console.WriteLine("▶");
        }

        private void ResetAbility()
        {
            upPower = 0;
            upDefense = 0;
            upMaxHp = 0;
            upSpeed = 0;
            upAp = 0;
        }

        private void UpAbility(int index)
        {
            switch (index)
            {
                case 1: upPower++; break;
                case 2: upDefense++; break;
                case 3: upMaxHp++; break;
                case 4: upSpeed++; break;
            }
        }

        private void DownAbility(int index)
        {
            switch (index)
            {
                case 1: upPower--; break;
                case 2: upDefense--; break;
                case 3: upMaxHp--; break;
                case 4: upSpeed--; break;
            }
        }

        private void DecisionAbility()
        {
            power += upPower;
            defense += upDefense;
            maxHP += upMaxHp;
            speed += upSpeed;
            upPower = 0;
            upDefense = 0;
            upMaxHp = 0;
            upSpeed = 0;
            upAp = 0;
        }


        public void Open()
        {
            stack.Push("Menu");
            selectIndex = 1;
            ResetAbility();
            while (stack.Count > 0)
            {
                switch (stack.Peek())
                {
                    case "Menu":
                        Menu();
                        break;
                    case "EmptyAP":
                        EmptyAP();
                        break;
                    case "APConfirm":
                        APConfirm();
                        break;
                }
            }
            Console.Clear();
            TextBox.PrintUI();
            Game.Player.PrintInfo(11, 0);
            TextBox.Cleartext();
        }



        private void Menu()
        {
            PrintALL();
            selectCursor(selectIndex);

            ConsoleKey input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    selectIndex--;
                    if (selectIndex < 1)
                        selectIndex = 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectIndex++;
                    if (selectIndex > 4)
                        selectIndex = 4;
                    break;
                case ConsoleKey.LeftArrow:
                    if(upAp > 0)
                    {
                        curhaveAp++;
                        upAp--;
                        DownAbility(selectIndex);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (curhaveAp > 0)
                    {
                        upAp++;
                        curhaveAp--;
                        UpAbility(selectIndex);
                    }
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if(haveAp == 0)
                        stack.Push("EmptyAP");
                    else
                    {
                        chooseOX = 1;
                        stack.Push("APConfirm");
                    }   
                        
                    break;
                case ConsoleKey.S:
                    stack.Clear();
                    Game.Player.PrintInfo(11, 0);
                    break;
            }
        }

        private void EmptyAP()
        {
            TextBox.PrintLog(1, "AP가 부족합니다.");
            TextBox.PrintNextText();
            stack.Pop();
        }

        private void APConfirm()
        {
            TextBox.PrintLog(1, $"해당 AP를 올리시겠습니까?");

            TextBox.PrintOX();
            TextBox.selectCursorOX(chooseOX);
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    chooseOX--;
                    if (chooseOX < 1) chooseOX = 1;
                    break;
                case ConsoleKey.RightArrow:
                    chooseOX++;
                    if (chooseOX > 2) chooseOX = 2;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (chooseOX == 1)
                    {
                        haveAp = curhaveAp;
                        DecisionAbility();
                        stack.Pop();
                    }
                    else
                    {
                        stack.Pop();
                    }
                    TextBox.Cleartext();
                    break;
            }
        }

        private void PrintALL()
        {
            int x = 11;
            int y = 4;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("├───┴──────────┤");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("│=    정보    =│");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("│              │      ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("│              │      ");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("│              │      ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("│              │      ");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("│              │      ");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("┴──────────────┤      ");
            Console.SetCursorPosition(x + 2, y + 2);
            Console.WriteLine("힘 : {0}+{1}", power, upPower);
            Console.SetCursorPosition(x + 2, y + 3);
            Console.WriteLine("방어 : {0}+{1}", defense, upDefense);
            Console.SetCursorPosition(x + 2, y + 4);
            Console.WriteLine("체력 : {0}/{1}+{2}", curHP, maxHP, upMaxHp);
            Console.SetCursorPosition(x + 2, y + 5);
            Console.WriteLine("민첩 : {0}+{1}", speed, upSpeed);
            Console.SetCursorPosition(x + 2, y + 6);
            Console.WriteLine("AP : {0}/{1}", curhaveAp, haveAp);
        }
    }
}
