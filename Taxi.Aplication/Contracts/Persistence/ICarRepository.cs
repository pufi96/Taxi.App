using Taxi.Domain.Entities;

namespace Taxi.Aplication.Contracts.Persistence;

public interface ICarRepository : IAsyncRepository<Car>
{
    Task<List<Car>> ListCarsShift();
    Task<Car?> GetCar(int carId);
}