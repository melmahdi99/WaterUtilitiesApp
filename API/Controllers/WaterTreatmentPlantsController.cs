using Application;
using Application.WaterTreatmentPlant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterTreatmentPlantsController : BaseApiController<WaterTreatmentPlantsController>
    {
        private readonly IWaterTreatmentPlantService _service;

        public WaterTreatmentPlantsController(IWaterTreatmentPlantService service, 
        ILogger<WaterTreatmentPlantsController> logger) : base(logger)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetWaterTreatmentPlants()
        {
            _logger.LogInformation("Request to GET all Water Treatment Plants.");
            var waterTreatmentPlants = await _service.GetWaterTreatmentPlantsAsync();
            if(!waterTreatmentPlants.Any()) return NotFound();
            return Ok(waterTreatmentPlants);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetWaterTreatmentPlantById(Guid id)
        {
            _logger.LogInformation("Request to GET Water Treatment Plant with ID: {id}", id);
            var waterTreatmentPlant = await _service.GetWaterTreatmentPlantAsync(id);
            if(waterTreatmentPlant == null) return NotFound();
            return Ok(waterTreatmentPlant);
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteWaterTreatmentPlantById(Guid id)
        {
            _logger.LogInformation("Request to DELETE Water Treatment Plant with ID: {id}", id);
            await _service.DeleteWaterTreatmentPlant(id);
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateWaterTreatmentPlant(CreateWaterTreatmentPlantDto dto)
        {
            _logger.LogInformation("Request to POST a new Water Treatment Plant");
            var created = await _service.CreateWaterTreatmentPlant(dto);
            _logger.LogInformation("Created new Water Treatment Plant with ID: {id}", created.Id);
            return CreatedAtAction(nameof(GetWaterTreatmentPlantById), new{id = created.Id}, created);
        }

        [Authorize(Roles ="Admin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateWaterTreatmentPlant(Guid id, ReadWaterTreatmentPlantDto dto)
        {
            _logger.LogInformation("Request to PUT Water Treatment Plant with ID: {id}",id);
            await _service.UpdateWaterTreatmentPlant(dto);
            _logger.LogInformation("Updated Water Treatment Plant with ID: {id}",id);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("Buffer")]
        public async Task<ActionResult<IEnumerable<GetBuildingDto>>> GetBuildingInServiceArea(
            [FromQuery]double latitude, [FromQuery]double longitude, [FromQuery]double radius)
        {
            var buildings = await _service.GetBuildingsInServiceAreaAsync(latitude, longitude, radius);
            if (!buildings.Any())
            {
                return NotFound();
            }
            return Ok(buildings);
        }
    }
}
