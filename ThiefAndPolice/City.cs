using System.IO.IsolatedStorage;

namespace ThiefAndPolice;

internal class City
{

    //Lista med personer i staden
    public List<Person> People { get; private set; }

    public List<Thief> Prison { get; private set; }

    public int CityWidth { get; set; }
    public int CityHeight { get; set; }




    public City(int width, int height, int numberOfPolice, int numberOfThieves, int numberOfCitizens)
    {
        CityWidth = width;
        CityHeight = height;
        People = new List<Person>();
        Prison = new List<Thief>();

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

    public void DrawCity(List<Person> inhabitants)
    {
        char[,] cityGrid = new char[CityHeight, CityWidth];

        for(int row = 0; row < CityHeight; row++)
        {
            for(int col = 0; col < CityWidth; col++)
            {
                cityGrid[row, col] = ' ';
            }
        }
        foreach(Person person in inhabitants)
        {
            cityGrid[person.PositionY, person.PositionX] = person.Char;
        }

        Console.WriteLine("= CITY " + new string('=', CityWidth - 5));
        for (int row = 0; row < CityHeight; row++)
        {
            Console.Write("X");
            for (int col = 0; col < CityWidth; col++)
            {
                char marker = cityGrid[row, col];
                if (marker == 'P') Console.ForegroundColor = ConsoleColor.Blue;
                else if (marker == 'T') Console.ForegroundColor = ConsoleColor.Red;
                else if (marker == 'C') Console.ForegroundColor = ConsoleColor.Green;

                Console.Write(marker);
                Console.ResetColor();
            }
            Console.WriteLine("X");
        }
        Console.WriteLine(new string('=', CityWidth+2));
    }
        
    

    //Lägg Till Polis
    //public void AddPolice(Police police)
    //{
    //    People.Add(police);
    //}
}