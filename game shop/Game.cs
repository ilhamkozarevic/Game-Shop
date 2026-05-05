using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game_shop
{
    public class Game
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return Name + " - " + Price.ToString("0.00") + " KM";
        }
    }
}
