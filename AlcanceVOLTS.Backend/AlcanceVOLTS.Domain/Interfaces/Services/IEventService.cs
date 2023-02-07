using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.Event;
using AlcanceVOLTS.Domain.Dtos.User;
using AlcanceVOLTS.Domain.Interfaces.Common;
using AlcanceVOLTS.Domain.Models;

namespace AlcanceVOLTS.Domain.Interfaces.Services
{
    public interface IEventService : ICrudServiceBase<Event>
    {
        ///<summary> Save Or Update Event </summary>
        Task<Guid> CreateOrUpdateAsync(RegisterEventDTO eventDTO);

        ///<summary> Get List Of Events By Filter </summary>
        Task<List<EventDTO>> GetAllByFilter(FilterDTO filter);

        ///<summary> Get List Of Volunteers By Event </summary>
        Task<List<VolunteerDTO>> GetVolunteersByEvent(Guid eventId);
    }
}
