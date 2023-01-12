using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.User;
using AlcanceVOLTS.Domain.Interfaces.Common;
using AlcanceVOLTS.Domain.Models;

namespace AlcanceVOLTS.Domain.Interfaces.Services
{
    public interface IUserService : ICrudServiceBase<User>
    {
        ///<summary> User Authenticate </summary>
        Task<User> UserAuthenticate(string email, string password);

        ///<summary> Get User By E-mail </summary>
        Task<User> GetUserByEmail(string email);

        ///<summary> Get List Of Users By Filter </summary>
        Task<List<UserDTO>> GetAllByFilter(FilterDTO filter);
    }
}
