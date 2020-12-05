using OccupancyData.Models;
using System.Collections.Generic;


namespace OccupancyServices.Interfaces
{
    public interface IComputerService
    {
        IEnumerable<Computer> GetAllComputers();
        IEnumerable<Computer> GetLoggedOnComputers();
        IEnumerable<Computer> GetLoggedOffComputers();
        Computer GetComputer(int id);
        Computer GetComputerByName(string name);
        void ComputerLogIn(int id);
        void ComputerLogOff(int id);
        void AddComputer(Computer computer);
    }
}
