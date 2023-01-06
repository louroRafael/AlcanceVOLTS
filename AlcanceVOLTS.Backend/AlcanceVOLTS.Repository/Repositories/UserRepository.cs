using AlcanceVOLTS.Domain.Interfaces.Repositories;
using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Repository.Contexts;
using AlcanceVOLTS.Repository.Repositories.Common;
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
    }
}
