using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.Event;
using AlcanceVOLTS.Domain.Interfaces.Repositories;
using AlcanceVOLTS.Domain.Interfaces.Services;
using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Domain.Services.Common;

namespace AlcanceVOLTS.Domain.Services
{
    public class EventService : CrudServiceBase<Event>, IEventService
    {
        private new readonly IEventRepository _repository;

        public EventService(IEventRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<EventDTO>> GetAllByFilter(FilterDTO filter) => await _repository.GetAllByFilter(filter);
    }
}
