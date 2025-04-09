using OOPCConsoleProject.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject.VarioutData
{
    public class NPC
    {
        private string name;
        public event Action OnTalk;
        public string Name { get { return name; }}
        private List<string> speech = new List<string>();
        public List<string> Speech { get { return speech; } set { speech = value; } }
        private Vector2 position;
        public Vector2 Position { get { return position; } }
        public NPC(string name, Vector2 position)
        {
            this.name = name;
            this.position = position;

        }

        public void Addspeech(string speech)
        {
            Speech.Add(speech);
        }
    }
}
