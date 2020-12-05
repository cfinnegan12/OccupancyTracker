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
    [Route("api/spaces")]
    [ApiController]
    public class SpacesAPIController : ControllerBase
    {

        private readonly ISpaceService _spaceService;
        private readonly IBuildingService _buildingService;

        public SpacesAPIController(ISpaceService spaceRepo, IBuildingService buildingRepo) {
            _spaceService = spaceRepo;
            _buildingService = buildingRepo;
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~GET METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        // Return All Spaces / All Spaces in a Building if Id is provided
        [HttpGet]
        public ActionResult<IEnumerable<SpaceDTO>> GetAllSpaces([FromQuery]int buildingId)
        {
            IEnumerable<SpaceDTO> spaces;
            if (buildingId==0)
                spaces = _spaceService.GetAllSpaces().Select( s => new SpaceDTO(s));
            else
                spaces = _spaceService.GetAllSpacesInBuilding(buildingId).Select(s => new SpaceDTO(s));
            return Ok(spaces);
        }

        // Return Space with specified Id
        [HttpGet("{id}")]
        public ActionResult<SpaceDTO> GetSpace(int id)
        {
            var space = _spaceService.GetSpace(id);
            if (space == null)
                return NotFound();
            else
                return Ok(new SpaceDTO(space));
        }


        // Return all Unoccupied Spaces
        [HttpGet("unoccupied")]
        public ActionResult<IEnumerable<SpaceDTO>> GetUnoccupiedSpaces([FromQuery] int buildingId)
        {
            IEnumerable<Space> spaces;
            if (buildingId != 0)
                spaces = _spaceService.GetUnoccupiedSpacesInBuilding(buildingId);
            else
                spaces = _spaceService.GetUnoccupiedSpaces();
            return Ok(spaces.Select(s => new SpaceDTO(s)));
        }

        // Return all Occupied Spaces
        [HttpGet("occupied")]
        public ActionResult<IEnumerable<SpaceDTO>> GetOccupiedSpaces([FromQuery] int buildingId)
        {
            IEnumerable<Space> spaces;
            if (buildingId != 0)
                spaces = _spaceService.GetOccupiedSpacesInBuilding(buildingId);
            else
                spaces = _spaceService.GetOccupiedSpaces();
            return Ok(spaces.Select(s => new SpaceDTO(s)));
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~PUT METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        // Set Occupied to true for Space
        [HttpPut("{id}/occupied")]
        public ActionResult<SpaceDTO> SetSpaceOccupied(int id)
        {
            if (_spaceService.GetSpace(id) == null)
                return NotFound();

            _spaceService.SpaceOccupied(id);
            return Ok(new SpaceDTO(_spaceService.GetSpace(id)));
        }

        // Set Occupied to false for Space
        [HttpPut("{id}/unoccupied")]
        public ActionResult<SpaceDTO> SetSpaceUnoccupied(int id)
        {
            if (_spaceService.GetSpace(id) == null)
                return NotFound();

            _spaceService.SpaceUnoccupied(id);
            return Ok(new SpaceDTO(_spaceService.GetSpace(id)));
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~POST METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Add new Space
        [HttpPost]
        public ActionResult AddSpace([FromBody] SpaceDTO spaceDTO)
        {
            if (spaceDTO.Name == null)
                return BadRequest("Name must be specified");

            Space space = new Space
            {
                Name = spaceDTO.Name,
                Occupied = spaceDTO.Occupied
            };

            var building = _buildingService.GetBuilding(spaceDTO.BuildingId);
            if (building != null)
                space.Building = building; 


            _spaceService.AddSpace(space);
            spaceDTO.Id = space.Id;
            return Ok(spaceDTO);
        }

    }
}
