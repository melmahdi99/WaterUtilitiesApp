using Application;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BillingsController : BaseApiController
    {
        private readonly IBillingService _billingservice;

        public BillingsController(IBillingService service)
        {
            _billingservice = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadBillingDto>>> GetBillings()
        {
            var billings = await _billingservice.GetBillingsAsync();
            if(!billings.Any())
            {
                return NotFound();
            }

            return Ok(billings);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FullBillingDto>> GetBillingById(Guid id)
        {
            var billing = await _billingservice.GetBillingAsync(id);

            if(billing == null)
            {
                return NotFound();
            }

            return Ok(billing);
        }

        [HttpPost]
        public async Task<ActionResult<ReadBillingDto>> CreateBilling(CreateBillingDto dto)
        {
            var created = await _billingservice.CreateBilling(dto);
            return CreatedAtAction(nameof(GetBillingById), new {id = created.Id}, created);
        }

        [HttpPut ("{id:guid}")]
        public async Task<IActionResult> UpdateBilling(FullBillingDto billing)
        {
            await _billingservice.UpdateBilling(billing);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBilling(Guid id)
        {
            await _billingservice.DeleteBilling(id);
            return NoContent();
        }
    }
}