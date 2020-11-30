using System.ComponentModel.DataAnnotations;

namespace OccupancyData.Models
{
    public class Building
    {   
        //Building Id
        [Required]
        public int Id { get; set; }

        //Total number of people in the building
        [Required]
        public int Building_Occupancy { get; set; }

        //Name of the building
        [Required]
        public string Building_Name { get; set; }


        public void Entrance() { Building_Occupancy++; }
        public void Exit() { Building_Occupancy--; }
    }
}
