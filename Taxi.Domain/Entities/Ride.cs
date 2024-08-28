using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;

public class Ride : AuditableEntity
{
    public bool IsLocal { get; set; }
    public double RidePrice { get; set; }
    public int? LocationPriceId { get; set; }
    public int ShiftId { get; set; }

    public virtual LocationPrice LocationPrice { get; set; } = default!;
    public virtual Shift Shift { get; set; } = default!;
    public virtual ICollection<InDebted> InDebteds { get; set; } = new HashSet<InDebted>();
}