namespace ThiefAndPolice
{
    internal class Program
    {
        public static int CitizensRobbed = 0;
        public static int ArrestedThieves = 0;

        static void Main(string[] args)
        {

            City city = new City(width: 100, height: 25, numberOfPolice: 10, numberOfThieves: 20, numberOfCitizens: 30);

            Newsfeed newsFeed = new Newsfeed();

            while (true)
            {
                city.DrawCity(city.People);

                foreach(Person person in city.People)
                {
                    person.Movement(city);                   
                }
                Events.Meeting(city, newsFeed);

                Console.WriteLine("Arresterade tjuvar: " + ArrestedThieves);
                Console.WriteLine("Rånade invånare: " + CitizensRobbed);

                newsFeed.printNews();

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
