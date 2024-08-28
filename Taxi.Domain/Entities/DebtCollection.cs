using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class DebtCollection : AuditableEntity
{
    public double DebtCollectionPrice { get; set; }
    public int DebtorId { get; set; }

    public virtual Debtor Debtor { get; set; } = default!;
}