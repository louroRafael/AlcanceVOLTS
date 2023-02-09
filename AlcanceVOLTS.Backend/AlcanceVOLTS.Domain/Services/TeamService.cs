using AlcanceVOLTS.Domain.Dtos.Team;
using AlcanceVOLTS.Domain.Interfaces.Repositories;
using AlcanceVOLTS.Domain.Interfaces.Services;
using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Domain.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Services
{
    public class TeamService : CrudServiceBase<Team>, ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository) : base(teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<List<TeamDTO>> GetByEvent(Guid eventId) => await _teamRepository.GetByEvent(eventId);
    }
}
