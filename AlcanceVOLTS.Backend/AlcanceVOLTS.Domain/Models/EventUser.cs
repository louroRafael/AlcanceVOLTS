using AlcanceVOLTS.Domain.Enums;
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

        public bool TeamLeader { get; set; }
        public bool Button { get; set; }
        public bool Tshirt { get; set; }
        public TshirtSize TshirtSize { get; set; }
        public bool Wristband { get; set; }
        public bool Badge { get; set; }
        public string BadgeLabel { get; set; }
        public bool WalkieTalkie { get; set; }
        public int WalkieTalkieNumber { get; set; }
        public bool CheckIn { get; set; }
        public virtual List<Snack> Snacks { get; set; }

        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }
        public Guid? TeamId { get; set; }
        public virtual Team? Team { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
