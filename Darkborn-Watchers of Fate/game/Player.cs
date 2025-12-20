using System;
using System.Collections.Generic;
using System.Text;
using game.Weapon;

namespace game.Player
{
    internal class randomutil
    {
        public static Random random = new Random();
    }

    public class Player(string name)
    {
        private Random random = new Random();
        public int HP { get; set; } = 100;
        public string Name { get; } = name;

        public int AGE { get; set; } = randomutil.random.Next(46);
    }
}
