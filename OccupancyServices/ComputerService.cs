using Microsoft.EntityFrameworkCore;
using OccupancyData;
using OccupancyData.Models;
using OccupancyServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OccupancyServices
{
    public class ComputerService : IComputerService
    {

        //Database context
        private OccupancyDbContext _context;

        public ComputerService(OccupancyDbContext context)
        {
            _context = context;
        }


        /*
         * Computer Service Implementation
         */

        public void ComputerLogIn(int id)
        {
            _context.Computers.Where(j => j.Id == id).FirstOrDefault().Log_On();
            _context.SaveChanges();
        }

        public void ComputerLogOff(int id)
        {
            _context.Computers.Where(j => j.Id == id).FirstOrDefault().Log_Off();
            _context.SaveChanges();
        }

        public IEnumerable<Computer> GetAllComputers()
        {
            return _context.Computers;
        }

        public Computer GetComputer(int id)
        {
            return _context.Computers.Where(j => j.Id == id).FirstOrDefault();
        }

        public IEnumerable<Computer> GetLoggedOffComputers()
        {
            return _context.Computers.Where(j => j.Logged_On == false);
        }

        public IEnumerable<Computer> GetLoggedOnComputers()
        {
            return _context.Computers.Where(j => j.Logged_On == true);
        }
    }
}
