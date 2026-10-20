namespace ThiefAndPolice
{
    internal class Program
    {
        public static int CitizensRobbed = 0;
        public static int ArrestedThieves = 0;

        static void Main(string[] args)
        {
            Console.CursorVisible= false;
            City city = new City(width: 100, height: 25, numberOfPolice: 10, numberOfThieves: 20, numberOfCitizens: 30, name:"Ankeborg");
            Prison prison = new Prison(width: 10, height: 10, name: "Kumlabunkern");
            Poorhouse poorhouse = new Poorhouse(width: 50, height: 10, name: "Fattigstugan");
            Newsfeed newsFeed = new Newsfeed();
            Console.ReadKey();

            while (true)
            {
               

                prison.CheckRelease(city);
                city.DrawCity(city.People);


                city.Movement();
                prison.Movement();
                poorhouse.Movement();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.C:
                            // Action for C key
                            break;
                        case ConsoleKey.T:
                            // Action for T key
                            break;
                        case ConsoleKey.P:
                            // Action for P key
                            break;
                        default:
                            // Handle other keys if necessary
                            break;
                    }
                }

                if (Events.Meeting(city, prison, poorhouse, newsFeed))
                    Thread.Sleep(200);

                Console.WriteLine("Arresterade tjuvar: " + ArrestedThieves);
                Console.WriteLine("Rånade invånare: " + CitizensRobbed);

                newsFeed.printNews();

                
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
