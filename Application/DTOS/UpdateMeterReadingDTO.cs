using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOS;

public class UpdateMeterReadingDTO
{
    [Required]
    [Range(0, 9_999_999.999)]
    public decimal NewReading { get; set; }

}
