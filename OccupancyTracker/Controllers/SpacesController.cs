using Microsoft.AspNetCore.Mvc;
using OccupancyData;
using OccupancyServices.Interfaces;
using OccupancyTracker.ViewModels.Space;
using System.Linq;

namespace OccupancyTracker.Controllers
{
    public class SpacesController : Controller
    {

        private readonly IBuildingService _buildingRepo;
        private readonly ISpaceService _spaceRepo;

        public SpacesController(IBuildingService brepo, ISpaceService crepo)
        {
            _buildingRepo = brepo;
            _spaceRepo = crepo;
        }


        public IActionResult Index()
        {
            var allSpaces = _spaceRepo.GetAllSpaces();

            var spaceViewModels = allSpaces
                .Select(result => new SpaceViewModel
                {
                    Name = result.Name,
                    Occupied = result.Occupied,
                    Building = (result.Building != null) ? result.Building.Building_Name : " "
                }); ;

            var spacesViewModel = new SpacesViewModel
            {
                Spaces = spaceViewModels
            };
            return View(spacesViewModel);
        }
    }
}
