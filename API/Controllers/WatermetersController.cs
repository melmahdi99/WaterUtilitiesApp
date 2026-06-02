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


        [HttpGet]
        public async Task<ActionResult<List<WaterMeterResponseDTO>>> GetAll()
        {
            var meters = await _service.GetAllAsync();
            return Ok(meters);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<WaterMeterResponseDTO>> GetById(Guid id)
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



        [HttpPost]
        public async Task<ActionResult<WaterMeterResponseDTO>> Create(CreateWaterMeterDTO dto)
        {
            var created = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id}, created);
        }




        [HttpPut("{id}")]
        public async Task<ActionResult<WaterMeterResponseDTO>> Update(Guid id, UpdateWaterMeterDTO dto)
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



        [HttpPut("{id}/reading")]
        public async Task<ActionResult<WaterMeterResponseDTO>> UpdatedReading(Guid id, UpdateMeterReadingDTO dto)
        {
            try
            {
                var Updated = await _service.UpdatReadingAsync(id, dto);
                return Ok(Updated);
            }
            catch (KeyNotFoundException e)
            {
                
                return NotFound(e.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NotFound();
            }
            catch (KeyNotFoundException e)
            {
                
                return NotFound(e.Message);
            }
        }


        
    }
}
