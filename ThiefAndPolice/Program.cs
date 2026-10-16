namespace ThiefAndPolice
{
    internal class Program
    {
        // Statistik och logg
        static int CitizensRobbed = 0;
        static int ArrestedThieves = 0;
        static List<string> NewsFeed = new List<string>();

        static void Main(string[] args)
        {

            //Skapa Stad
            City city = new City(width: 100, height: 25, numberOfPolice: 10, numberOfThieves: 20, numberOfCitizens: 30);
            // while (true) {
            // city.UpdateMovement();
            // city.UpdateInteractions();
            // city.Render();
            //}

            Police police1 = new Police(city);
            Thief thief1 = new Thief(city);
            Citizen citizen1 = new Citizen(city);

            Console.WriteLine("Invånare inventory: ");
            foreach (Item item in citizen1.Inventory)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("--------------");

            thief1.Robbery(citizen1);

            foreach (Item item in citizen1.Inventory)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("----------------------");
            foreach (Item item in thief1.Inventory)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("------------------------");

            police1.CatchTheif(thief1);
            foreach (Item item in thief1.Inventory)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("---------------------------");
            foreach (Item item in police1.Inventory)
            {
                Console.WriteLine(item.Name);
            }


            while (true)
            {
                city.DrawCity(city.People);

                foreach(Person person in city.People)
                {
                    person.Movement(city);                   
                }
                Console.WriteLine(city.ToString());

                Console.ReadKey();
                Console.Clear();
            }


            // Stadens storlek
            //const int CityWidth = 100;
            //const int CityWith = 25;


        }
    }
}
