using OccupancyData.Models;
using System.Collections.Generic;


namespace OccupancyServices.Interfaces
{
    public interface IComputerService
    {
        IEnumerable<Computer> GetAllComputers();
        IEnumerable<Computer> GetLoggedOnComputers();
        IEnumerable<Computer> GetLoggedOffComputers();
        IEnumerable<Computer> GetComputersInLab(int lab);
        Computer GetComputer(int id);
        float GetLabOccupancy(int id);
        void ComputerLogIn(int id);
        void ComputerLogOff(int id);
    }
}
