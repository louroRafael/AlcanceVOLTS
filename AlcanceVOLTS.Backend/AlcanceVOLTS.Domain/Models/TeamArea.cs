using AlcanceVOLTS.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Models
{
    public class TeamArea : EntityBase
    {
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
        public Guid AreaId { get; set; }
        public virtual Area Area { get; set; }
    }
}
