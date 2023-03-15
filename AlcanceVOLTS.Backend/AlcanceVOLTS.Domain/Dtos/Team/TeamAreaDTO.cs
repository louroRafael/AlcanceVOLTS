using AlcanceVOLTS.Domain.Dtos.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.Team
{
    public class TeamAreaDTO
    {
        public TeamAreaDTO()
        {
        }

        public TeamAreaDTO(Models.TeamArea teamAreaModel)
        {
            TeamId = teamAreaModel.TeamId;
            AreaId = teamAreaModel.AreaId?.ToString() ?? "";
            AreaName = teamAreaModel.Area?.Name ?? "Descanso";
            PeriodId = teamAreaModel.PeriodId;
            Period = new PeriodDTO(teamAreaModel.Period);
        }

        public Guid TeamId { get; set; }
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public Guid PeriodId { get; set; }
        public PeriodDTO Period { get; set; }
    }
}
