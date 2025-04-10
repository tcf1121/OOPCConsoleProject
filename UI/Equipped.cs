using OOPCConsoleProject.VarioutData;
using OOPCConsoleProject.VarioutData.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.UI
{
    public class Equipped
    {
        private Equipment? head;
        private Equipment? fullbody;
        private Equipment? shoes;
        private Equipment? weapon;
        private Stack<string> stack;
        private int selectIndex;

        public Equipped()
        {
            stack = new Stack<string>();
        }

        public void EquipIt(Equipment equipment, int index)
        {
            switch (equipment.Part)
            {
                case Part.머리:
                    if (head != default)
                        UnEquip(Part.머리);
                    Equip(equipment, index);
                    break;
                case Part.전신:
                    if (fullbody != default)
                        UnEquip(Part.전신);
                    Equip(equipment, index);
                    break;
                case Part.신발:
                    if (shoes != default)
                        UnEquip(Part.신발);
                    Equip(equipment, index);
                    break;
                case Part.무기:
                    if (weapon != default)
                        UnEquip(Part.무기);
                    Equip(equipment, index);
                    break;
            }
        }

        public void UnEquip(Part part)
        {
            switch (part)
            {
                case Part.머리:
                    Game.Player.inventory.Add(head!);
                    head = default;
                    break;
                case Part.전신:
                    Game.Player.inventory.Add(fullbody!);
                    fullbody = default;
                    break;
                case Part.신발:
                    Game.Player.inventory.Add(shoes!);
                    shoes = default;
                    break;
                case Part.무기:
                    Game.Player.inventory.Add(weapon!);
                    weapon = default;
                    break;
            }
        }

        public void Equip(Equipment equipment, int index)
        {
            Game.Player.inventory.RemoveAt(index);
            Game.Player.Equip(equipment);
            switch (equipment.Part)
            {
                case Part.머리:
                    head = equipment;       break;
                case Part.전신:
                    fullbody = equipment;   break;
                case Part.신발:
                    shoes = equipment;      break;
                case Part.무기:
                    weapon = equipment;     break;
            }
        }

        public void Open()
        {
            stack.Push("Menu");
            while (stack.Count > 0)
            {
                switch (stack.Peek())
                {
                    case "Menu":
                        Menu();
                        break;
                    case "UnEquipMenu":
                        UnEquipMenu();
                        break;
                    case "UnEquipCheck":
                        UnEquipCheck();
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
            TextBox.PrintLog(1, "1. 장착 해제");
            TextBox.PrintLog(2, "←BS : 뒤로가기");

            ConsoleKey input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.D1:
                    stack.Push("UnEquipMenu");
                    break;
                case ConsoleKey.Backspace:
                    stack.Pop();
                    break;
                case ConsoleKey.E:
                    stack.Clear();
                    Game.Player.PrintInfo(11, 0);
                    break;
            }
        }

        private void UnEquipMenu()
        {
            TextBox.PrintLog(1, "해제할 부위 선택");
            TextBox.PrintLog(2, "←BS : 뒤로가기");

            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.Backspace)
                stack.Pop();
            else if (input == ConsoleKey.E)
                stack.Clear();
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || 4 < select)
                {
                    Util.PressAnyKey("범위 내의 아이템을 선택");
                }
                else
                {
                    selectIndex = select;
                    stack.Push("UnEquipCheck");
                }
            }
        }

        private void UnEquipCheck()
        {
            switch (selectIndex)
            {

                case 0:
                    if (head == default)
                        Util.PressAnyKey("해제할 아이템이 없습니다.");
                    else
                    {
                        Util.PressAnyKey($"{head.Name}을/를 해제합니다.");
                        UnEquip(Part.머리);
                    }                     
                    break;
                case 1:
                    if (fullbody == default)
                        Util.PressAnyKey("해제할 아이템이 없습니다.");
                    else
                    {
                        Util.PressAnyKey($"{fullbody.Name}을/를 해제합니다.");
                        UnEquip(Part.전신);
                    }
                    break;
                case 2:
                    if (shoes == default)
                        Util.PressAnyKey("해제할 아이템이 없습니다.");
                    else
                    {
                        Util.PressAnyKey($"{shoes.Name}을/를 해제합니다.");
                        UnEquip(Part.신발);
                    }
                    break;
                case 3:
                    if (weapon == default)
                        Util.PressAnyKey("해제할 아이템이 없습니다.");
                    else
                    {
                        Util.PressAnyKey($"{weapon.Name}을/를 해제합니다.");
                        UnEquip(Part.무기);
                    }
                    break;

            }
            stack.Pop();
            stack.Pop();
        }

        private void PrintALL()
        {
            int x = 11;
            int y = 4;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("├───┴──────────┤");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("│=    장비    =│");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("│              │");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("│              │");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("│              │");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("│              │");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("│              │");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("┼──────────────┤");
            Console.SetCursorPosition(x + 2, y + 2);
            Console.WriteLine("1. 머리 : {0}", head ==default? "x":head.Name);
            Console.SetCursorPosition(x + 2, y + 3);
            Console.WriteLine("2. 갑옷 : {0}", fullbody == default ? "x" : fullbody.Name);
            Console.SetCursorPosition(x + 2, y + 4);
            Console.WriteLine("3. 신발 : {0}", shoes == default ? "x" : shoes.Name);
            Console.SetCursorPosition(x + 2, y + 5);
            Console.WriteLine("4. 무기 : {0}", weapon == default ? "x" : weapon.Name);
        }
    }
}
