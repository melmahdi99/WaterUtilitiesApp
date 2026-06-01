using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class BuildingCustomer
{
    // m:n junction table between many Buildings and many Customers
    [ForeignKey(nameof(Building))]
    public Guid BuildingId { get; set; }
    [Required]
    public required Building Building { get; set; }


    [ForeignKey(nameof(Customer))]
    public Guid CustomerId { get; set; }
    [Required]
    public required Customer Customer { get; set;}
}