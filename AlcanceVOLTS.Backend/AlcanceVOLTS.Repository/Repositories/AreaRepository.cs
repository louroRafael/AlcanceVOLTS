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
    public class AreaRepository : CrudRepositoryBase<Area>, IAreaRepository
    {
        public AreaRepository(MainDbContext context) : base(context)
        {
        }

        public async Task<List<Area>> GetAllByFilter(FilterDTO filter)
        {
            var searchText = filter.GeneralSearch.ToUpper();

            var result = await Query().OrderBy(x => x.Name).ToListAsync();
                            
            return result;
        }
    }
}
