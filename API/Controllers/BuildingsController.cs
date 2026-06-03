using Application;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : BaseApiController<BuildingsController>
    {
        private readonly IBuildingService _buildingservice;
        // private readonly ILogger<BuildingsController> _logger;

        public BuildingsController(
            IBuildingService service,
            ILogger<BuildingsController> logger
        ) : base(logger)
        {
            _buildingservice = service;
            // _logger = logger;
        }

        // get all buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBuildingDto>>> GetBuildingsAsync()
        {
            _logger.LogInformation("Request to get all buildings");
            var buildings = await _buildingservice.GetBuildingsAsync();

            if (!buildings.Any())
            {
                return NotFound();
            }
            return Ok(buildings);
        }

        // get building by ID
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetBuildingDto>> GetBuildingById(Guid id)
        {
            var building = await _buildingservice.GetBuildingById(id);

            if (building == null)
            {
                return NotFound();
            }
            return Ok(building);
        }

        // create a building
        [HttpPost]
        public async Task<ActionResult<GetBuildingDto>> CreateBuilding(CreateBuildingDto dto)
        {
            var created = await _buildingservice.CreateBuilding(dto);
            return CreatedAtAction(nameof(GetBuildingById), new { id = created.Id }, created);
        }

        // edit a building
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditBuilding(Guid id, CreateBuildingDto dto)
        {
            try
            {
                await _buildingservice.EditBuilding(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // delete a building
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBuilding(Guid id)
        {
            try
            {
                await _buildingservice.DeleteBuilding(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}