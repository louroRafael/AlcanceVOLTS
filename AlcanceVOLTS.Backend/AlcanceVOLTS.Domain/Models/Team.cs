using AlcanceVOLTS.Domain.Dtos.Team;
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


        #region Operators

        public static implicit operator Team(RegisterTeamDTO teamDTO)
        {
            Team team = new Team();

            team.Name = teamDTO.Name;
            team.Dynamic = teamDTO.Dynamic;
            team.EventId = teamDTO.EventId;
            team.TeamAreas = teamDTO.TeamAreas.Select(x => (TeamArea)x).ToList();

            return team;
        }

        #endregion Operators
    }
}
