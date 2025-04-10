using OOPCConsoleProject.VarioutData.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.UI
{
    public class Shop
    {
        private readonly List<Item> items;
        private readonly Stack<string> stack;
        private int selectIndex;
        private int page;
        private int max;
        public Shop()
        {
            items = [];
            stack = new Stack<string>();
        }

        public void Open(string want)
        {
            if(want == "Sale")
                stack.Push("Sale");
            else
                stack.Push("Purchase");
            page = 0;
            while (stack.Count > 0)
            {
                switch (stack.Peek())
                {
                    case "Sale":
                        Sale(ref page);
                        break;
                    case "Purchase":
                        Purchase(ref page);
                        break;
                    case "SaleConfirm":
                        SaleConfirm();
                        break;
                    case "DropConfirm":
                        PurchaseConfirm();
                        break;
                }
            }
            Console.Clear();
            TextBox.PrintUI();
            Game.Player.PrintInfo(11, 0);
            TextBox.Cleartext();
        }

        private void Purchase(ref int page)
        {
            // 구매 창
        }

        private void Sale(ref int page)
        {
            // 판매 창
        }

        private void PurchaseConfirm()
        {
            // 구매 확인 창
        }

        private void SaleConfirm()
        {
            // 판매 확인 창
        }

        private void PrintALL(int page)
        {
            int x = 11;
            int y = 4;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("├───┴──────────┤");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("│=    상점    =│");
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
            int num = 1;
            if (page == items.Count / 5)
                max = items.Count % 5;
            else max = 5;
            for (int i = page * 5; i < page * 5 + 5; i++)
            {
                Console.SetCursorPosition(x + 2, y + 2 + i);
                if (i < page * 5 + max)
                {
                    if (items[i].Reduplication)
                        Console.WriteLine("{0}. {1} * {2}", num++, items[i].Name, items[i].Count);
                    else
                        Console.WriteLine("{0}. {1}", num++, items[i].Name);
                }
                else
                    Console.WriteLine("{0}. x", num++);
            }
            Console.SetCursorPosition(x + 5, y + 7);
            Console.WriteLine("{0}─{1}─{2}", page == 0 ? '=' : '←', page + 1, page == (items.Count - 1) / 5 ? '=' : '→');

        }
    }
}
