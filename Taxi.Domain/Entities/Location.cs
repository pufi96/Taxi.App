using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Domain.Common;

namespace Taxi.Domain.Entities;
public class Location : AuditableEntity
{
    public string LocationName { get; set; } = string.Empty;

    public virtual ICollection<LocationPrice> LocationPricesStart { get; set; } = new HashSet<LocationPrice>();
    public virtual ICollection<LocationPrice> LocationPricesEnd { get; set; } = new HashSet<LocationPrice>();
}