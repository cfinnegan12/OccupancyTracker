using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OccupancyData.Models;
using OccupancyServices.Interfaces;
using OccupancyTracker.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OccupancyTracker.Controllers
{
    [Route("api/labs")]
    [ApiController]
    public class LabsAPIController : ControllerBase
    {
        private readonly ILabService _labService;
        private readonly IComputerService _computerService;

        public LabsAPIController(ILabService labRepo, IComputerService compRepo)
        {
            _labService = labRepo;
            _computerService = compRepo;
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~GET METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        [HttpGet]
        public ActionResult<IEnumerable<LabDTO>> GetAllLabs()
        {
            var labs = _labService.GetAllLabs().Select(lab => new LabDTO(lab));
            return Ok(labs);
        }

        [HttpGet("{id}")]
        public ActionResult<LabDTO> GetLab(int id)
        {
            var lab = _labService.GetLab(id);

            if (lab == null)
                return NotFound();
            else
                return Ok(new LabDTO(lab));
        }

        [HttpGet("{id}/computers")]
        public ActionResult<IEnumerable<Computer>> GetLabComputers(int id)
        {
            var lab = _labService.GetLab(id);
            if (lab == null)
                return NotFound();
            else
                return Ok(lab.Computers);

        }

        [HttpGet("{id}/occupancy")]
        public ActionResult<int> GetLabOccupancy(int id)
        {
            var lab = _labService.GetLab(id);
            if (lab == null)
                return NotFound();
            else
                return Ok(lab.GetOccupancy());

        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~PUT METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        [HttpPut("{id}/computers")]
        public ActionResult<LabDTO> AddComputerToLab(int id, [FromQuery] int computerId)
        {
            var lab = _labService.GetLab(id);
            if (lab == null)
                return NotFound("Lab not found");

            if (computerId == 0)
                return BadRequest("computerId must be provided via Query String");

            var computer = _computerService.GetComputer(computerId);

            if (computer == null)
                return NotFound("Computer Not Found");

            _labService.AddComputerToLab(id, computer);

            return Ok(new LabDTO(lab));
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~POST METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        [HttpPost]
        public ActionResult<LabDTO> AddLab([FromBody] LabDTO labDTO)
        {
            Lab lab = new Lab
            {
                Name = labDTO.Lab_Name,
                Computers = new List<Computer>()
            };

            foreach(int compId in labDTO.Computers)
            {
                var comp = _computerService.GetComputer(compId);
                if (comp == null)
                    return BadRequest("No computer with id " + compId + " exists.");
                else
                    lab.Computers.Add(comp);
            }

            _labService.AddLab(lab);
            return Ok(new LabDTO(lab));
        }
    }
}
