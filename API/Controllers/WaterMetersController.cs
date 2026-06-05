using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatermetersController : BaseApiController<WatermetersController>
    {
        private readonly IWaterMeterService _service;


        public WatermetersController(IWaterMeterService service,
        ILogger<WatermetersController> logger) : base(logger)
        {
            _service = service;
        }


        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<ActionResult<List<WaterMeterResponseDTO>>> GetAllAsync()
        {
            var meters = await _service.GetAllAsync();
            return Ok(meters);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<WaterMeterResponseDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                var meter = await _service.GetByIDAsync(id);
                return Ok(meter);
            }
            catch (KeyNotFoundException e)
            {
                
                return NotFound(e.Message);
            }
        }


        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<WaterMeterResponseDTO>> Create(CreateWaterMeterDTO dto)
        {
            var created = await _service.Create(dto);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = created.Id}, created);
        }



        [Authorize(Roles ="Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<WaterMeterResponseDTO>> UpdateAsync(Guid id, UpdateWaterMeterDTO dto)
        {
            try
            {
                var Updated = await _service.UpdateAsync(id, dto);
                return Ok(Updated);
            }
            catch (KeyNotFoundException e)
            {
                
                return NotFound(e.Message);
            }

        }



        // [HttpPut("{id}/reading")]
        // public async Task<ActionResult<WaterMeterResponseDTO>> UpdatedReading(Guid id, UpdateMeterReadingDTO dto)
        // {
        //     try
        //     {
        //         var Updated = await _service.UpdatReadingAsync(id, dto);
        //         return Ok(Updated);
        //     }
        //     catch (KeyNotFoundException e)
        //     {
                
        //         return NotFound(e.Message);
        //     }
        //}


        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync (Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                
                return NotFound(e.Message);
            }
        }


        
    }
}