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
        private readonly IEventService _eventService;

        public UserService(IUserRepository repository, 
            IEventService eventService) : base(repository)
        {
            _repository = repository;
            _eventService = eventService;
        }

        public async Task<User> UserAuthenticate(string email, string password) => await _repository.FirstOrDefaultAsync(u => u.Login.Equals(email) && !string.IsNullOrEmpty(password) && u.Password.Equals(password.ToMD5()));

        public async Task<User> GetUserByEmail(string email) => await _repository.FirstOrDefaultAsync(u => u.Login.Equals(email));

        public async Task<List<UserDTO>> GetAllByFilter(FilterDTO filter) => await _repository.GetAllByFilter(filter);

        public async Task ImportVolunteers(List<VolunteerDTO> volunteers, Guid eventId)
        {
            foreach (var volunteer in volunteers)
            {
                var user = await GetUserByEmail(volunteer.Email);

                if (user == null)
                {
                    user = new User(volunteer.Name, volunteer.Email);
                    await SaveAsync(user);
                }

                var eventUser = new EventUser(eventId, user.Id);
                user.EventUsers.Add(eventUser);

                await SaveAsync(user);
            }
        }
    }
}
