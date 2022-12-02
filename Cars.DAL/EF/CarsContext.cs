using Cars.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.DAL.EF
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>().HasData(
                new Car[]
                {
                    new Car { Id = 1, Name = "Машина №1" },
                    new Car { Id = 2, Name = "Машина №2" },
                    new Car { Id = 3, Name = "Машина №3" },
                    new Car { Id = 4, Name = "Машина №4" },
                    new Car { Id = 5, Name = "Машина №5" },
                    new Car { Id = 6, Name = "Машина №6" },
                    new Car { Id = 7, Name = "Машина №7" },
                    new Car { Id = 8, Name = "Машина №8" },
                    new Car { Id = 9, Name = "Машина №9" },
                    new Car { Id = 10, Name = "Машина №10" },
                    new Car { Id = 11, Name = "Машина №11" },
                    new Car { Id = 12, Name = "Машина №12" },
                }
            );
        }
    }
}
