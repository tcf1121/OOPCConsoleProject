using OOPCConsoleProject.UI;
using OOPCConsoleProject.VarioutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.GameObjects
{
    class NPCObj(NPC npc) : GameObject(ConsoleColor.DarkMagenta, '♀', position: npc.Position, false)
    {
        public override void Interact(Player player)
        {
            //대화 기능 추가
            TextBox.NPCDialog(npc);
        }
    }
}
