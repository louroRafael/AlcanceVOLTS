using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.Team
{
    public class TeamAreaDTO
    {
        public Guid TeamId { get; set; }
        public Guid AreaId { get; set; }
        public Guid? PeriodId { get; set; }
    }
}
