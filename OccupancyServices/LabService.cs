using Microsoft.EntityFrameworkCore;
using OccupancyData;
using OccupancyData.Models;
using OccupancyServices.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OccupancyServices
{
    public class LabService : ILabService
    {

        //Database context
        private OccupancyDbContext _context;

        public LabService(OccupancyDbContext context)
        {
            _context = context;
        }

        public void AddComputerToLab(int labId, Computer computer)
        {
            Lab lab = _context.Labs.FirstOrDefault( j => j.Id == labId);
            lab.Computers.Add(computer);
            _context.SaveChanges();
        }

        public void AddLab(Lab lab)
        {
            _context.Labs.Add(lab);
            _context.SaveChanges();
        }

        public IEnumerable<Lab> GetAllLabs()
        {
            return _context.Labs.Include(lab => lab.Computers).OrderBy(lab => lab.Id);
        }

        public Lab GetLab(int id)
        {
            return _context.Labs.Include(lab => lab.Computers).FirstOrDefault(lab => lab.Id == id);
        }

        public IEnumerable<Computer> GetLabComputers(int id)
        {
            return _context.Labs.Include(lab => lab.Computers).FirstOrDefault(lab => lab.Id == id).Computers;
        }

    }
}
