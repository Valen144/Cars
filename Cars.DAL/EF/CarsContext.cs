using Cars.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.DAL.EF
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
