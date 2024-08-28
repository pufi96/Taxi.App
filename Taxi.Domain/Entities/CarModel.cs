using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class CarModel : AuditableEntity
{
    public string CarModelName { get; set; } = string.Empty;
    public int CarBrandId { get; set; }

    public virtual CarBrand CarBrand { get; set; } = default!;
    public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
}