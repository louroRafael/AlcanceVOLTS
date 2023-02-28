using AlcanceVOLTS.Domain.Dtos.User;
using AlcanceVOLTS.Domain.Interfaces.Common;
using AlcanceVOLTS.Domain.Models;

namespace AlcanceVOLTS.Domain.Interfaces.Repositories
{
    public interface IEventUserRepository : ICrudRepositoryBase<EventUser>
    {
        ///<summary> Save Event User </summary>
        Task SaveAsync(VolunteerDTO volunteer);
    }
}
