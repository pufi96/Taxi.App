using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class Car : AuditableEntity
{
    public string Registration { get; set; } = string.Empty;
    public DateTime ValidityOfRegistration { get; set; }
    public int Mileage { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string ChassisNumber { get; set; } = string.Empty;
    public double EngineVolume { get; set; }
    public int HorsePower { get; set; }
    public int FuelTypeId { get; set; }
    public string ImageFilePath { get; set; } = string.Empty;
    public int CarModelId { get; set; }

    public virtual FuelType FuelType { get; set; } = default!;
    public virtual CarModel CarModel { get; set; } = default!;
    public virtual ICollection<Maintenance> Maintenances { get; set; } = new HashSet<Maintenance>();
    public virtual ICollection<Shift> Shifts { get; set; } = new HashSet<Shift>();
}