using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IA_simbolica.models
{
    public class Robot
    {
        public string Name { get; set; }
        public int Energy { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Robot(string name, int energy, int positionX, int positionY)
        {
            Name = name;
            Energy = energy;
            PositionX = positionX;
            PositionY = positionY;
        }
}
}