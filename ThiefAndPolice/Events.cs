using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefAndPolice
{
    internal class Events
    {
        public static bool Meeting(Place city, Place prison, Place poorhouse, Newsfeed newsFeed)
        {
            foreach (Thief thief in city.People.OfType<Thief>())
            {

                foreach (Citizen citizen in city.People.OfType<Citizen>())
                {
                    if (citizen.PositionX == thief.PositionX && citizen.PositionY == thief.PositionY)
                    {
                        if (citizen.Inventory.Count > 0)
                        {
                            thief.Robbery(citizen);
                            newsFeed.AddNews(newsFeed.AnnounceRobbery(thief, citizen));
                            

                            if (citizen.Inventory.Count == 0)
                            {
                                citizen.PositionX = Random.Shared.Next(0, poorhouse.Width);
                                citizen.PositionY = Random.Shared.Next(0, poorhouse.Height);
                                city.People.Remove(citizen);
                                poorhouse.People.Add(citizen);

                            }

                            return true;
                        }
                    }

                }
            }

            foreach (Police police in city.People.OfType<Police>())
            {

                foreach (Thief thief in city.People.OfType<Thief>())
                {
                    if (police.PositionX == thief.PositionX && police.PositionY == thief.PositionY)
                    {

                        if (police.CatchThief(thief))
                        {
                            newsFeed.AddNews(newsFeed.AnnounceArrest(thief, police));
                            thief.PositionX = Random.Shared.Next(0, prison.Width);
                            thief.PositionY = Random.Shared.Next(0, prison.Height);

                            prison.People.Add(thief);
                            city.People.Remove(thief);

                            return true;

                        }
                    }

                }

            }

            return false;

        }
    }
}
