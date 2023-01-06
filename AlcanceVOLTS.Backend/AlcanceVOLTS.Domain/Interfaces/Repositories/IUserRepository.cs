using AlcanceVOLTS.Domain.Interfaces.Common;
using AlcanceVOLTS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Interfaces.Repositories
{
    public interface IUserRepository : ICrudRepositoryBase<User>
    {
    }
}
