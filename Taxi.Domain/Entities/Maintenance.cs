using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class Maintenance : AuditableEntity
{
    public DateTime DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public int? Price { get; set; }
    public int Mileage { get; set; }
    public string Description { get; set; } = string.Empty;
    public int MaintenanceTypeId { get; set; }
    public int CarId { get; set; }

    public virtual MaintenanceType MaintenanceType { get; set; } = default!;
    public virtual Car Car { get; set; } = default!;
}