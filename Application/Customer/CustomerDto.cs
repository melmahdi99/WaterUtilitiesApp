using Domain;

namespace Application.Customer;

public class CustomerDto
{
    public Guid Id { get; set; }
    public required string FName { get; set; }
    public required string LName { get; set; }
    public List<Billing> Bills { get; set; }
}