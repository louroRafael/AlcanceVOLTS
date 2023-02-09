using AlcanceVOLTS.Domain.Dtos.Team;
using AlcanceVOLTS.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Models
{
    public class TeamArea : EntityBase
    {
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
        public Guid AreaId { get; set; }
        public virtual Area Area { get; set; }

        #region Operators

        public static implicit operator TeamArea(TeamAreaDTO teamAreaDTO)
        {
            var teamArea = new TeamArea();

            teamArea.TeamId = teamAreaDTO.TeamId;
            teamArea.AreaId = teamAreaDTO.AreaId;

            return teamArea;
        }

        #endregion Operators
    }
}
