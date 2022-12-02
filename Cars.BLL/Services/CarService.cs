using Cars.DAL.EF;
using Cars.BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Cars.BLL.DTOs;
using Cars.BLL.Helpers;
using Cars.DAL.Repositories;

namespace Cars.BLL.Services
{
    public class CarService : ICarService
    {
        private CarRepository _carRepository;

        public CarService(CarsContext context)
        {
            _carRepository = new(context);
        }

        public async Task<IEnumerable<CarDTO>> GetCars(int fromPage, int toPage)
        {
            if (fromPage < 0 || toPage < 0)
                throw new ArgumentException("value cannot be negative");

            if (toPage < fromPage)
                throw new ArgumentException("value cannot be greater", nameof(fromPage));

            var cars = _carRepository.GetCars();

            var selectedСars = await cars
               .OrderBy(x => x.Name)
               .Skip(fromPage)
               .Take(toPage - fromPage + 1)
               .ToListAsync();

            return selectedСars.MapToDTO();
        }
    }
}
