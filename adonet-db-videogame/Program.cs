using System.Security.Cryptography.X509Certificates;

namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int UserChoice= 0;
            while (UserChoice != 6) {
                Console.WriteLine("Benvenuto sul sito di GameStop Italia");
                Console.WriteLine("MENU");
                Console.WriteLine("[1] Inserisci un nuovo videogioco");
                Console.WriteLine("[2] Ricerca un videogioco per id");
                Console.WriteLine("[3] Ricerca videogiochi per nome");
                Console.WriteLine("[4] Cancella un videogioco");
                Console.WriteLine("[5] Aggiungi una software house");
                Console.WriteLine("[6] Logout");
                UserChoice = Convert.ToInt32(Console.ReadLine());
                switch (UserChoice)
                {
                    case 1:
                        UserChoice = 0;
                        Console.WriteLine("Inserisci il Titolo");
                        string GameTitle = Console.ReadLine();
                        Console.WriteLine("Di quale Software House fa parte?");
                        int SHId= Convert.ToInt32(Console.ReadLine());
                        Videogame videogame = new Videogame();
                        videogame.AddVideogame(new Videogame() 
                            { 
                                SoftwareHouseId = SHId, 
                                Title = GameTitle 
                            }
                        );
                        break;
                    case 2:
                        UserChoice = 0;
                        Console.WriteLine("Ricerca il videogioco per id");
                        int GameSearch = Convert.ToInt32(Console.ReadLine());
                        Videogame videogame1 = new Videogame();
                        videogame1.SearchVideogameById(GameSearch);

                        break;
                    case 3:
                        UserChoice = 0;
                        Console.WriteLine("Ricerca il videogioco per nome");
                        string GameSearchByTitle = Console.ReadLine();
                        Videogame videogame2 = new Videogame();
                        videogame2.SearchVideogameByTitle(GameSearchByTitle);
                        break;
                    case 4:
                        UserChoice = 0;
                        Console.WriteLine("Inserisci l'id del gioco che vuoi eliminare");
                       int VideogameDel= Convert.ToInt32(Console.ReadLine());
                        Videogame.DeleteVideogame(VideogameDel);
                        break;
                    case 5:
                        UserChoice = 0;
                        Console.WriteLine("Inserisci la Software House");
                        string SHName = Console.ReadLine();
                        SoftwareHouse softwareHouse1= new SoftwareHouse();
                        softwareHouse1.AddSoftwareHouse(new SoftwareHouse() { Name = SHName });
                        Console.WriteLine("Hai aggiunto la Software House: " + SHName);
                        break;
                    case 6:
                        break;
                }
            }
                    
        }
    }
}
