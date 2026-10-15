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

            Police police1 = new Police();
            Thief thief1 = new Thief();
            Citizen citizen1 = new Citizen();

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


            // Stadens storlek
            //const int CityWidth = 100;
            //const int CityWith = 25;





        }
    }
}
