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

        public char Char { get; set; }

        public Person()
        {
            PositionY = Random.Shared.Next(0, 26);
            PositionX = Random.Shared.Next(0, 101);
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


        // Subklasser

        internal class Citizen : Person
        {
            public Citizen() : base()
            {
                Char = 'C';
                Inventory.Add(new Item("Keys"));
                Inventory.Add(new Item("Mobilephone"));
                Inventory.Add(new Item("Money"));
                Inventory.Add(new Item("Watch"));
            }
        }


        internal class Thief : Person
        {
            public Thief() : base()
            {
                Char = 'T';

            }

            public void Robbery(Citizen citizen)
            {
                if (citizen.Inventory.Count > 0)
                {
                    int itemIndex = Random.Shared.Next(0, citizen.Inventory.Count);
                    Inventory.Add(citizen.Inventory[itemIndex]);
                    citizen.Inventory.RemoveAt(itemIndex);
                }
            }
        }

        internal class Police : Person
        {
            public Police() : base()
            {
                Char = 'P';
            }

            public void CatchTheif(Thief thief)
            {
                foreach (Item item in thief.Inventory)
                {
                    Inventory.Add(item);
                    
                }

                thief.Inventory.Clear();
            }
        }
    }

