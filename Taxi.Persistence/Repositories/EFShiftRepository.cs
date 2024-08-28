using Microsoft.EntityFrameworkCore;
using Taxi.Aplication.Contracts.Persistence;
using Taxi.Domain.Entities;

namespace Taxi.Persistence.Repositories;
public class EFShiftRepository : EFBaseRepository<Shift>, IShiftRepository
{
    public EFShiftRepository(TaxiDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Shift> Get(int shiftId)
    {
        var shift = await _dbContext.Shifts.Where(x => x.Id == shiftId).FirstOrDefaultAsync();
        return shift;
    }

    public async Task<Shift> GetShift(int shiftId)
    {
        var shift = await _dbContext.Shifts.FirstOrDefaultAsync(x => x.Id == shiftId);
        return shift!;
    }

    public async Task<List<Shift>> GetShiftsUser(int userId)
    {
        var shift = await _dbContext.Shifts.Where(x => x.Id == userId).ToListAsync();
        return shift!;
    }
}