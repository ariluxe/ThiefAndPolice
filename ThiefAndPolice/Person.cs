using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace ThiefAndPolice
{
    internal class Person
    {
        private Place city;

        public string Name { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int MovementDirection { get; set; }
        public List<Item> Inventory { get; set; }

        public char Char { get; set; }

        public Person(Place city)
        {
            this.city = city;
            Name =  Random.Shared.Next(0, 10000).ToString();
            PositionY = Random.Shared.Next(0, city.Height);
            PositionX = Random.Shared.Next(0, city.Width);

            MovementDirection = Random.Shared.Next(0, 9);
            Inventory = new List<Item>();
        }

        public void Movement(int xMax, int yMax)
        {
            switch (MovementDirection)
            {
                case 0: //Höger
                    if (PositionX < xMax - 1) { PositionX++; }
                    else { PositionX = 0; }
                    break;
                case 1: //Ner
                    if (PositionY < yMax - 1) { PositionY++; }
                    else { PositionY = 0; }
                    break;
                case 2: //Vänster
                    if (PositionX > 0) { PositionX--; }
                    else { PositionX = xMax - 1; }
                    break;
                case 3://Upp
                    if (PositionY > 0) { PositionY--; }
                    else { PositionY = yMax - 1; }
                    break;
                case 4://HögerUpp
                    if (PositionX < xMax - 1) { PositionX++; }
                    else { PositionX = 0; }
                    if (PositionY > 0) { PositionY--; }
                    else { PositionY = yMax - 1; }
                    break;
                case 5://VänsterUpp
                    if (PositionX > 0) { PositionX--; }
                    else { PositionX = xMax - 1; }
                    if (PositionY > 0) { PositionY--; }
                    else { PositionY = yMax - 1; }
                    break;
                case 6://HögerNer
                    if (PositionX < xMax - 1) { PositionX++; }
                    else { PositionX = 0; }
                    if (PositionY < yMax - 1) { PositionY++; }
                    else { PositionY = 0; }
                    break;
                case 7://VänsterNer
                    if (PositionX > 0) { PositionX--; }
                    else { PositionX = xMax - 1; }
                    if (PositionY < yMax - 1) { PositionY++; }
                    else { PositionY = 0; }
                    break;
                case 8://Stilla
                    break;
            }
        }
    }

    internal class Citizen : Person
    {
        public Citizen(Place city) : base(city)
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
        public DateTime SentenceEndTime { get; set; } // När tjuven får dra
        public Thief(Place city) : base(city)
        {
            Char = 'T';
        }

        public void Robbery(Citizen citizen)
        {
            int itemIndex = Random.Shared.Next(0, citizen.Inventory.Count);
            Inventory.Add(citizen.Inventory[itemIndex]);
            citizen.Inventory.RemoveAt(itemIndex);
        }
    }

    internal class Police : Person
    {
        public Police(Place city) : base(city)
        {
            Char = 'P';
        }

        public void CatchThief(Thief thief)
        {
            if (thief.Inventory.Count >= 1)
            {


                foreach (Item item in thief.Inventory)
                {
                    Inventory.Add(item);

                }

                thief.Inventory.Clear();
            }
            }
        }
}

