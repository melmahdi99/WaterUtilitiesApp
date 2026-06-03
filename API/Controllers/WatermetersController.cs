using Application;
using Application.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatermetersController : ControllerBase
    {
        private readonly IWaterMeterService _service;


        public WatermetersController(IWaterMeterService service)
        {
            _service = service;
        }


        [HttpGet] //api/watermeters
        public async Task<ActionResult<List<WaterMeterResponseDTO>>> GetAllAsync() //This works
        {
            var meters = await _service.GetAllAsync();
            return Ok(meters);
        }


        [HttpGet("{id}")] //api/Watermeters/{id}
        public async Task<ActionResult<WaterMeterResponseDTO>> GetByIdAsync(Guid id) //works
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


        
        [HttpPost] //api/Watermeters
        public async Task<ActionResult<WaterMeterResponseDTO>> Create([FromBody] CreateWaterMeterDTO dto) //THis sends a post, but it gives an   
        {
            var created = await _service.Create(dto);

            //return Ok(created);

            return CreatedAtAction("GetById", new { id = created.Id}, created);
        }




        [HttpPut("{id}")] //api/Watermeters/{id}
        public async Task<ActionResult<WaterMeterResponseDTO>> UpdateAsync(Guid id, UpdateWaterMeterDTO dto)//works on Thunderclient
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


        [HttpDelete("{id}")] //api/watermeters/{id}
        public async Task<IActionResult> DeleteAsync (Guid id) //Works
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



        [HttpGet("{id}/usage")] //api/watermeters/{id}/usage
        public async Task<ActionResult<WaterMeterUsageDTO>> GetUsage(Guid id) //This endpoint works
        {
            try
            {
                var usage = await _service.GetUsageAsync(id);
                return Ok(usage);
            }
            catch (KeyNotFoundException e)
            {
                
                return NotFound(e.Message);
            }
        }


        [HttpGet("{id}/health")] //api/watermeters/{id}/health
        public async Task<ActionResult<MeterHealthReportDTO>> GetHealth(Guid id) //works
        {
            try
            {
                var report = await _service.GetHealthReportAsync(id);
                return Ok(report);
            }
            catch (KeyNotFoundException e)
            {
                
                return NotFound(e.Message);
            }
        }


        [HttpPost("{id}/reading")] ///api/watermeters/{id}/reading
        public async Task<ActionResult<WaterMeterResponseDTO>> SubmitReading(Guid id, UpdateMeterReadingDTO dto) //works
        {
            try
            {
                var updated = await _service.SubmitReadingAsync(id, dto);
                return Ok(updated);
            }
            catch (ArgumentException e)
            {
                
                return BadRequest(e.Message); //400 error
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPut("{id}/updatereading")]
        public async Task<ActionResult<WaterMeterResponseDTO>> UpdateReading(Guid id, UpdateMeterReadingDTO dto) //works
        {
        try
        {
            var updated = await _service.SubmitReadingAsync(id, dto);
            return Ok(updated);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
}


        
    }
}
