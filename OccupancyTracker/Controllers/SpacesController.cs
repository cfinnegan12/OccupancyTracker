using Microsoft.AspNetCore.Mvc;
using OccupancyData;
using OccupancyServices.Interfaces;
using OccupancyTracker.ViewModels.Space;
using System.Linq;

namespace OccupancyTracker.Controllers
{
    public class SpacesController : Controller
    {

        private readonly ISpaceService _repo;

        public SpacesController(ISpaceService repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            var allSpaces = _repo.GetAllSpaces();

            var spaceViewModels = allSpaces
                .Select(result => new SpaceViewModel
                {
                    Name = result.Name,
                    Occupied = result.Occupied
                });

            var spacesViewModel = new SpacesViewModel
            {
                Spaces = spaceViewModels
            };
            return View(spacesViewModel);
        }
    }
}
