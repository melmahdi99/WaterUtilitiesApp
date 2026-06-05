using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Customer
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName="nvarchar(55)")]
    public required string FirstName { get; set; }
    [Column(TypeName="nvarchar(55)")]
    public required string LastName { get; set; }
    [EmailAddress]
    public required string Email {get; set;}
    public List<Billing> Bills { get; set; }
}
