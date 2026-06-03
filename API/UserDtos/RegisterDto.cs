using System;
using System.ComponentModel.DataAnnotations;

namespace API.UserDtos;

public class RegisterDto
{
    [Required, MinLength(2), MaxLength(30)]
    public string? FirstName { get; set; }

    [Required, MinLength(2), MaxLength(30)]
    public string? LastName { get; set; }

    [Required, MaxLength(50)]
    public string? Email { get; set; }
    
    [Required]
    public string? Password { get; set; }
}
