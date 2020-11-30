using Microsoft.AspNetCore.Mvc;
using OccupancyServices.Interfaces;
using OccupancyTracker.ViewModels.Building;
using OccupancyTracker.ViewModels.Space;
using System.Linq;


namespace OccupancyTracker.Controllers
{
    public class CSBController : Controller
    {
        private readonly IBuildingService _buildingRepo;
        private readonly ISpaceService _SpacesRepo;

        public CSBController(IBuildingService buildingRepo, ISpaceService spaceRepo)
        {
            _buildingRepo = buildingRepo;
            _SpacesRepo = spaceRepo;
        }

        public IActionResult Index()
        {
            var csbSpaces = _SpacesRepo.GetAllSpaces();
            var csbSpaceVMs = csbSpaces.Select(
                space => new SpaceViewModel
                {
                    Name = space.Name,
                    Occupied = space.Occupied
                });
            var csbSpacesVM = new SpacesViewModel
            {
                Spaces = csbSpaceVMs
            };

            var csb = _buildingRepo.GetBuildingByName("Computer Science Building");
            var csbVM = new CSBViewModel
            {
                Occupancy = csb.Building_Occupancy,
                Spaces = csbSpacesVM
            };
            return View(csbVM);
        }
    }
}
