using OOPCConsoleProject.UI;
using OOPCConsoleProject.VarioutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.GameObjects
{
    public class ItemBox : GameObject
    {
        public string name;
        public string description;
        private Item item;
        public ItemBox(Vector2 position, Item item)
            : base(ConsoleColor.DarkGray, '▦', position, true)
        {
            this.item = item;
        }

        public override void Interact(Player player)
        {
            Util.PressAnyKey($"{item.Name}을/를 얻었다.");
            player.inventory.Add(item);
        }

    }
}
