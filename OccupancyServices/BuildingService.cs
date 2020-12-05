using OccupancyData;
using OccupancyData.Models;
using OccupancyServices.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace OccupancyServices
{
    public class BuildingService : IBuildingService
    {
        //Database context
        private OccupancyDbContext _context;

        public BuildingService(OccupancyDbContext context)
        {
            _context = context;
        }

        /*
         * Building Service Implementation
         */

        public void AddBuilding(Building building)
        {
            _context.Buildings.Add(building);
            _context.SaveChanges();
        }


        public void BuildingEntry(int Id)
        {
            var building = _context.Buildings.Where(j => j.Id == Id).FirstOrDefault();
            building.Building_Occupancy += 1;
            _context.SaveChanges();
        }

        public void BuildingExit(int Id)
        {
            var building = _context.Buildings.Where(j => j.Id == Id).FirstOrDefault();
            building.Building_Occupancy -= 1; 
            _context.SaveChanges();
        }

        public IEnumerable<Building> GetAllBuildings()
        {
            return _context.Buildings;
        }

        public Building GetBuilding(int Id)
        {
            return _context.Buildings.Where(j => j.Id == Id).FirstOrDefault();
        }

        public Building GetBuildingByName(string name)
        {
            return _context.Buildings.Where(j => j.Building_Name == name).FirstOrDefault();
        }

        public int GetBuildingOccupancy(int Id)
        {
            return _context.Buildings.Where(j => j.Id == Id).FirstOrDefault().Building_Occupancy;
        }

        public bool ResetBuildingOccupancy(int Id)
        {
            var building = _context.Buildings.FirstOrDefault(j => j.Id == Id);
            building.Building_Occupancy = 0;
            _context.SaveChanges();
            return building != null;
        }

        public bool SetBuildingOccupancy(int Id, int occupancy)
        {
            var building = _context.Buildings.FirstOrDefault(j => j.Id == Id);
            building.Building_Occupancy = occupancy;
            _context.SaveChanges();
            return building != null;
        }
    }
}
