using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;

public class LocationPrice : AuditableEntity
{
    public double Price { get; set; }
    public int LocationStartId { get; set; }
    public int LocationEndId { get; set; }

    public virtual Location LocationStart { get; set; } = default!;
    public virtual Location LocationEnd { get; set; } = default!;
    public virtual ICollection<Ride> Rides { get; set; } = new HashSet<Ride>();
}