using System.ComponentModel.DataAnnotations;

namespace OccupancyData.Models
{
    public class Space
    {
        //Space Id
        [Required]
        public int Id { get; set; }

        //Space's name
        [Required]
        public string Name { get; set; }

        //Space occupied status
        [Required]
        public bool Occupied { get; set; }

        //Building Space is located in
        public Building Building { get; set; }

        public void Space_Occupied() { Occupied = true; }
        public void Space_Unoccupied() { Occupied = false; }

    }
}
