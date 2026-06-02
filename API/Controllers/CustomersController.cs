using Application.DTOs.Customers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class CustomersController(AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<CustomerDto>>> GetCustomers()
    {
        var customers = await context.Customers
            .AsNoTracking()
            .Select(customer => new CustomerDto
            {
                Id = customer.Id,
                FName = customer.FName,
                LName = customer.LName,
                BillingId = customer.BillingId
            })
            .ToListAsync();

        return Ok(customers);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(Guid id)
    {
        var customer = await context.Customers
            .AsNoTracking()
            .Where(customer => customer.Id == id)
            .Select(customer => new CustomerDto
            {
                Id = customer.Id,
                FName = customer.FName,
                LName = customer.LName,
                BillingId = customer.BillingId
            })
            .SingleOrDefaultAsync();

        return customer is null ? NotFound() : Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CreateCustomerDto customerDto)
    {
        var billingExists = await context.Billings.AnyAsync(billing => billing.Id == customerDto.BillingId);

        if (!billingExists)
        {
            return BadRequest($"Billing with id '{customerDto.BillingId}' was not found.");
        }

        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            FName = customerDto.FName,
            LName = customerDto.LName,
            BillingId = customerDto.BillingId
        };

        context.Customers.Add(customer);
        await context.SaveChangesAsync();

        var createdCustomer = ToDto(customer);

        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, createdCustomer);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, UpdateCustomerDto customerDto)
    {
        var customer = await context.Customers.FindAsync(id);

        if (customer is null)
        {
            return NotFound();
        }

        var billingExists = await context.Billings.AnyAsync(billing => billing.Id == customerDto.BillingId);

        if (!billingExists)
        {
            return BadRequest($"Billing with id '{customerDto.BillingId}' was not found.");
        }

        customer.FName = customerDto.FName;
        customer.LName = customerDto.LName;
        customer.BillingId = customerDto.BillingId;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var customer = await context.Customers.FindAsync(id);

        if (customer is null)
        {
            return NotFound();
        }

        context.Customers.Remove(customer);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private static CustomerDto ToDto(Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            FName = customer.FName,
            LName = customer.LName,
            BillingId = customer.BillingId
        };
    }
}
