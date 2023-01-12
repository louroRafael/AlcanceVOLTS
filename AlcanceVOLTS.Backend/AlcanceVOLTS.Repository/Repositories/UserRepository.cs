using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.User;
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
    public class UserRepository : CrudRepositoryBase<User>, IUserRepository
    {
        public UserRepository(MainDbContext context) : base(context)
        {
        }

        public async Task<List<UserDTO>> GetAllByFilter(FilterDTO filter)
        {
            var searchText = filter.GeneralSearch.ToUpper();

            var result = await Query()
                            .Select(x => new UserDTO(x))
                            .ToListAsync();
            return result;
        }
    }
}
