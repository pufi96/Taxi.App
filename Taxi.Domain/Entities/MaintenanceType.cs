using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class MaintenanceType : AuditableEntity
{
    public string MaintenanceTypeName { get; set; } = string.Empty;

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new HashSet<Maintenance>();
}