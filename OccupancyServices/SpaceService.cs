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

        public void AddSpace(Space space)
        {
            _context.Spaces.Add(space);
            _context.SaveChanges();
        }


        public IEnumerable<Space> GetAllSpaces()
        {
            return _context.Spaces.Include(j => j.Building);
        }

        public IEnumerable<Space> GetAllSpacesInBuilding(int buildingId)
        {
            return _context.Spaces.Where(j => j.Building.Id == buildingId).Include(j => j.Building);
        }

        public IEnumerable<Space> GetOccupiedSpaces()
        {
            return _context.Spaces.Where(j => j.Occupied == true).Include(j => j.Building);
        }

        public IEnumerable<Space> GetOccupiedSpacesInBuilding(int buildingId)
        {
            return _context.Spaces.Where(j => j.Building.Id == buildingId && j.Occupied == true).Include(j => j.Building);
        }

        public Space GetSpace(int id)
        {
            return _context.Spaces.Where(j => j.Id == id).Include(j => j.Building).FirstOrDefault();
        }

        public IEnumerable<Space> GetUnoccupiedSpaces()
        {
            return _context.Spaces.Where(j => j.Occupied == false).Include(j => j.Building);
        }

        public IEnumerable<Space> GetUnoccupiedSpacesInBuilding(int buildingId)
        {
            return _context.Spaces.Where(j => j.Building.Id == buildingId && j.Occupied == false).Include(j => j.Building);

        }

        public void SetSpaceBuilding(int id, Building building)
        {
            _context.Spaces.FirstOrDefault(j => j.Id == id).Building = building;
            _context.SaveChanges();
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
