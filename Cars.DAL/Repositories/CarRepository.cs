using Cars.DAL.EF;
using Cars.DAL.Entities;

namespace Cars.DAL.Repositories
{
    public class CarRepository
    {
        private readonly CarsContext _context;

        public CarRepository(CarsContext context)
        {
            _context = context;
        }

        public IQueryable<Car> GetCars()
        {
            return _context.Cars.AsQueryable();
        }
    }
}
