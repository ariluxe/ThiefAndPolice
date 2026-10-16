using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefAndPolice
{
    internal class Events
    {
        public static bool Meeting(City city)
        {
            foreach (Thief thief in city.People.OfType<Thief>())
            {

                foreach(Citizen citizen in city.People.OfType<Citizen>())
                {
                    if (citizen.PositionX == thief.PositionX && citizen.PositionY == thief.PositionY)
                    {
                        thief.Robbery(citizen);
                        Program.CitizensRobbed++;
                        return true;
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
