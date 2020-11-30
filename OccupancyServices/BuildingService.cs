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

        public void BuildingEntry(int Id)
        {
            _context.Buildings.Where(j => j.Id == Id).FirstOrDefault().Entrance();
            _context.SaveChanges();
        }

        public void BuildingExit(int Id)
        {
            _context.Buildings.Where(j => j.Id == Id).FirstOrDefault().Exit();
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
    }
}
