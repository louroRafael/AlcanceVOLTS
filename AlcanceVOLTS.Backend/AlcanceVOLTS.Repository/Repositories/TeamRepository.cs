using AlcanceVOLTS.Domain.Dtos.Team;
using AlcanceVOLTS.Domain.Interfaces.Repositories;
using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Repository.Contexts;
using AlcanceVOLTS.Repository.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Repository.Repositories
{
    public class TeamRepository : CrudRepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(MainDbContext context) : base(context)
        {
        }

        public async Task<List<TeamDTO>> GetByEvent(Guid eventId)
        {
            return await Query()
                .Where(x => x.EventId == eventId)
                .Select(x => new TeamDTO(x))
                .ToListAsync();
        }
    }
}
