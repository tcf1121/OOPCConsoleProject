using OOPCConsoleProject.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject
{
    public class Inventory
    {
        private List<Item> items;
        private Stack<string> stack;
        private int selectIndex;
        private int page;
        private int max;
        public Inventory()
        {
            items = new List<Item>();
            stack = new Stack<string>();
        }
        public void Add(Item item)
        {
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

        public void Open()
        {
            stack.Push("Menu");
            page = 0;
            while(stack.Count > 0)
            {
                Console.Clear();
                switch (stack.Peek())
                {
                    case "Menu":
                        Menu(ref page);
                        break;
                    case "UseMenu":
                        UseMenu(ref page);
                        break;
                    case "DropMenu":
                        DropMenu(ref page);
                        break;
                    case "UseConfirm":
                        UseConfirm(page);
                        break;
                    case "DropConfirm":
                        DropConfirm(page);
                        break;
                }
            }
        }

        private void Menu(ref int page)
        {
            PrintALL(page);
            Console.WriteLine("1. 사용하기");
            Console.WriteLine("2. 버리기");
            Console.WriteLine("←BS. 뒤로가기");

            ConsoleKey input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.D1:
                    stack.Push("UseMenu");
                    break;
                case ConsoleKey.D2:
                    stack.Push("DropMenu");
                    break;
                case ConsoleKey.Backspace:
                    stack.Pop();
                    break;
                case ConsoleKey.LeftArrow:
                    if (page > 0)
                        page--;
                    Console.Clear();
                    Menu(ref page);
                    break;
                case ConsoleKey.RightArrow:
                    if (page < (items.Count-1) / 5)
                        page++;
                    Console.Clear();
                    Menu(ref page);
                    break;
            }
        }

        private void UseMenu(ref int page)
        {
            PrintALL(page);

            Console.WriteLine("사용할 아이템을 선택해주세요.");
            Console.WriteLine("←BS : 뒤로가기");

            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.Backspace)
                stack.Pop();
            else if (input == ConsoleKey.LeftArrow)
            {
                if (page > 0)
                    page--;
                Console.Clear();
                UseMenu(ref page);
            }
            else if (input == ConsoleKey.RightArrow)
            {
                if (page < (items.Count - 1) / 5)
                    page++;
                Console.Clear();
                UseMenu(ref page);
            }
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || max <= select)
                {
                    Util.PressAnyKey("범위 내의 아이템을 선택하세요.");
                }
                else
                {
                    selectIndex = select + page * 5;
                    stack.Push("UseConfirm");
                }
            }
                
        }

        private void DropMenu(ref int page)
        {
            PrintALL(page);

            Console.WriteLine("버릴 아이템을 선택해주세요.");
            Console.WriteLine("←BS : 뒤로가기");

            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.Backspace)
                stack.Pop();
            else if (input == ConsoleKey.LeftArrow)
            {
                if (page > 0)
                    page--;
                Console.Clear();
                DropMenu(ref page);
            }
            else if (input == ConsoleKey.RightArrow)
            {
                if (page < (items.Count - 1) / 5)
                    page++;
                Console.Clear();
                DropMenu(ref page);
            }
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || max <= select)
                {
                    Util.PressAnyKey("범위 내의 아이템을 선택하세요.");
                }
                else
                {
                    selectIndex = select + page * 5;
                    stack.Push("DropConfirm");
                }
            }
        }

        private void UseConfirm(int page)
        {
            Item selectItem = items[selectIndex];
            Console.WriteLine("{0}을/를 사용하시겠습니까? (y/ n)", selectItem.name);

            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.Y:
                    selectItem.Use();
                    Util.PressAnyKey($"{selectItem.name}을 사용하였습니다.");
                    Remove(selectItem);
                    stack.Pop();
                    break;
                case ConsoleKey.N:
                    stack.Pop();
                    break;
            }
        }

        private void DropConfirm(int page)
        {
            Item selectItem = items[selectIndex];
            Console.WriteLine("{0}을/를 버리시겠습니까? (y/ n)", selectItem.name);

            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.Y:
                    Util.PressAnyKey($"{selectItem.name}을 버렸습니다.");
                    Remove(selectItem);
                    stack.Pop();
                    break;
                case ConsoleKey.N:
                    stack.Pop();
                    break;
            }
        }


        public void PrintALL(int page)
        {
            Console.WriteLine("===소유한 아이템====");
            if(items.Count == 0)
                Console.WriteLine("없음");
            int num = 1;          
            if (page == items.Count / 5)
                max = items.Count % 5;
            else max = 5;
            for (int i = page * 5; i < (page * 5) + 5; i++)
            {
                if(i < (page * 5) + max)
                    Console.WriteLine("{0}. {1}", num++, items[i].name);
                else
                    Console.WriteLine("{0}.  x", num++);
            }
                
            Console.WriteLine("====== {0} {1} {2} ======="
                ,page == 0? '=' : '←', page + 1, page == (items.Count- 1) / 5 ? '=' : '→');
            
        }
    }
}
