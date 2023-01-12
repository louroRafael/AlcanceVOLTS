using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.User;
using AlcanceVOLTS.Domain.Infra.Helpers;
using AlcanceVOLTS.Domain.Interfaces.Repositories;
using AlcanceVOLTS.Domain.Interfaces.Services;
using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Domain.Services.Common;

namespace AlcanceVOLTS.Domain.Services
{
    public class UserService : CrudServiceBase<User>, IUserService
    {
        private new readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            this._repository = repository;
        }

        public async Task<User> UserAuthenticate(string email, string password) => await _repository.FirstOrDefaultAsync(u => u.Login.Equals(email) && !string.IsNullOrEmpty(password) && u.Password.Equals(password.ToMD5()));

        public async Task<User> GetUserByEmail(string email) => await _repository.FirstOrDefaultAsync(u => u.Login.Equals(email));

        public async Task<List<UserDTO>> GetAllByFilter(FilterDTO filter) => await _repository.GetAllByFilter(filter);
    }
}
