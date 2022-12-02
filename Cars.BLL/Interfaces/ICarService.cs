using Cars.BLL.DTOs;

namespace Cars.BLL.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> GetCars(int fromPage, int toPage);
    }
}
