using AlcanceVOLTS.Domain.Dtos.Team;
using AlcanceVOLTS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.User
{
    public class VolunteerDTO
    {
        public VolunteerDTO()
        {

        }

        public VolunteerDTO(EventUser eventUser)
        {
            Id = eventUser.Id;
            Name = eventUser.User.Name;
            Email = eventUser.User.Login;
            Button = eventUser.Button;
            Tshirt = eventUser.Tshirt;
            TshirtSize = eventUser.TshirtSize.ToString();
            Wristband = eventUser.Wristband;
            Badge = eventUser.Badge;
            BadgeLabel = eventUser.BadgeLabel;
            WalkieTalkie = eventUser.WalkieTalkie;
            WalkieTalkieNumber = eventUser.WalkieTalkieNumber;
            CheckIn = eventUser.CheckIn;
            TeamLeader = eventUser.TeamLeader;
            Team = eventUser.Team != null ? new TeamDTO(eventUser.Team) : null;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Button { get; set; }
        public bool Tshirt { get; set; }
        public string TshirtSize { get; set; }
        public bool Wristband { get; set; }
        public bool Badge { get; set; }
        public string BadgeLabel { get; set; }
        public bool WalkieTalkie { get; set; }
        public int WalkieTalkieNumber { get; set; }
        public bool CheckIn { get; set; }
        public bool TeamLeader { get; set; }
        public TeamDTO? Team { get; set; }
    }
}
