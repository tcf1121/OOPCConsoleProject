using OOPCConsoleProject.VarioutData;
using OOPCConsoleProject.VarioutData.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
        private int chooseNum;
        private int chooseOX;

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
                    Game.Player.ability.UnEquip(head!);
                    head = default;
                    break;
                case Part.전신:
                    Game.Player.inventory.Add(fullbody!);
                    Game.Player.ability.UnEquip(fullbody!);
                    fullbody = default;
                    break;
                case Part.신발:
                    Game.Player.inventory.Add(shoes!);
                    Game.Player.ability.UnEquip(shoes!);
                    shoes = default;
                    break;
                case Part.무기:
                    Game.Player.inventory.Add(weapon!);
                    Game.Player.ability.UnEquip(weapon!);
                    weapon = default;
                    break;
            }
        }

        public void Equip(Equipment equipment, int index)
        {
            Game.Player.inventory.RemoveAt(index);
            Game.Player.ability.Equip(equipment);
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

        public void Open()
        {
            stack.Push("Menu");
            selectIndex = 1;
            while (stack.Count > 0)
            {
                switch (stack.Peek())
                {
                    case "Menu":
                        Menu();
                        break;
                    case "ItemInfo":
                        ItemInfo();
                        break;
                    case "EmptyItem":
                        EmptyItem();
                        break;
                    case "UnEquipConfirm":
                        UnEquipConfirm();
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
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    chooseNum = 1;
                    if (GetEquipment(selectIndex) == default)
                        stack.Push("EmptyItem");
                    else
                        stack.Push("ItemInfo");
                    break;
                case ConsoleKey.E:
                    stack.Clear();
                    Game.Player.PrintInfo(11, 0);
                    break;
            }
        }

        private Equipment GetEquipment(int index)
        {
            Equipment? equipment;
            switch (index)
            {
                case 1: equipment = head!; break;
                case 2: equipment = fullbody!; break;
                case 3: equipment = shoes!; break;
                case 4: equipment = weapon!; break;
                default: equipment = default; break;
                    
            }
            return equipment;
        }

        private void EmptyItem()
        {
            TextBox.PrintLog(1, "해당 부위는 비어있습니다.");
            TextBox.PrintNextText();
            stack.Pop();
        }

        private void ItemInfo()
        {
            Equipment equipment = GetEquipment(selectIndex);
            TextBox.PrintLog(1, $"{equipment.Name}");
            TextBox.PrintLog(2, $"{equipment.Description}");

            TextBox.PrintThree("해제", "취소", "");
            TextBox.selectCursorThree(chooseNum);

            ConsoleKey input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    chooseNum--;
                    if (chooseNum < 1) chooseNum = 1;
                    break;
                case ConsoleKey.RightArrow:
                    chooseNum++;
                    if (chooseNum > 2) chooseNum = 2;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (chooseNum == 1)
                    {
                        chooseOX = 1;
                        stack.Push("UnEquipConfirm");
                    }
                    else
                        stack.Pop();
                    TextBox.Cleartext();
                    break;
            }
        }

        private void UnEquipConfirm()
        {
            Equipment equipment = GetEquipment(selectIndex);
            TextBox.PrintLog(1, $"{equipment.Name}을/를 ");
            TextBox.PrintLog(2, "해제하시겠습니까?");

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
                        Util.PressAnyKey($"{equipment.Name}을/를 해제했습니다.");
                        UnEquip((Part)(selectIndex - 1));
                        stack.Pop();
                    }
                    TextBox.Cleartext();
                    stack.Pop();
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
            Console.WriteLine("│=    장비    =│");
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
            Console.WriteLine(" 머리 : {0}", head ==default? "x":head.Name);
            Console.SetCursorPosition(x + 2, y + 3);
            Console.WriteLine(" 갑옷 : {0}", fullbody == default ? "x" : fullbody.Name);
            Console.SetCursorPosition(x + 2, y + 4);
            Console.WriteLine(" 신발 : {0}", shoes == default ? "x" : shoes.Name);
            Console.SetCursorPosition(x + 2, y + 5);
            Console.WriteLine(" 무기 : {0}", weapon == default ? "x" : weapon.Name);
        }
    }
}
