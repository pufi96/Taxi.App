using Taxi.Domain.Entities;

namespace Taxi.Aplication.Contracts.Persistence;
public interface IShiftRepository : IAsyncRepository<Shift>
{
    Task<List<Shift>> GetShiftsUser(int userId);
    Task<Shift> GetShift(int shiftId);
}