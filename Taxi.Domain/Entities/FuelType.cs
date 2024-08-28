using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class FuelType : AuditableEntity
    {
    public string FuelTypeName { get; set; } = string.Empty;
    public virtual IEnumerable<Car> Cars { get; set; } = new HashSet<Car>();
}