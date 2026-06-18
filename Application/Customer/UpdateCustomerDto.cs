using Domain;

namespace Application.Customer;

public class UpdateCustomerDto
{
    public required string FName { get; set; }
    public required string LName { get; set; }
    public required string Email { get; set; }
    public List<Billing>? Bills { get; set; }
}