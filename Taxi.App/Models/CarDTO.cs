namespace Taxi.App.Models;

public class CarDTO: BaseDto
{
    public string? Registration { get; set; }
    public DateTime? ValidityOfRegistration { get; set; }
    public int Mileage { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
    public string ChassisNumber { get; set; }
    public double EngineVolume { get; set; }
    public int HorsePower { get; set; }
}