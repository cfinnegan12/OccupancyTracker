using OccupancyData.Models;
using System.Collections.Generic;

namespace OccupancyServices.Interfaces
{
    public interface ILabService
    {
        IEnumerable<Lab> GetAllLabs();
        IEnumerable<Computer> GetLabComputers(int id);
        Lab GetLab(int id);
        void AddComputerToLab(int labId, Computer computer);
        void AddLab(Lab lab);

    }
}
