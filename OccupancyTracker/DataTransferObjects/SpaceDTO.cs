using OccupancyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OccupancyTracker.DataTransferObjects
{
    public class SpaceDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Occupied { get; set; }
        public int BuildingId { get; set; }

        public SpaceDTO() { }
        public SpaceDTO(Space space)
        {
            Id = space.Id;
            Name = space.Name;
            Occupied = space.Occupied;
            BuildingId = space.Building.Id;
        }
    }
}
