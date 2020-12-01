using Microsoft.AspNetCore.Mvc;
using OccupancyServices.Interfaces;
using OccupancyTracker.ViewModels.Building;
using OccupancyTracker.ViewModels.Space;
using System.Linq;

namespace OccupancyTracker.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly IBuildingService _buildingRepo;
        private readonly ISpaceService _spaceRepo;

        public BuildingsController(IBuildingService brepo, ISpaceService crepo)
        {
            _buildingRepo = brepo;
            _spaceRepo = crepo;
        }

        public IActionResult Index()
        {
            var allBuildings = _buildingRepo.GetAllBuildings();
            var buildingVMs = allBuildings.Select(
                building => new BuildingViewModel
                {
                    Id = building.Id,
                    Name = building.Building_Name,
                    Occupancy = building.Building_Occupancy,
                    Spaces = null
                });

            var buildingsVM = new BuildingsViewModel { Buildings = buildingVMs };

            return View(buildingsVM);
        }

        public IActionResult Details(int id)
        {
            var building = _buildingRepo.GetBuilding(id);
            var buidingSpaces = _spaceRepo.GetAllSpacesInBuilding(id);

            var buildingSpaceVMs = buidingSpaces.Select(
                    space => new SpaceViewModel
                    {
                        Name = space.Name,
                        Occupied = space.Occupied,
                        Building = building.Building_Name
                    });

            var buildingSpacesVM = new SpacesViewModel { Spaces = buildingSpaceVMs };
            var buildingVM = new BuildingViewModel
            {
                Id = id,
                Name = building.Building_Name,
                Occupancy = building.Building_Occupancy,
                Spaces = buildingSpacesVM
            };

            return View(buildingVM);
        }

    }
}
