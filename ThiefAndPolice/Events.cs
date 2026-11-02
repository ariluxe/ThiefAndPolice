using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefAndPolice
{
    internal class Events
    {
        public static bool MeetingThief(Place city, Place prison, Place poorhouse, Newsfeed newsFeed)
        {

            bool result = false;

            List<Person> copyCityPeople = new List<Person>(city.People);

            foreach (Thief thief in copyCityPeople.OfType<Thief>())
            {

                foreach (Citizen citizen in copyCityPeople.OfType<Citizen>())
                {
                    if (citizen.X == thief.X && citizen.Y == thief.Y)
                    {
                        if (citizen.Inventory.Count > 0)
                        {
                            thief.Robbery(citizen);
                            newsFeed.AddNews(newsFeed.AnnounceRobbery(thief, citizen));
                            Program.CitizensRobbed++;

                            if (citizen.Inventory.Count == 0)
                            {
                                citizen.X = Random.Shared.Next(0, poorhouse.Width);
                                citizen.Y = Random.Shared.Next(0, poorhouse.Height);
                                city.People.Remove(citizen);
                                poorhouse.People.Add(citizen);
                            }
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        public static bool MeetingPolice(Place city, Place prison, Place poorhouse, Newsfeed newsFeed)
        {
            bool result = false;

            List<Person> copyCityPeople = new List<Person>(city.People);

            foreach (Police police in copyCityPeople.OfType<Police>())
            {

                foreach (Thief thief in copyCityPeople.OfType<Thief>())
                {
                    if (police.X == thief.X && police.Y == thief.Y)
                    {

                        if (police.CatchThief(thief))
                        {
                            newsFeed.AddNews(newsFeed.AnnounceArrest(thief, police));
                            thief.X = Random.Shared.Next(0, prison.Width);
                            thief.Y = Random.Shared.Next(0, prison.Height);

                            prison.People.Add(thief);
                            city.People.Remove(thief);

                            result = true;
                        }
                    }
                }
            }

            return result;
        }
    }
}
