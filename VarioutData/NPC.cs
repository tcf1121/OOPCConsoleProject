using OOPCConsoleProject.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.VarioutData
{
    public class NPC(string name, Vector2 position)
    {
        //public event Action OnTalk;
        public string Name { get { return name; }}
        private List<string> speech = [];
        public List<string> Speech { get { return speech; } set { speech = value; } }

        public Vector2 Position { get { return position; } }

        public void Addspeech(string speech)
        {
            Speech.Add(speech);
        }
    }
}
