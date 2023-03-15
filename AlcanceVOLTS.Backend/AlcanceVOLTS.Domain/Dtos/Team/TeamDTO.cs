﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.Team
{
    public class TeamDTO
    {
        public TeamDTO()
        {
        }

        public TeamDTO(Models.Team team)
        {
            Id = team.Id;
            Name = team.Name;
            Dynamic = team.Dynamic ? "Rotativa" : "Fixa";
            TeamAreas = team.TeamAreas.Select(x => new TeamAreaDTO(x)).ToList();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Dynamic { get; set; }
        public List<TeamAreaDTO> TeamAreas { get; set; }
    }
}
