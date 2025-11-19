using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace adonet_db_videogame
{
    public class Videogame
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }
        public int SoftwareHouseId { get; set; }

        public void AddVideogame(Videogame videogame)
        {
            try
            {
                using VideogameManager db = new VideogameManager();
                {
                    SoftwareHouse softwareHouse = db.SoftwareHouses.FirstOrDefault(sf => sf.Id == videogame.SoftwareHouseId);
                    if (softwareHouse == null)
                    {
                        Console.WriteLine("L'id che hai inserito non porta ad'una Software House");
                    }
                    else
                    {
                        db.Add(videogame);
                        db.SaveChanges();
                        db.Dispose();
                        Console.WriteLine("Hai aggiunto un nuovo videogioco!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void SearchVideogameById(int id)
        {
            try
            {
                using VideogameManager db = new VideogameManager();
                {

                    Videogame videogame = db.Videogames.FirstOrDefault(vg => vg.Id == id);
                    db.Dispose();
                    if (videogame == null)
                    {
                        Console.WriteLine("Hai inserito un id non valido");
                    }
                    else
                    {
                        Console.WriteLine("Il gioco che hai selezionato è: " + videogame.Title);
                    }
                   
                 

                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void SearchVideogameByTitle(string GameSearchByTitle)
        {
            try
            {
                using VideogameManager db = new VideogameManager();
                {

                    Videogame videogame = db.Videogames.FirstOrDefault(vg => vg.Title.ToLower().Contains(GameSearchByTitle.ToLower()));
                    if (videogame == null)
                    {
                        Console.WriteLine("Hai inserito un nome non valido");
                    }
                    else
                    {
                        Console.WriteLine("Il gioco che hai selezionato è: " + videogame.Title);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        //private const string STRINGA_DI_CONNESSIONE = "Data Source=localhost;Initial Catalog=DatabaseVideogame;Integrated Security=True;TrustServerCertificate=True";
        public static void DeleteVideogame(long id)   
        {
            //using SqlConnection connection = new SqlConnection(STRINGA_DI_CONNESSIONE);
            try
            {
              //  connection.Open();
              //using  SqlCommand cmd = new SqlCommand("DELETE FROM videogames WHERE id = @id", connection);
              //  cmd.Parameters.Add(new SqlParameter("@id", id));
              //  cmd.ExecuteNonQuery();

                using VideogameManager db = new VideogameManager();
                {
                    Videogame videogame = db.Videogames.FirstOrDefault(vg => vg.Id == id);
                    if (videogame == null)
                    {
                        Console.WriteLine("Non ho trovato nessun videogioco con quell' id");
                    }
                    else
                    {
                        db.Remove(videogame);
                        db.SaveChanges();
                        db.Dispose();
                        Console.WriteLine("Hai eliminato " + videogame.Title);
                    }
                  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
       
    }
}

