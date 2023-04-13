using AlcanceVOLTS.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Models
{
    public class Snack : EntityBase
    {
        public Snack() { }

        public Snack(Guid eventUserId, Guid periodId) {
            EventUserId = eventUserId;
            PeriodId = periodId;
        }

        public Guid EventUserId { get; set; }
        public virtual EventUser EventUser { get; set; }
        public Guid PeriodId { get; set; }
        public virtual Period Period { get; set; } 
    }
}
