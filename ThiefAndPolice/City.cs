using System.IO.IsolatedStorage;

namespace ThiefAndPolice;

internal class City
{

    //Lista med personer i staden
    public List<Person> People { get; private set; }

    public int CityWidth { get; set; }
    public int CityHeight { get; set; }


    public City(int width, int height, int numberOfPolice, int numberOfThieves, int numberOfCitizens)
    {
        CityWidth = width;
        CityHeight = height;
        People = new List<Person>();
        for(int i = 0; i < numberOfPolice; i++)
        {
            People.Add(new Police(this));
        }

        for(int i = 0; i < numberOfThieves; i++)
        {
            People.Add(new Thief(this));
        }

        for(int i = 0; i < numberOfCitizens; i++)
        {
            People.Add(new Citizen(this));
        }
    }



    public string ToString()
    {
        string result = "Staden innehåller " + People.Count + " personer:\n";
        foreach (var person in People)
        {
            result += person.GetType().Name + "\n";
        }
        return result;
    }

    //Lägg Till Polis
    //public void AddPolice(Police police)
    //{
    //    People.Add(police);
    //}
}