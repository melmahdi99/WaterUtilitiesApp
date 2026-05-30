using System;

namespace Domain;

public class Customer
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    //Not sure if we're keeping the water company table after what Ethan said
    // public Guid WaterCompanyId { get; set; }
}
