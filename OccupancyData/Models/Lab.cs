using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OccupancyData.Models
{
    public class Lab
    {
        [Required]
        public int Id { get; set; }

        //Name of the lab
        [Required]
        public string Name { get; set; }

        //Computers in the lab
        [Required]
        public IEnumerable<Computer> Computers { get; set; }

        public float GetOccupancy()
        {
            float total = Computers.Count();
            float loggedOn = Computers.Where(comp => comp.Logged_On==true).Count();
            return (loggedOn/total)*100;
        }

    }
}
