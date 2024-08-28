using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class Debtor : AuditableEntity
{
    public string DebtorFirstName { get; set; } = string.Empty;
    public string DebtorLastName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<InDebted> InDebteds { get; set; } = new HashSet<InDebted>();
    public virtual ICollection<DebtCollection> DebtCollections { get; set; } = new HashSet<DebtCollection>();
}