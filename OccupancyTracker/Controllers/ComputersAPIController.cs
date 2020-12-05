using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OccupancyData.Models;
using OccupancyServices.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OccupancyTracker.Controllers
{
    [Route("api/computers")]
    [ApiController]
    public class ComputersAPIController : ControllerBase
    {
        IComputerService _computerService;

        public ComputersAPIController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~GET METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        [HttpGet]
        public ActionResult<IEnumerable<Computer>> GetAllComputers()
        {
            var computers = _computerService.GetAllComputers();
            return Ok(computers);
        }

        [HttpGet("{id}")]
        public ActionResult<Computer> GetComputers(int id)
        {
            var computer = _computerService.GetComputer(id);
            if (computer == null)
                return NotFound();
            else
                return Ok(computer);
        }

        [HttpGet("loggedon")]
        public ActionResult<IEnumerable<Computer>> GetLoggedOnComputers()
        {
            var computers = _computerService.GetLoggedOnComputers();
            return Ok(computers);
        }

        [HttpGet("loggedoff")]
        public ActionResult<IEnumerable<Computer>> GetLoggedOffComputers()
        {
            var computers = _computerService.GetLoggedOffComputers();
            return Ok(computers);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~PUT METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        [HttpPut("logon")]
        public ActionResult<Computer> LogOnComputer([FromQuery] int id, [FromQuery] string machineName)
        {
            if (id == 0 && machineName == null)
                return BadRequest("id or machineName must be provided via Query String");

            Computer computer;
            if (id != 0)
                computer = _computerService.GetComputer(id);
            else
                computer = _computerService.GetComputerByName(machineName);

            if (computer == null)
                return NotFound();

            _computerService.ComputerLogIn(computer.Id);
            return Ok(computer);
        }

        [HttpPut("logoff")]
        public ActionResult<Computer> LogOffComputer([FromQuery] int id, [FromQuery] string machineName)
        {
            if (id == 0 && machineName == null)
                return BadRequest("id or machineName must be provided via Query String");

            Computer computer;
            if (id != 0)
                computer = _computerService.GetComputer(id);
            else
                computer = _computerService.GetComputerByName(machineName);

            if (computer == null)
                return NotFound();


            _computerService.ComputerLogOff(computer.Id);
            return Ok(computer);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~POST METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        [HttpPost]
        public ActionResult<Computer> AddComputer([FromBody] Computer computer)
        {
            if (computer.Machine_Name == null)
                return BadRequest("Machine Name must be provided");

            _computerService.AddComputer(computer);
            return Ok(computer);
        }
    }
}
