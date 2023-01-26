using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.Event;
using AlcanceVOLTS.Domain.Interfaces.Repositories;
using AlcanceVOLTS.Domain.Interfaces.Services;
using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Domain.Services.Common;

namespace AlcanceVOLTS.Domain.Services
{
    public class AreaService : CrudServiceBase<Area>, IAreaService
    {
        private new readonly IAreaRepository _repository;

        public AreaService(IAreaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<Area>> GetAllByFilter(FilterDTO filter) => await _repository.GetAllByFilter(filter);
    }
}
