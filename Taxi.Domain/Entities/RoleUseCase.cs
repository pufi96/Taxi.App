using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class RoleUseCase : AuditableEntity
{
    public int RoleId { get; set; }
    public int UseCaseId { get; set; }

    public virtual Role Role { get; set; } = default!;
}