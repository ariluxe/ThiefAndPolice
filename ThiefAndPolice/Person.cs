using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace ThiefAndPolice
{
    internal class Person
    {
        private Place city;

        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MovementDirection { get; set; }
        public List<Item> Inventory { get; set; }

        public char Char { get; set; }

        public Person(Place city)
        {
            this.city = city;
            Name = Random.Shared.Next(0, 10000).ToString();
            Y = Random.Shared.Next(0, city.Height);
            X = Random.Shared.Next(0, city.Width);

            MovementDirection = Random.Shared.Next(0, 9);
            Inventory = new List<Item>();
        }

        public void Movement(int xMax, int yMax)
        {
            switch (MovementDirection)
            {
                case 0: //Höger
                    if (X < xMax - 1) { X++; }
                    else { X = 0; }
                    break;
                case 1: //Ner
                    if (Y < yMax - 1) { Y++; }
                    else { Y = 0; }
                    break;
                case 2: //Vänster
                    if (X > 0) { X--; }
                    else { X = xMax - 1; }
                    break;
                case 3://Upp
                    if (Y > 0) { Y--; }
                    else { Y = yMax - 1; }
                    break;
                case 4://HögerUpp
                    if (X < xMax - 1) { X++; }
                    else { X = 0; }
                    if (Y > 0) { Y--; }
                    else { Y = yMax - 1; }
                    break;
                case 5://VänsterUpp
                    if (X > 0) { X--; }
                    else { X = xMax - 1; }
                    if (Y > 0) { Y--; }
                    else { Y = yMax - 1; }
                    break;
                case 6://HögerNer
                    if (X < xMax - 1) { X++; }
                    else { X = 0; }
                    if (Y < yMax - 1) { Y++; }
                    else { Y = 0; }
                    break;
                case 7://VänsterNer
                    if (X > 0) { X--; }
                    else { X = xMax - 1; }
                    if (Y < yMax - 1) { Y++; }
                    else { Y = 0; }
                    break;
                case 8://Stilla
                    break;
            }
        }
    }

    internal class Citizen : Person
    {
        public Citizen(Place city) : base(city)
        {
            Char = 'C';
            Name = Names.getRandomCitizenName();

            Inventory.Add(new Item("Keys"));
            Inventory.Add(new Item("Mobilephone"));
            Inventory.Add(new Item("Money"));
            Inventory.Add(new Item("Watch"));
        }
    }

    internal class Thief : Person
    {
        public DateTime SentenceEndTime { get; set; } // När tjuven får dra
        public Thief(Place city) : base(city)
        {
            Char = 'T';
            Name = Names.getRandomThiefName();
        }

        public void Robbery(Citizen citizen)
        {
            int itemIndex = Random.Shared.Next(0, citizen.Inventory.Count);
            Inventory.Add(citizen.Inventory[itemIndex]);
            citizen.Inventory.RemoveAt(itemIndex);
        }
    }

    internal class Police : Person
    {

        public Police(Place city) : base(city)
        {
            Char = 'P';
            Name = Names.getRandomPoliceName();
        }

        public bool CatchThief(Thief thief)
        {
            if (thief.Inventory.Count >= 1)
            {
                thief.SentenceEndTime = DateTime.Now.AddSeconds(thief.Inventory.Count * 10);

                foreach (Item item in thief.Inventory)
                {
                    Inventory.Add(item);

                }


                thief.Inventory.Clear();

                return true;
            }

            return false;
        }
    }


    internal class Names
    {

        public static string getRandomPoliceName()
        {
            return policeNames[Random.Shared.Next(0, policeNames.Length)];
        }

        public static string getRandomThiefName()
        {
            return thiefNames[Random.Shared.Next(0, thiefNames.Length)];
        }

        public static string getRandomCitizenName()
        {
            return citizenNames[Random.Shared.Next(0, citizenNames.Length)];
        }

        static string[] thiefNames = new string[]
{
    // Maffia & Gangsterklassiker (Film & TV)
    "Corleone",      // Vito/Michael Corleone (Gudfadern)
    "Soprano",       // Tony Soprano (The Sopranos)
    "Montana",       // Tony Montana (Scarface)
    "Goodman",       // Jimmy Conway / Henry Hill-världen (Maffia/Goodfellas)
    "Devito",        // Tommy DeVito (Goodfellas)
    "Capone",        // Al Capone (De omutbara / verklig förlaga)
    "Roth",          // Hyman Roth (Gudfadern II)
    "Shelby",        // Tommy Shelby (Peaky Blinders)
    "Maroni",        // Salvatore Maroni (Batman / Gangster)
    "Falcone",       // Carmine Falcone (Batman / Maffiaboss)

    // Detektiv- & Noir-skurkar / Brottslingar
    "Moriarty",      // Professor James Moriarty (Sherlock Holmes)
    "Keyser",        // Keyser Söze (De misstänkta)
    "Lector",        // Hannibal Lecter (När lammen tystnar)
    "Bates",         // Norman Bates (Psycho)
    "Torrance",      // Jack Torrance (The Shining)

    // Tjuvar, Kupmästare & Gentleman-tjuvar
    "Lupin",         // Arsène Lupin (Maurice Leblanc)
    "Ocean",         // Danny/Debbie Ocean (Ocean's Eleven)
    "Benedict",      // Terry Benedict (Ocean's Eleven)
    "Roper",         // Richard Roper (The Night Manager)
    "Proctor",       // Svindlare och kupmästare i klassisk litteratur

    // Litteratur- & Sagobovar
    "Fagin",         // Fagin (Oliver Twist / Charles Dickens)
    "Sikes",         // Bill Sikes (Oliver Twist)
    "Silver",        // Long John Silver (Skattkammarön)
    "Hook",          // Kapten Krok / Captain Hook (Peter Pan)
    "Robin",         // Robin Hood (Klassisk stråtrövare/fredlös)

    // Rånare, Tarantino & Moderna kultfilmer
    "Pink",          // Mr. Pink (Reservoir Dogs)
    "White",         // Mr. White (Reservoir Dogs)
    "Blonde",        // Mr. Blonde (Reservoir Dogs)
    "Vega",          // Vincent Vega (Pulp Fiction)
    "Winnfield",     // Jules Winnfield (Pulp Fiction)
    "Dillinger",     // John Dillinger (Public Enemies)
    "McCartney",     // Bankrånarklassiker
    "McCauley",      // Neil McCauley (Heat)
    "Shiherlis",     // Chris Shiherlis (Heat)
    "Gittes",        // Chinatown-undervärlden

    // Svenska & Nordiska bovar och skurkar
    "Sickan",        // Charles-Ingvar "Sickan" Jönsson (Jönssonligan)
    "Vanheden",      // Ragnar Vanheden (Jönssonligan)
    "Rocky",         // Dynamit-Harry / Rocky (Jönssonligan / Olsen-banden)
    "Wallentin",     // Wall-Enberg / Wallentin (Jönssonligan)
    "Ljuse",         // Svarta Masken / Nordiska kriminalromaner
    "Krogh",         // Nordiska kriminalhistorier

    // Sci-Fi, Fantasy & Popkultur
    "Vader",         // Darth Vader (Star Wars)
    "Palpatine",     // Kejsare Palpatine (Star Wars)
    "Fett",          // Boba/Jango Fett (Star Wars - prisjägare/undervärlden)
    "Jabba",         // Jabba the Hutt (Star Wars - gängledare)
    "Gruber",        // Hans Gruber (Die Hard)
    "Luthor",        // Lex Luthor (Superman)
    "Gekko",         // Gordon Gekko (Wall Street - finansbov)
    "Potter",        // Voldemort / Mörka sidan
    "Bane"           // Bane (Batman)
};

        static string[] policeNames = new string[]
{
    // Svensk & Nordisk kriminallitteratur
    "Wallander",     // Kurt Wallander (Henning Mankell)
    "Beck",          // Martin Beck (Sjöwall/Wahlöö)
    "Gunvald",       // Gunvald Larsson (Beck)
    "Wisting",       // William Wisting (Jørn Lier Horst)
    "Huss",          // Irene Huss (Helene Tursten)
    "Bäckström",     // Evert Bäckström (Leif GW Persson)
    "Hole",          // Harry Hole (Jo Nesbø)
    "Mörck",         // Carl Mörck (Avdelning Q / Jussi Adler-Olsen)
    "Noren",         // Saga Norén (Bron)
    "Bylund",        // Thomas Andreasson / Sandhamn (Viveca Sten)

    // Brittisk kriminallitteratur & TV
    "Holmes",        // Sherlock Holmes (Arthur Conan Doyle)
    "Poirot",        // Hercule Poirot (Agatha Christie)
    "Marple",        // Miss Marple (Agatha Christie)
    "Morse",         // Kommissarie Morse (Colin Dexter)
    "Barnaby",       // Tom/John Barnaby (Midsomer Murders)
    "Luther",        // John Luther (Luther)
    "Miller",        // Ellie Miller (Broadchurch)
    "Hardy",         // Alec Hardy (Broadchurch)
    "Hastings",      // Ted Hastings (Line of Duty)
    "Arnott",        // Steve Arnott (Line of Duty)

    // Amerikanska film- & TV-klassiker
    "Callahan",      // Harry Callahan (Dirty Harry)
    "McClane",       // John McClane (Die Hard)
    "Columbo",       // Kommissarie Columbo (Columbo)
    "Riggs",         // Martin Riggs (Lethal Weapon)
    "Murtaugh",      // Roger Murtaugh (Lethal Weapon)
    "Crockett",      // Sonny Crockett (Miami Vice)
    "Tubbs",         // Ricardo Tubbs (Miami Vice)
    "Kojak",         // Theo Kojak (Kojak)
    "Foley",         // Axel Foley (Beverly Hills Cop)
    "Popeye",        // Jimmy "Popeye" Doyle (The French Connection)

    // Detektiv- & Noir-klassiker
    "Spade",         // Sam Spade (Riddarfalken från Malta)
    "Marlowe",       // Philip Marlowe (Raymond Chandler)
    "Clouseau",      // Kommissarie Clouseau (Rosa Pantern)
    "Maigret",       // Jules Maigret (Georges Simenon)
    "Dupin",         // C. Auguste Dupin (Edgar Allan Poe)

    // Modernare film, TV & Sci-Fi
    "Mills",         // David Mills (Se7en)
    "Somerset",      // William Somerset (Se7en)
    "Clarice",       // Clarice Starling (När lammen tystnar - FBI)
    "Deckard",       // Rick Deckard (Blade Runner)
    "McNulty",       // Jimmy McNulty (The Wire)
    "Moreland",      // Bunk Moreland (The Wire)
    "Bunk",          // Wima Bunk (The Wire)
    "Voight",        // Hank Voight (Chicago P.D.)
    "Peralta",       // Jake Peralta (Brooklyn Nine-Nine)
    "Diaz",          // Rosa Diaz (Brooklyn Nine-Nine)

    // Klassiska TV-serier & Litteratur
    "Benson",        // Olivia Benson (Law & Order: SVU)
    "Stabler",       // Elliot Stabler (Law & Order: SVU)
    "Bosch",         // Harry Bosch (Michael Connelly)
    "Reacher",       // Jack Reacher (f.d. Militärpolis / Lee Child)
    "Rebus"          // John Rebus (Ian Rankin)
};

        static string[] citizenNames = new string[]
{
    // Pionjärer & Matematikens grundare
    "Turing",        // Alan Turing (Fadern till modern datavetenskap och AI)
    "Lovelace",      // Ada Lovelace (Världens första programmerare)
    "Babbage",       // Charles Babbage (Skaparen av den analytiska maskinen)
    "Boole",         // George Boole (Boolesk algebra)
    "VonNeumann",    // John von Neumann (Von Neumann-arkitekturen)
    "Shannon",       // Claude Shannon (Informationsteorins fader)
    "Wiener",        // Norbert Wiener (Cybernetikens fader)
    "Zuse",          // Konrad Zuse (Skaparen av världens första programmerbara dator, Z3)
    "Atanasoff",     // John Vincent Atanasoff (ABC-datorn)
    "Mauchly",       // John Mauchly (ENIAC)

    // Programspråk & Operativsystem
    "Ritchie",       // Dennis Ritchie (Skapare av C och Unix)
    "Thompson",      // Ken Thompson (Skapare av Unix, B och Go)
    "Gosling",       // James Gosling (Fadern till Java)
    "Stroustrup",    // Bjarne Stroustrup (Skapare av C++)
    "Torvalds",      // Linus Torvalds (Skapare av Linux och Git)
    "Stallman",      // Richard Stallman (GNU-projektet och fri programvara)
    "BernersLee",    // Tim Berners-Lee (Uppfinnare av World Wide Web)
    "Cerf",          // Vint Cerf (Medskapare av TCP/IP och "Internet")
    "Kahn",          // Bob Kahn (Medskapare av TCP/IP)
    "Backus",        // John Backus (Skapare av FORTRAN)

    // Databaser, Algoritmer & Teori
    "Dijkstra",      // Edsger W. Dijkstra (Dijkstras algoritm, strukturerad programmering)
    "Knuth",         // Donald Knuth (The Art of Computer Programming)
    "Hoare",         // C.A.R. Hoare (Quicksort, Hoare-logik)
    "Codd",          // Edgar F. Codd (Relationsdatabasens fader)
    "Rivest",        // Ronald Rivest (RSA-kryptering)
    "Shamir",        // Adi Shamir (RSA-kryptering)
    "Adleman",       // Leonard Adleman (RSA-kryptering)
    "Diffie",        // Whitfield Diffie (Asymmetrisk kryptografi)
    "Hellman",       // Martin Hellman (Diffie-Hellman-nyckelbyte)
    "Lamport",       // Leslie Lamport (LaTeX, distribuerade system)

    // AI, Maskininlärning & Gränssnitt
    "McCarthy",      // John McCarthy (Myntade begreppet AI, LISP)
    "Minsky",        // Marvin Minsky (AI-pionjär vid MIT)
    "Engelbart",     // Douglas Engelbart (Uppfann datormusen)
    "Kay",           // Alan Kay (Objektorienterad programmering, Dynabook)
    "Papert",        // Seymour Papert (LOGO-språket, konstruktivism)
    "Hinton",        // Geoffrey Hinton (Fadern till modern djupinlärning)
    "LeCun",         // Yann LeCun (CNN, djupinlärning)
    "Bengio",        // Yoshua Bengio (AI-pionjär, neuronnät)
    "Feigenbaum",    // Edward Feigenbaum (Expertsystem)
    "Wozniak",       // Steve Wozniak (Skapare av Apple I och II)

    // Tech-ikoner & Hackerkultur
    "Jobs",          // Steve Jobs (Apple)
    "Gates",         // Bill Gates (Microsoft)
    "Allen",         // Paul Allen (Microsoft)
    "Zuckerberg",    // Mark Zuckerberg (Meta / Facebook)
    "Page",          // Larry Page (Google)
    "Brin",          // Sergey Brin (Google)
    "Musk",          // Elon Musk (PayPal, SpaceX, xAI)
    "Bezos",         // Jeff Bezos (Amazon)
    "Mitnick",       // Kevin Mitnick (Klassisk legendarisk hacker)
    "Schneier"       // Bruce Schneier (Säkerhetsexpert och kryptograf)
};
    }
}

