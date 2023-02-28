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
            Team = eventUser.Team != null ? new TeamDTO(eventUser.Team) : null;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public TeamDTO? Team { get; set; }
    }
}
