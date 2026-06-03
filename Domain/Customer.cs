using System;
using System.Collections.Generic;

namespace Domain;

public class Customer
{
    public Guid Id { get; set; }
    public required string FName { get; set; }
    public required string LName { get; set; }
    public List<Billing> Bills { get; set; } = new();
}
