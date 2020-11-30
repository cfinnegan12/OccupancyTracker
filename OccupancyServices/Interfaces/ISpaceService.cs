using OccupancyData.Models;
using System.Collections.Generic;


namespace OccupancyServices.Interfaces
{
    public interface ISpaceService
    {
        IEnumerable<Space> GetAllSpaces();
        IEnumerable<Space> GetOccupiedSpaces();
        IEnumerable<Space> GetUnoccupiedSpaces();
        Space GetSpace(int id);
        void SpaceOccupied(int id);
        void SpaceUnoccupied(int id);
    }
}
