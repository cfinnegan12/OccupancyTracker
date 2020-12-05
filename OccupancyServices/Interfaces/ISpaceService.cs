using OccupancyData.Models;
using System.Collections.Generic;


namespace OccupancyServices.Interfaces
{
    public interface ISpaceService
    {
        IEnumerable<Space> GetAllSpaces();
        IEnumerable<Space> GetOccupiedSpaces();
        IEnumerable<Space> GetUnoccupiedSpaces();
        IEnumerable<Space> GetAllSpacesInBuilding(int buildingId);
        IEnumerable<Space> GetOccupiedSpacesInBuilding(int buildingId);
        IEnumerable<Space> GetUnoccupiedSpacesInBuilding(int buildingId);
        Space GetSpace(int id);
        void SpaceOccupied(int id);
        void SpaceUnoccupied(int id);
        void AddSpace(Space space);
        void SetSpaceBuilding(int id, Building building);
    }
}
