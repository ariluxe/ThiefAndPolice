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
                city.DrawCity(city.People);


                city.Movement();
                prison.Movement();
                poorhouse.Movement();

                if (Events.Meeting(city, prison, newsFeed))
                    Thread.Sleep(200);

                Console.WriteLine("Arresterade tjuvar: " + ArrestedThieves);
                Console.WriteLine("Rånade invånare: " + CitizensRobbed);

                newsFeed.printNews();

                
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
