using Cars.DAL.EF;
using Cars.DAL.Entities;

namespace Cars.API.Extensions
{
    public static class CarsContextExtensions
    {
        public static void Initialize(this CarsContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            for (int i = 0; i < 15; i++)
            {
                var car = dbContext.Cars.FirstOrDefault(b => b.Id == i);
                if (car == null)
                {
                    dbContext.Cars.Add(new Car { Name = $"Машина №{i}" });
                }
            }

            dbContext.SaveChanges();
        }
    }
}