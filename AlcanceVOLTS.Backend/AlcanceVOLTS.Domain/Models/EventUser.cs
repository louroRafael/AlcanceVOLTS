using AlcanceVOLTS.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Models
{
    public class EventUser : EntityBase
    {

        public EventUser(Guid eventId, Guid userId) {
            EventId = eventId;
            UserId = userId;
        }

        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }
        public Guid? TeamId { get; set; }
        public virtual Team? Team { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
