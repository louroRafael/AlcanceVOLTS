using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.User;
using AlcanceVOLTS.Domain.Interfaces.Common;
using AlcanceVOLTS.Domain.Models;

namespace AlcanceVOLTS.Domain.Interfaces.Repositories
{
    public interface IUserRepository : ICrudRepositoryBase<User>
    {
        ///<summary> Get List Of Users By Filter </summary>
        Task<List<UserDTO>> GetAllByFilter(FilterDTO filter);
    }
}
