using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefAndPolice
{
    internal class Events
    {
        public static bool Meeting(City city, Newsfeed newsFeed)
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
                            Program.CitizensRobbed++;
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
                        police.CatchTheif(thief);
                        newsFeed.AddNews(newsFeed.AnnounceArrest(thief, police));

                        city.Prison.Add(thief);
                        city.People.Remove(thief);
                        Program.ArrestedThieves++;

                        return true;
                    }

                }

            }

            return false;

        }
    }
}
