using Microsoft.AspNetCore.Mvc;
using OccupancyServices.Interfaces;
using OccupancyTracker.ViewModels.Lab;
using System.Linq;

namespace OccupancyTracker.Controllers
{
    public class LabsController : Controller
    {
        private readonly ILabService _repo;

        public LabsController(ILabService repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            var labs = _repo.GetAllLabs();
            var labVMs = labs.Select(
                lab => new LabViewModel
                {
                    Id = lab.Id,
                    Name = lab.Name,
                    Lab_Occupancy = lab.GetOccupancy()
                });

            var labsVM = new LabsViewModel { Labs = labVMs };

            return View(labsVM);
        }
    }
}
