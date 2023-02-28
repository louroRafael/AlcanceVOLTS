using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.Event;
using AlcanceVOLTS.Domain.Dtos.User;
using AlcanceVOLTS.Domain.Interfaces.Repositories;
using AlcanceVOLTS.Domain.Interfaces.Services;
using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Domain.Services.Common;

namespace AlcanceVOLTS.Domain.Services
{
    public class EventService : CrudServiceBase<Event>, IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IPeriodRepository _periodRepository;
        private readonly IEventUserRepository _eventUserRepository;

        public EventService(IEventRepository eventRepository, 
                            IPeriodRepository periodRepository, 
                            IEventUserRepository eventUserRepository) : base(eventRepository)
        {
            _eventRepository = eventRepository;
            _periodRepository = periodRepository;
            _eventUserRepository = eventUserRepository;
        }

        public async Task<Guid> CreateOrUpdateAsync(RegisterEventDTO eventDTO)
        {
            var eventModel = await _eventRepository.SaveAsync(eventDTO);

            if(eventDTO.Periods != null)
                foreach(var period in eventDTO.Periods)
                    await _periodRepository.SaveAsync(period);

            return eventModel.Id;
        }

        public async Task<List<EventDTO>> GetAllByFilter(FilterDTO filter) => await _eventRepository.GetAllByFilter(filter);

        public async Task<List<VolunteerDTO>> GetVolunteersByEvent(Guid eventId)
        {
            var eventModel = await _repository.GetAsync(eventId);
            return eventModel.EventUsers.Select(x => new VolunteerDTO(x)).ToList();
        }

        public async Task SaveVolunteer(VolunteerDTO volunteer)
        {
            await _eventUserRepository.SaveAsync(volunteer);
        }
    }
}
