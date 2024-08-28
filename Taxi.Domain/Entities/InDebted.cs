using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class InDebted : AuditableEntity
{
    public int DebtorId { get; set; }
    public int RideId { get; set; }

    public virtual ICollection<Debtor> Debtors { get; set; } = new HashSet<Debtor>();
    public virtual Ride Ride { get; set; } = default!;
}