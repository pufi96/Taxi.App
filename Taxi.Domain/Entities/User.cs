using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class User : AuditableEntity
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public double? Earnings { get; set; }
    public int UserRoleId { get; set; }

    public virtual Role UserRole { get; set; } = default!;
    public virtual ICollection<Shift> Shifts { get; set; } = new HashSet<Shift>();
}