using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BillingsController : BaseApiController<BillingsController>
    {
        private readonly IBillingService _billingservice;

        public BillingsController(IBillingService service, 
        ILogger<BillingsController> logger) : base(logger)
        {
            _billingservice = service;
        }

        [Authorize(Roles ="Admin")]
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

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<ReadBillingDto>> CreateBilling(CreateBillingDto dto)
        {
            var created = await _billingservice.CreateBilling(dto);
            return CreatedAtAction(nameof(GetBillingById), new {id = created.Id}, created);
        }

        [Authorize(Roles ="Admin")]
        [HttpPut ("{id:guid}")]
        public async Task<IActionResult> UpdateBilling(FullBillingDto billing)
        {
            await _billingservice.UpdateBilling(billing);
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBilling(Guid id)
        {
            await _billingservice.DeleteBilling(id);
            return NoContent();
        }
    }
}