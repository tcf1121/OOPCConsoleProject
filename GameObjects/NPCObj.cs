using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.GameObjects
{
    class NPCObj : GameObject
    {
        public string name;
        public string description;
        private NPC npc;
        public NPCObj(NPC npc)
            : base(ConsoleColor.DarkMagenta, '♀', position: npc.Position, false)
        {
            this.npc = npc;
        }

        public override void Interact(Player player)
        {
            //대화 기능 추가
            TextBox.NPCDialog(npc);
        }
    }
}
