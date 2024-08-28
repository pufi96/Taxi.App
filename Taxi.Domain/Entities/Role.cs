using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class Role : AuditableEntity
{
    public string RoleName { get; set; }  = string.Empty;

    public virtual IEnumerable<RoleUseCase> RoleUseCases { get; set; } = new HashSet<RoleUseCase>();
    public virtual IEnumerable<User> Users { get; set; } = new HashSet<User>();
}