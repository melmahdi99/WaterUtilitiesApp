using Domain;
using Microsoft.Identity.Client;

namespace Persistence;

public class DbInitializerBilling
{
    public static async Task SeedData(AppDbContext context)
    {
        if (context.Billings.Any()) return;

        var random = new Random();
        var billings = new List<Billing>();

        for (int i = 0; i < 20; i++)
        {
            var billing = new Billing
            {
                PriceRate = random.Next(1, 100), //this should be in dollars per gallon
                TotalAmountDue = 0, //this should be in dollars, calculated by multiplying the PriceRate by the MeterReading field in the WaterMeter table
                DueDate = DateOnly.FromDateTime(DateTime.Now).AddDays(random.Next(-10, 30)), //FromDateTime is a method that converts DateTime to DateOnly, this is needed because the AddDays method is for DateTime not DateOnly
                TimePaid = DateTime.Now.AddDays(random.Next(-10,30)), //adds a random time 
                IsPaid = false, //this should be determined through a conditional that determines whether the TimePaid is after the DueDate
                CustomerId = Guid.NewGuid(), //this should be a reference to the Customer entity in the final version of the app
                WaterMeterId = Guid.NewGuid() //this should be a reference to the water meter entity in the final version of the app
            };
        }


        foreach(var billing in billings) //loop to correctly assign true values to IsPaid if the TimePaid is before the DueDate
        {
            if (billing.TimePaid < billing.DueDate.ToDateTime(new TimeOnly(23, 59, 59))) //to compare the 2 variables I converted the DueDate to DateTime from DateOnly assuming the time due is 11:59 PM
            {
                billing.IsPaid = true;
            };
        };
    }
}