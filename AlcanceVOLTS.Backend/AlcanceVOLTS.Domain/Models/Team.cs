using AlcanceVOLTS.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Models
{
    public class Team : EntityBase
    {
        public string Name { get; set; }
        public bool Dynamic { get; set; }

        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }
        public virtual IEnumerable<TeamArea> TeamAreas { get; set; }
    }
}
