using System;
using System.Collections.Generic;
using System.Text;
using game.Weapon;
using util.RenderHelper;

namespace game.Player
{
    internal class randomutil
    {
        public static Random random = new Random();
    }

    public class Player(string name)
    {
        private RenderHelper helper = new RenderHelper();
        private int _hp = 100;

        public int HP
        {
            get => _hp;
            set
            {
                if (_hp != value)
                {
                    _hp = value;
                    OnHPChanged();
                }
            }
        }

        public string Name { get; } = name;

        public int AGE { get; set; } = randomutil.random.Next(46);

        private void OnHPChanged()
        {
            helper.RenderHP(this);
        }
    }
}
