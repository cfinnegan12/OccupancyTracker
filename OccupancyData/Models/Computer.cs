using System.ComponentModel.DataAnnotations;

namespace OccupancyData.Models
{
    public class Computer
    {

        //Computer's Id
        [Required]
        public int Id { get; set; }

        //Computer's name
        [Required]
        public string Machine_Name { get; set; }

        //Wether the computer is logged into or not
        [Required]
        public bool Logged_On { get; set; }

        //Which lab the computer is in
        [Required]
        public int Lab { get; set; }


        public void Log_On() { Logged_On = true; }
        public void Log_Off() { Logged_On = false; }
    }
}
