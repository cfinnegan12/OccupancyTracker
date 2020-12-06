using OccupancyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OccupancyTracker.DataTransferObjects
{
    public class LabDTO
    {
        public int Id { get; set; }
        public string Lab_Name { get; set; }

        public IEnumerable<int> Computers { get; set; }

        public LabDTO() { }

        public LabDTO(Lab lab)
        {
            Id = lab.Id;
            Lab_Name = lab.Name;
            Computers = lab.Computers.Select(j => j.Id);
        }

    }
}
