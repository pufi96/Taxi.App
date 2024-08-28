namespace Taxi.Aplication.Features;

public class BaseVm
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? EditedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
