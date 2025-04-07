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

        public Inventory()
        {
            items = new List<Item>();
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

        public void PrintALL()
        {
            Console.WriteLine("===소유한 아이템====");
            if(items.Count == 0)
                Console.WriteLine("없음");
            foreach(Item a in items)
                Console.WriteLine("{0}", a.name);
            Console.WriteLine("====================");
        }
    }
}
