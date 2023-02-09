using AlcanceVOLTS.Domain.Dtos.Team;
using AlcanceVOLTS.Domain.Interfaces.Common;
using AlcanceVOLTS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Interfaces.Repositories
{
    public interface ITeamRepository : ICrudRepositoryBase<Team>
    {
        ///<summary> Get List Of Teams By Event Id </summary>
        Task<List<TeamDTO>> GetByEvent(Guid eventId);
    }
}
