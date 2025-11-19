using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class SoftwareHouse
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }

        public void AddSoftwareHouse(SoftwareHouse SoftwareHouse)
        {
            try
            {
                using VideogameManager db = new VideogameManager();
                {
                    db.Add(SoftwareHouse);
                    db.SaveChanges();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
   
