using OccupancyData.Models;
using System.Collections.Generic;

namespace OccupancyServices.Interfaces
{
    public interface IBuildingService
    {

        IEnumerable<Building> GetAllBuildings();
        Building GetBuilding(int Id);
        Building GetBuildingByName(string name);
        int GetBuildingOccupancy(int Id);
        void BuildingEntry(int Id);
        void BuildingExit(int Id);
        bool ResetBuildingOccupancy(int Id);
        bool SetBuildingOccupancy(int Id, int occupancy);
        void AddBuilding(Building building);

    }
}
