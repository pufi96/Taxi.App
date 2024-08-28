using Microsoft.EntityFrameworkCore;
using Taxi.Aplication.Contracts.Persistence;
using Taxi.Domain.Entities;

namespace Taxi.Persistence.Repositories;

public class EFCarRepository : EFBaseRepository<Car>, ICarRepository
{
    public EFCarRepository(TaxiDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Car?> GetCar(int carId)
    {
        return await _dbContext.Cars.Where(x => x.Id == carId).FirstAsync();
    }

    
    public Task<List<Car>> ListCarsShift()
    {
        throw new NotImplementedException();
    }
}