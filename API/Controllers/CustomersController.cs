using Domain;
using Application.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly AppDbContext _context;
    public CustomersController(AppDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles ="Admin")]
    [HttpGet]
    public async Task<ActionResult<List<CustomerDto>>> GetCustomers()
    {
        var customers = await _context.Customers
            .AsNoTracking()
            .Select(customer => new CustomerDto
            {
                Id = customer.Id,
                FName = customer.FirstName,
                LName = customer.LastName,
                Email = customer.Email,
                Bills = customer.Bills
            })
            .ToListAsync();

        return Ok(customers);
    }

    [Authorize(Roles ="Admin")]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(Guid id)
    {
        var customer = await _context.Customers
            .AsNoTracking()
            .Where(customer => customer.Id == id)
            .Select(customer => new CustomerDto
            {
                Id = customer.Id,
                FName = customer.FirstName,
                LName = customer.LastName,
                Email = customer.Email,
                Bills = customer.Bills
            })
            .SingleOrDefaultAsync();

        return customer is null ? NotFound() : Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CreateCustomerDto customerDto)
    {
        // var billingExists = await _context.Billings.AnyAsync(billing => billing.Id == customerDto.BillingId);

        // if (!billingExists)
        // {
        //     return BadRequest($"Billing with id '{customerDto.BillingId}' was not found.");
        // }

        var customer = new Customer
        {
            FirstName = customerDto.FName,
            LastName = customerDto.LName,
            Email = customerDto.Email
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        var createdCustomer = ToDto(customer);

        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, createdCustomer);
    }

    // [HttpPut("{id:guid}")]
    // public async Task<IActionResult> UpdateCustomer(Guid id, UpdateCustomerDto customerDto)
    // {
    //     var customer = await _context.Customers.FindAsync(id);

    //     if (customer is null)
    //     {
    //         return NotFound();
    //     }

    //     var billingExists = await _context.Billings
    //         .AnyAsync(billing => billing.Id == customerDto.Bills);

    //     if (!billingExists)
    //     {
    //         return BadRequest($"Billing with id '{customerDto.Bills}' was not found.");
    //     }

    //     customer.FirstName = customerDto.FName;
    //     customer.LastName = customerDto.LName;
    //     customer.Bills = customerDto.Bills;

    //     await _context.SaveChangesAsync();

    //     return NoContent();
    // }


    [Authorize(Roles ="Admin")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer is null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private static CustomerDto ToDto(Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            FName = customer.FirstName,
            LName = customer.LastName,
            Email = customer.Email,
            Bills = customer.Bills
        };
    }
}