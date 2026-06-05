namespace Application.DTOs.Customers;

public class CreateCustomerDto
{
    public required string FName { get; set; }
    public required string LName { get; set; }
    public required string Email { get; set; }
}
