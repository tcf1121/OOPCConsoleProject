using OOPCConsoleProject.UI;
using OOPCConsoleProject.VarioutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.GameObjects
{
    public class ShopNPC(NPC npc) : GameObject(ConsoleColor.DarkMagenta, 'Å', position: npc.Position, false)
    {
        // 상점
        public override void Interact(Player player)
        {
            // 상점 열기
        }

        public void AddShop()
        {
            // 상점 연결
        }
    }
}
