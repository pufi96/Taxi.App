using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class CarBrand : AuditableEntity
{
    public string CarBrandName { get; set; } = string.Empty;
    public virtual ICollection<CarModel> CarModels { get; set; } = new HashSet<CarModel>();
}