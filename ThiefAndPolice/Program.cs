namespace ThiefAndPolice
{
    internal class Program
    {
        public static int CitizensRobbed = 0;

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
                prison.DrawPrison(prison.People);
                poorhouse.DrawPoorhouse(poorhouse.People);


                city.Movement();
                prison.Movement();
                poorhouse.Movement();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.C:
                            Citizen citizen = new Citizen(city);
                            city.People.Add(citizen);
                            newsFeed.AddNews(newsFeed.AnnounceMoveIn(citizen));
                            break;
                        case ConsoleKey.T:
                            Thief thief = new Thief(city);
                            city.People.Add(new Thief(city));
                            newsFeed.AddNews(newsFeed.AnnounceMoveIn(thief));
                            break;
                        case ConsoleKey.P:
                            Police police = new Police(city);
                            city.People.Add(new Police(city));
                            newsFeed.AddNews(newsFeed.AnnounceMoveIn(police));
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }

                //if (Events.Meeting(city, prison, poorhouse, newsFeed))
                //    Thread.Sleep(200);
                if (Events.MeetingThief(city, prison, poorhouse, newsFeed) || Events.MeetingPolice(city, prison, poorhouse, newsFeed))
                    Thread.Sleep(200);

                city.ThiefTracker();
                Console.WriteLine("Robbed citizens: " + CitizensRobbed);

                newsFeed.printNews();

                
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(100);
            }
        }
    }
}
