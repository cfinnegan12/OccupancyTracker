using Microsoft.EntityFrameworkCore;
using OccupancyData;
using OccupancyData.Models;
using OccupancyServices.Interfaces;
using System;
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
