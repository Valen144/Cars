using Cars.BLL.DTOs;
using Cars.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Сars.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<IEnumerable<CarDTO>>>> GetCars(
            [FromQuery] int fromPage = 0, 
            [FromQuery] int toPage = 10)
        {
            return Ok(ApiResult<IEnumerable<CarDTO>>.Success200(
                await _carService.GetCars(fromPage, toPage)));
        }
    }
}