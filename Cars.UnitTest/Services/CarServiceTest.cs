using Cars.BLL.Interfaces;
using Cars.BLL.Services;
using Cars.DAL.EF;
using Cars.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.UnitTest.Services
{
    public class CarServiceTest
    {
        [Test]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        public void Failed_to_get_cars_when_negative_parameters(int from, int to)
        {
            var sut = CreateCarService();

            Assert.That(async () =>
            {
                await sut.GetCars(from, to);
            },
           Throws.TypeOf<ArgumentException>().And.Message
           .EqualTo("value cannot be negative"));
        }

        [Test]
        public void Failed_to_get_cars_when_value_less_than_fromPage()
        {
            var sut = CreateCarService();

            Assert.That(async () =>
            {
                await sut.GetCars(3, 1);
            },
           Throws.TypeOf<ArgumentException>().And.Message
           .EqualTo("value cannot be greater (Parameter 'fromPage')"));
        }

        [Test]
        public async Task Successful_return_of_cars()
        {
            var sut = CreateCarService();

            var cars = await sut.GetCars(1, 3);

            var carsList = cars.ToList();
            Assert.Multiple(() =>
            {
                Assert.That(cars.Count(), Is.EqualTo(3));
                Assert.That(carsList[0].Id, Is.EqualTo(2));
                Assert.That(carsList[1].Id, Is.EqualTo(3));
                Assert.That(carsList[2].Id, Is.EqualTo(4));
            });
        }

        #region Factory methods
        private CarsContext CreateDbContextAndData()
        {
            var options = new DbContextOptionsBuilder<CarsContext>()
                .UseInMemoryDatabase("CarTest").Options;

            var dbContext = new CarsContext(options);

            dbContext.AddRange(CreateCars());
            dbContext.SaveChanges();

            return dbContext;
        }

        private IEnumerable<Car> CreateCars()
        {
            return new List<Car>()
            {
                new Car() { Id = 1, Name = "Car №1" },
                new Car() { Id = 2, Name = "Car №2" },
                new Car() { Id = 3, Name = "Car №3" },
                new Car() { Id = 4, Name = "Car №4" },
                new Car() { Id = 5, Name = "Car №5" },
            };
        }

        private ICarService CreateCarService()
        {
            return new CarService(CreateDbContextAndData());
        }
        #endregion
    }
}
