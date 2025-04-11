using OOPCConsoleProject.Scene;
using OOPCConsoleProject.VarioutData.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OOPCConsoleProject.UI
{
    public class Inventory
    {
        private readonly List<Item> items;
        private readonly Stack<string> stack;
        private int selectIndex;
        private int page;
        private int max;
        private int selectNum;
        private int chooseNum;
        private int chooseOX;
        public Inventory()
        {
            items = [];
            stack = new Stack<string>();            
        }
        public void Add(Item item)
        {
            foreach(Item have in items)
            {
                if (have.Name == item.Name)
                    if (have.Reduplication)
                    {
                        have.Count++;
                        return;
                    }                        
            }
            items.Add(item);
        }

        public void Remove(Item item)
        {
            items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }


        public void UseAt(int index)
        {
            items[index].Use();
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
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine(" ");
            Console.SetCursorPosition(x, y - 1 + selectNum);
            Console.WriteLine("▶");
        }

        public void Open()
        {
            stack.Push("Menu");
            selectNum = 1;
            page = 0;
            while(stack.Count > 0)
            {
                switch (stack.Peek())
                {
                    case "Menu":
                        Menu(ref page);
                        break;
                    case "ItemInfo":
                        ItemInfo(selectIndex);
                        break;
                    case "CantItem":
                        EmptyItem();
                        break;
                    case "UseConfirm":
                        UseConfirm();
                        break;
                    case "DropConfirm":
                        DropConfirm();
                        break;
                    
                }
            }
            Console.Clear();
            TextBox.PrintUI();
            Game.Player.PrintInfo(11, 0);
            TextBox.Cleartext();
        }

        private void Menu(ref int page)
        {
            PrintALL(page);
            selectCursor(selectNum);
            ConsoleKey input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    selectNum--;
                    if (selectNum < 1)
                    {
                        if(page == 0)
                            selectNum = 1;
                        else
                        {
                            page--;
                            Menu(ref page);
                            selectNum = 5;
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    selectNum++;
                    if (selectNum > 5)
                    {
                        if (page < (items.Count - 1) / 5)
                        {
                            page++;
                            Menu(ref page);
                            selectNum = 1;
                        }
                        else
                        {   
                            selectNum = 5;
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (page > 0)
                        page--;
                    Menu(ref page);
                    break;
                case ConsoleKey.RightArrow:
                    if (page < (items.Count - 1) / 5)
                        page++;
                    Menu(ref page);
                    break;
                case ConsoleKey.I:
                    stack.Clear();
                    Game.Player.PrintInfo(11, 0);
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    selectIndex = selectNum - 1 + page * 5;
                    if (items.Count < selectIndex + 1)
                        stack.Push("CantItem");
                    else
                    {
                        chooseNum = 1;
                        if (!items[selectIndex].Canuse)
                            chooseNum = 2;
                        stack.Push("ItemInfo");
                    }
                        
                    break;
            }
        }

        private void EmptyItem()
        {
            TextBox.PrintLog(1, "아이템을 선택해주세요.");
            TextBox.PrintNextText();
            stack.Pop();
        }

        private void ItemInfo(int Index)
        {
            StringBuilder text = new StringBuilder();
            text.Append(items[Index].Canuse ? (items[Index].IsEquip ? "착용" : "사용"):"    ");

            
            TextBox.PrintLog(1, $"{items[Index].Name}");
            TextBox.PrintLog(2, $"{items[Index].Description}");
            TextBox.PrintThree(text.ToString(), "버리기", "취소");
            TextBox.selectCursorThree(chooseNum);

            ConsoleKey input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    chooseNum--;
                    if(!items[Index].Canuse && chooseNum < 2)
                        chooseNum = 2;
                    else if (chooseNum < 1) chooseNum = 1;
                    break;
                case ConsoleKey.RightArrow:
                    chooseNum++;
                    if (chooseNum > 3) chooseNum = 3;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    TextBox.Cleartext();
                    if (chooseNum == 1)
                    {
                        chooseOX = 1;
                        stack.Push("UseConfirm");
                    }
                    else if (chooseNum == 2)
                    {
                        chooseOX = 1;
                        stack.Push("DropConfirm");
                    }
                    else
                        stack.Pop();
                    break;
            }
        }
        private void UseConfirm()
        {
            Item selectItem = items[selectIndex];
            TextBox.PrintLog(1, $"{selectItem.Name}을/를 ");
            if(selectItem.IsEquip)
                TextBox.PrintLog(2, "착용하시겠습니까?");
            else
                TextBox.PrintLog(2, "사용하시겠습니까?");

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
                        selectItem.Use();
                        if (selectItem.IsEquip)
                            Util.PressAnyKey($"{selectItem.Name}을/를 착용하였습니다.");
                        else
                            Util.PressAnyKey($"{selectItem.Name}을/를 사용하였습니다.");
                        if (selectItem.Reduplication && selectItem.Count > 1)
                            selectItem.Count--;
                        else
                        {
                            if (selectItem.IsEquip)
                                Game.Player.equipped.EquipIt((Equipment)selectItem, selectIndex);
                            else
                                RemoveAt(selectIndex);
                        }
                        stack.Pop();
                    }
                    TextBox.Cleartext();                  
                    stack.Pop();
                    break;
            }
        }

        private void DropConfirm()
        {
            Item selectItem = items[selectIndex];
            TextBox.PrintLog(1, $"{selectItem.Name}을/를 ");
            TextBox.PrintLog(2, "버리시겠습니까?");

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
                        Util.PressAnyKey($"{selectItem.Name}을/를 버렸습니다.");
                        RemoveAt(selectIndex);
                        stack.Pop();
                    }
                    TextBox.Cleartext();
                    stack.Pop();
                    break;
            }
        }


        private void PrintALL(int page)
        {
            int x = 11;
            int y = 4;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("├───┴──────────┤");
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine("│=  인벤토리  =│");
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
            int num = 1;          
            if (page == items.Count / 5)
                max = items.Count % 5;
            else max = 5;
            for (int i = page * 5; i < page * 5 + 5; i++)
            {
                Console.SetCursorPosition(x + 2, y+2+i);
                if(i < page * 5 + max)
                {
                    if (items[i].Reduplication)
                        Console.WriteLine(" {0} * {1}", items[i].Name, items[i].Count);
                    else
                        Console.WriteLine(" {0}", items[i].Name);
                }
                else
                    Console.WriteLine(" x");
            }
            Console.SetCursorPosition(x+5, y+7);
            Console.WriteLine("{0}─{1}─{2}", page == 0 ? '=' : '←', page + 1, page == (items.Count - 1) / 5 ? '=' : '→');
            
        }
    }
}
