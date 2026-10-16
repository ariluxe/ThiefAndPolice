using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace ThiefAndPolice
{
    internal class Person
    {
        private City city;
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int MovementDirection { get; set; }
        //public int MovementDirectionX {get; set; }
        //public int MovementDirectionY {get; set; }
        public List<Item> Inventory { get; set; }

        public char Char { get; set; }

        public Person(City city)
        {
            this.city = city;
            PositionY = Random.Shared.Next(0, city.CityHeight);
            PositionX = Random.Shared.Next(0, city.CityWidth);

            MovementDirection = Random.Shared.Next(0, 9);

            Inventory = new List<Item>();
        }

        public void Movement(City city)
        {
            switch (MovementDirection)
            {
                case 0: //Höger
                    if (PositionX < city.CityWidth-1) { PositionX++; }
                    else { PositionX = 0; }
                    break;
                case 1: //Ner
                    if (PositionY < city.CityHeight-1) { PositionY++; }
                    else { PositionY = 0; }
                    break;
                case 2: //Vänster
                    if (PositionX > 0) { PositionX--; }
                    else { PositionX = city.CityWidth-1; }
                    break;
                case 3://Upp
                    if (PositionY > 0) { PositionY--; }
                    else { PositionY = city.CityHeight - 1; }
                    break;
                case 4://HögerUpp
                    if (PositionX < city.CityWidth - 1) { PositionX++; }
                    else { PositionX = 0; }
                    if (PositionY > 0) { PositionY--; }
                    else { PositionY = city.CityHeight - 1; }
                    break;
                case 5://VänsterUpp
                    if (PositionX > 0) { PositionX--; }
                    else { PositionX = city.CityWidth - 1; }
                    if (PositionY > 0) { PositionY--; }
                    else { PositionY = city.CityHeight - 1; }
                    break;
                case 6://HögerNer
                    if (PositionX < city.CityWidth - 1) { PositionX++; }
                    else { PositionX = 0; }
                    if (PositionY < city.CityHeight - 1) { PositionY++; }
                    else { PositionY = 0; }
                    break;
                case 7://VänsterNer
                    if (PositionX > 0) { PositionX--; }
                    else { PositionX = city.CityWidth - 1; }
                    if (PositionY < city.CityHeight - 1) { PositionY++; }
                    else { PositionY = 0; }
                    break;
                case 8://Stilla
                    break;
            }

            // Kontrollera att personen inte går utanför stadens gränser
            //PositionX = PositionX >= city.CityWidth ? 0 : PositionX;
            //PositionX = PositionX < 0 ? city.CityWidth : PositionX;
            
            //PositionY = PositionY >= city.CityHeight ? 0 : PositionY;
            //PositionY = PositionY < 0 ? city.CityHeight : PositionY;
        }
    }


    // Subklasser

    internal class Citizen : Person
    {
        public Citizen(City city) : base(city)
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
        public Thief(City city) : base(city)
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
        public Police(City city) : base(city)
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

