using Microsoft.EntityFrameworkCore;
using OccupancyData;
using OccupancyData.Models;
using OccupancyServices.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OccupancyServices
{
    public class SpaceService : ISpaceService
    {

        //Database context
        private OccupancyDbContext _context;

        public SpaceService(OccupancyDbContext context)
        {
            _context = context;
        }


        /*
         * Space Service Implementation
         */

        public IEnumerable<Space> GetAllSpaces()
        {
            return _context.Spaces.Include(j => j.Building);
        }

        public IEnumerable<Space> GetAllSpacesInBuilding(int buildingId)
        {
            return _context.Spaces.Where(j => j.Building.Id == buildingId);
        }

        public IEnumerable<Space> GetOccupiedSpaces()
        {
            return _context.Spaces.Where(j => j.Occupied == true);
        }

        public IEnumerable<Space> GetOccupiedSpacesInBuilding(int buildingId)
        {
            return _context.Spaces.Where(j => j.Building.Id == buildingId && j.Occupied == true);
        }

        public Space GetSpace(int id)
        {
            return _context.Spaces.Where(j => j.Id == id).FirstOrDefault();
        }

        public IEnumerable<Space> GetUnoccupiedSpaces()
        {
            return _context.Spaces.Where(j => j.Occupied == false);
        }

        public IEnumerable<Space> GetUnoccupiedSpacesInBuilding(int buildingId)
        {
            return _context.Spaces.Where(j => j.Building.Id == buildingId && j.Occupied == false);

        }

        public void SpaceOccupied(int id)
        {
            _context.Spaces.Where(j => j.Id == id).FirstOrDefault().Space_Occupied();
            _context.SaveChanges();
        }

        public void SpaceUnoccupied(int id)
        {
            _context.Spaces.Where(j => j.Id == id).FirstOrDefault().Space_Unoccupied();
            _context.SaveChanges();
        }
    }
}
