using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject
{
    public class NPC
    {
        private string name;
        public string Name { get; set; }
        private List<string> speech = new List<string>();
        public List<string> Speech { get { return speech; } set { speech = value; } }
        private Vector2 position;
        public Vector2 Position { get { return position; } }
        public NPC(string name, Vector2 position)
        {
            Name = name;
            this.position = position;
        }

        public void Addspeech(string speech)
        {
            Speech.Add(speech);
        }
    }
}
