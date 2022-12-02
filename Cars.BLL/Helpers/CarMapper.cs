using AutoMapper;
using Cars.BLL.DTOs;
using Cars.DAL.Entities;

namespace Cars.BLL.Helpers
{
    public static class CarMapper
    {
        public static Mapper Create()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarDTO, Car>().ReverseMap();
            });

            return new Mapper(config);
        }
    }
}
