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
        return $"Tjuven {thief.Name} rånade medborgare {citizen.Name}".PadRight(60);
    }

    public string AnnounceArrest(Thief thief, Police police)
    {
        return $"Polisen {police.Name} arresterarde tjuven {thief.Name}".PadRight(60);
    }
    public string AnnounceMoveIn(Person person)
    {
        switch (person.GetType().Name)
        {
            case "Thief":

                return $"Tjuven gör nu stadens gator osäkra.";
                

            case "Citizen":

                return $"Medborgaren flyttade in i staden. Välkommen!";
                

            case "Police":

                return $"Konstapel är nu i tjänst i staden.";
               
        }
        return null;
    }
    internal void printNews()
    {
        //for ( int i = 0; i < News.Count; i++  ) {
        int i = 1;
        foreach (string s in News)
        {
            Console.WriteLine($"{i}. {s}");
            i++;
        }
    }
}

