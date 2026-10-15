using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefAndPolice
{
    internal class Person
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public List<Item> Inventory { get; set; }

        public Person()
        {
            PositionY = Random.Shared.Next(0,26);
            PositionX = Random.Shared.Next(0,101);
            Inventory = new List<Item>();
        }

        public void Movement()
        {
            switch (Random.Shared.Next(0, 8))
            {
                case 0:
                    PositionX++;
                    break;
                case 1:
                    PositionY++;
                    break;
                case 2:
                    PositionX--;
                    break;
                case 3:
                    PositionY--;
                    break;
                case 4:
                    PositionX++;
                    PositionY--;
                    break;
                case 5:
                    PositionX--;
                    PositionY--;
                    break;
                case 6:
                    PositionX++;
                    PositionY++;
                    break;
                case 7:
                    PositionX--;
                    PositionY++;
                    break;
            }
        }
    }
}
