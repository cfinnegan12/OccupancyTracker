using Microsoft.AspNetCore.Mvc;
using OccupancyData.Models;
using OccupancyServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OccupancyTracker.Controllers
{
    [Route("api/buildings")]
    [ApiController]
    public class BuildingsAPIController : ControllerBase
    {

        private readonly IBuildingService _buildingService;
        public BuildingsAPIController(IBuildingService buildingRepo)
        {
            _buildingService = buildingRepo;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~GET METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        /*
         * Return All Buildings
         */
        [HttpGet]
        public ActionResult<IEnumerable<Building>> GetAllBuildings()
        {
            var buildings = _buildingService.GetAllBuildings();
            return Ok(buildings);
        }

        /*
         * Return Building with specified Id
         */
        [HttpGet("{id}")]
        public ActionResult<Building> GetBuilding(int id)
        {
            var building = _buildingService.GetBuilding(id);
            if (building == null) return NotFound();
            return Ok(building);
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~PUT METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        /*
         * Reset Occupancy of Building with specified Id
         */
        [HttpPut("{id}/reset")]
        public ActionResult ResetBuildingOccupancy(int id)
        {
            if (_buildingService.ResetBuildingOccupancy(id))
                return Ok(_buildingService.GetBuilding(id));
            else
                return NotFound();
        }

        /*
         * Set Occupancy of Building with specified Id
         */
        [HttpPut("{id}/{occupancy}")]
        public ActionResult SetBuildingOccupancy(int id, int occupancy)
        {
            if (_buildingService.SetBuildingOccupancy(id, occupancy))
                return Ok(_buildingService.GetBuilding(id));
            else
                return NotFound();
        }


        /*
         * Increment Occupancy of Building with specified Id
         */
        [HttpPut("{id}/entry")]
        public ActionResult BuildingEntrance(int id)
        {
            if (_buildingService.GetBuilding(id) == null)
                return NotFound();


            _buildingService.BuildingEntry(id);
            return Ok();
        }

        /*
         * Decrement Occupancy of Building with specified Id
         */
        [HttpPut("{id}/exit")]
        public ActionResult BuildingExit(int id)
        {
            if (_buildingService.GetBuilding(id) == null)
                return NotFound();


            _buildingService.BuildingExit(id);
            return Ok();
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~POST METHODS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        /*
         * Add a new building to the system
         */
        [HttpPost]
        public ActionResult AddBuilding([FromBody] Building building)
        {
            if (building.Building_Name == null)
                return BadRequest("building_Name must be supplied");

            _buildingService.AddBuilding(building);
            return Ok(building);
        }
    }
}
