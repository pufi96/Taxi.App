using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class Shift : AuditableEntity
{
    public DateTime ShiftStart { get; set; }
    public DateTime? ShiftEnd { get; set; }
    public int MileageStart { get; set; }
    public int? MileageEnd { get; set; }
    public double? Turnover { get; set; }
    public double? Earnings { get; set; }
    public double? Expenses { get; set; }
    public string? Description { get; set; } = string.Empty;
    public int UserId { get; set; }
    public int CarId { get; set; }

    public virtual ICollection<Ride> Rides { get; set; } = new HashSet<Ride>();
    public virtual User User { get; set; } = default!;
    public virtual Car Car { get; set; } = default!;
}