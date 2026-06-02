using System;

namespace Domain;

public class WaterMeter
{
    public Guid Id { get; set; }
    public decimal MeterReading { get; set; }
    public bool IsOnline { get; set; }

    //FK
    public Guid BuildingId { get; set; }
}

// public class MeterReading
// {
//     public decimal Value { get; set; }
//     public DateTimeOffset RecordedAt { get; set; }



//     public decimal CalculateConsumption(decimal previousValue)
//     {   //calculates how much water has been consumed since the last reading
//         if (Value < previousValue) //if current reading is greater than or equal to the previous reading it returns the difference, your actual consumption
//         {
//             return 0m; //if the current reading is less than or equal to zero than it returns 0. Water meters should never be negative
//         }
    
//         return Value - previousValue;
//     }

// }
