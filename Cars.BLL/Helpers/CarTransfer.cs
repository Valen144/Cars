using Cars.BLL.DTOs;
using Cars.DAL.Entities;

namespace Cars.BLL.Helpers
{
    public static class CarTransfer
    {
        public static List<CarDTO> MapToDTO(this IEnumerable<Car> items)
        {
            return CarMapper.Create().Map<List<CarDTO>>(items);
        }
    }
}
