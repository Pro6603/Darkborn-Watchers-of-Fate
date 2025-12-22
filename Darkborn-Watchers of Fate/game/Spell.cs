using System;
using System.Collections.Generic;
using System.Text;

namespace game.Spell
{
    public class Spell
    {
        public string Name;
        public string Description;

        public Spell(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
