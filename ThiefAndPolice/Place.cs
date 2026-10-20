using System.IO.IsolatedStorage;
using System.Threading.Channels;

namespace ThiefAndPolice;


internal class Place
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<Person> People { get; private set; }
    public string Name { get; set; }

    public Place(int width, int height, string name)
    {
        Width = width;
        Height = height;
        Name = name;
        People = new List<Person>();
    }

    public void Movement()
    {
        foreach (Person person in People)
            person.Movement(Width, Height);

             
    }

}

    internal class City : Place
{


    public City(int width, int height, int numberOfPolice, int numberOfThieves, int numberOfCitizens, string name) : base(width, height, name)
    {
        
 
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

   
    public void DrawCity(List<Person> inhabitants)
    {
        char[,] cityGrid = new char[Height, Width];

        for(int row = 0; row < Height; row++)
        {
            for(int col = 0; col < Width; col++)
            {
                cityGrid[row, col] = ' ';
            }
        }
        foreach(Person person in inhabitants)
        {
            cityGrid[person.PositionY, person.PositionX] = person.Char;
        }

        Console.WriteLine("= CITY " + new string('=', Width - 5));
        for (int row = 0; row < Height; row++)
        {
            Console.Write("X");
            for (int col = 0; col < Width; col++)
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
        Console.WriteLine(new string('=', Width+2));
    }
}
internal class Prison : Place
{
    public Prison(int width, int height, string name) : base(width, height, name)
    {
        
    }
}
internal class Poorhouse : Place
{
    public Poorhouse(int width, int height, string name) : base(width, height, name)
    {

    }
}