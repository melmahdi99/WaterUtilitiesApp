using System;

namespace Domain;

public class Customer
{
    public Guid Id { get; set; }
    public required string FName { get; set; }
    public required string LName { get; set; }
    public Guid BillingId { get; set; }
    public Billing? Billing { get; set; }
}
