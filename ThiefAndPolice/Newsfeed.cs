using System;
using System.Collections.Generic;
using System.Text;

namespace ThiefAndPolice;

internal class Newsfeed
{
    public List<string> News { get; set; }

    public Newsfeed()
    {
        News = new List<string>();
    }

    public void AddNews(string newsEvent)
    {

        if (News.Count > 4)
        {
            News.RemoveAt(4);
        }

        News.Insert(0, newsEvent);
    }

    public string AnnounceRobbery(Thief thief, Citizen citizen)
    {
        return $"Thief {thief.Name} robbed citizen {citizen.Name}".PadRight(60);
    }

    public string AnnounceArrest(Thief thief, Police police)
    {
        return $"Police {police.Name} arrested the thief {thief.Name}".PadRight(60);
    }
    public string AnnounceMoveIn(Person person)
    {
        switch (person.GetType().Name)
        {
            case "Thief":

                return $"The thief {person.Name} is now back on the streets again.".PadRight(60);
                

            case "Citizen":

                return $"Citizen {person.Name} has moved into the city. Welcome!".PadRight(60);
                

            case "Police":

                return $"Police {person.Name} is now back in the city.".PadRight(60);
               
        }
        return null;
    }
    internal void printNews()
    {
        int i = 1;
        foreach (string s in News)
        {
            Console.WriteLine($"{i}. {s}");
            i++;
        }
    }
}

