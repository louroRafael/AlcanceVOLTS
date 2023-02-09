using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.Team
{
    public class RegisterTeamDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Dynamic { get; set; }
        public Guid EventId { get; set; }
        public List<TeamAreaDTO> TeamAreas { get; set; }
    }
}
