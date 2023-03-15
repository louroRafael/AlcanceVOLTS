using AlcanceVOLTS.Domain.Dtos.Team;
using AlcanceVOLTS.Domain.Models.Common;

namespace AlcanceVOLTS.Domain.Models
{
    public class TeamArea : EntityBase
    {
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
        public Guid? AreaId { get; set; }
        public virtual Area? Area { get; set; }
        public Guid PeriodId { get; set; }
        public virtual Period Period { get; set; }

        #region Operators

        public static implicit operator TeamArea(TeamAreaDTO teamAreaDTO)
        {
            var teamArea = new TeamArea();

            teamArea.TeamId = teamAreaDTO.TeamId;
            teamArea.AreaId = teamAreaDTO.AreaId != "" ? Guid.Parse(teamAreaDTO.AreaId) : null;
            teamArea.PeriodId = teamAreaDTO.PeriodId;

            return teamArea;
        }

        #endregion Operators
    }
}
