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

        public VolunteerDTO(Models.User user)
        {
            Id = user.Id.ToString();
            Name = user.Name;
            Email = user.Login;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
