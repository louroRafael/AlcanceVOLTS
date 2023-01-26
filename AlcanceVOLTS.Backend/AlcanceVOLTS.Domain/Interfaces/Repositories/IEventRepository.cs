using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.Event;
using AlcanceVOLTS.Domain.Interfaces.Common;
using AlcanceVOLTS.Domain.Models;

namespace AlcanceVOLTS.Domain.Interfaces.Repositories
{
    public interface IEventRepository : ICrudRepositoryBase<Event>
    {
        ///<summary> Get List Of Events By Filter </summary>
        Task<List<EventDTO>> GetAllByFilter(FilterDTO filter);
    }
}
