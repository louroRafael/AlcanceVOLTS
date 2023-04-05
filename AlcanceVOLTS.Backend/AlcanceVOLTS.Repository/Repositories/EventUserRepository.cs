using AlcanceVOLTS.Domain.Dtos.User;
using AlcanceVOLTS.Domain.Interfaces.Repositories;
using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Repository.Contexts;
using AlcanceVOLTS.Repository.Repositories.Common;

namespace AlcanceVOLTS.Repository.Repositories
{
    public class EventUserRepository : CrudRepositoryBase<EventUser>, IEventUserRepository
    {
        public EventUserRepository(MainDbContext context) : base(context)
        {
        }

        public async Task SaveAsync(VolunteerDTO volunteerDTO)
        {
            var volunteer = await GetAsync(volunteerDTO.Id);

            volunteer.TeamId = volunteerDTO.Team?.Id;
            volunteer.TeamLeader = volunteerDTO.TeamLeader;
            volunteer.TshirtSize = volunteerDTO.TshirtSize;

            await SaveAsync(volunteer);
        }

        public async Task CheckInAsync(VolunteerDTO volunteerDTO)
        {
            var volunteer = await GetAsync(volunteerDTO.Id);

            volunteer.Button = volunteerDTO.Button;
            volunteer.Tshirt = volunteerDTO.Tshirt;
            volunteer.Wristband = volunteerDTO.Wristband;
            volunteer.Badge = volunteerDTO.Badge;
            volunteer.WalkieTalkie = volunteerDTO.WalkieTalkie;
            volunteer.WalkieTalkieNumber = volunteerDTO.WalkieTalkieNumber;

            await SaveAsync(volunteer);
        }
    }
}
