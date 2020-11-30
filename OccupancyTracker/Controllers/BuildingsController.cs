using Microsoft.AspNetCore.Mvc;
using OccupancyServices.Interfaces;
using OccupancyTracker.ViewModels.Building;
using System.Linq;

namespace OccupancyTracker.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly IBuildingService _repo;

        public BuildingsController(IBuildingService repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var allBuildings = _repo.GetAllBuildings();
            var buildingVMs = allBuildings.Select(
                building => new BuildingViewModel
                {
                    Name = building.Building_Name,
                    Occupancy = building.Building_Occupancy
                });

            var buildingsVM = new BuildingsViewModel { Buildings = buildingVMs };

            return View(buildingsVM);
        }

    }
}
