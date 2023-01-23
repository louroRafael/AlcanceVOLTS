using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.Event;
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
    public class EventRepository : CrudRepositoryBase<Event>, IEventRepository
    {
        public EventRepository(MainDbContext context) : base(context)
        {
        }

        public async Task<List<EventDTO>> GetAllByFilter(FilterDTO filter)
        {
            var searchText = filter.GeneralSearch.ToUpper();

            var result = await Query()
                            .Select(x => new EventDTO(x))
                            .ToListAsync();
            return result;
        }
    }
}
