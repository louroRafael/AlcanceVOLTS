using AlcanceVOLTS.API.Auth;
using AlcanceVOLTS.API.Controllers.Common;
using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.Event;
using AlcanceVOLTS.Domain.Dtos.Team;
using AlcanceVOLTS.Domain.Dtos.User;
using AlcanceVOLTS.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlcanceVOLTS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : AuthenticatedController
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;
        private readonly ITeamService _teamService;

        public EventController(IEventService eventService, IUserService userService, ITeamService teamService)
        {
            _eventService = eventService;
            _userService = userService;
            _teamService = teamService;
        }

        [BearerAuthorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromBody] RegisterEventDTO eventModel) 
        {
            return ResponseOK(await _eventService.CreateOrUpdateAsync(eventModel));
        }

        [BearerAuthorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _eventService.DeleteAsync(id);
            return ResponseOK();
        }

        [BearerAuthorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return ResponseOK(await _eventService.GetAsync(Guid.Parse(id)));
        }

        [BearerAuthorize]
        [HttpPost("list")]
        public async Task<IActionResult> ListEvents([FromBody] FilterDTO filter)
        {
            return ResponseOK(await _eventService.GetAllByFilter(filter));
        }

        [BearerAuthorize]
        [HttpPut("import-volunteers/{id}")]
        public async Task<IActionResult> ImportVolunteers([FromBody] List<VolunteerDTO> volunteers, string id)
        {
            await _userService.ImportVolunteers(volunteers, Guid.Parse(id));
            return ResponseOK();
        }

        [BearerAuthorize]
        [HttpGet("list-volunteers/{id}")]
        public async Task<IActionResult> ListVolunteers(string id)
        {
            return ResponseOK(await _eventService.GetVolunteersByEvent(Guid.Parse(id)));
        }

        [BearerAuthorize]
        [HttpPost("save-volunteer")]
        public async Task<IActionResult> SaveVolunteer([FromBody] VolunteerDTO volunteerDTO) {
            await _eventService.SaveVolunteer(volunteerDTO);
            return ResponseOK();
        }

        [BearerAuthorize]
        [HttpPost("check-in")]
        public async Task<IActionResult> CheckIn([FromBody] VolunteerDTO volunteerDTO)
        {
            await _eventService.CheckIn(volunteerDTO);
            return ResponseOK();
        }

        [BearerAuthorize]
        [HttpPost("save-team")]
        public async Task<IActionResult> SaveTeam([FromBody] RegisterTeamDTO teamModel)
        {
            await _teamService.SaveAsync(teamModel);
            return ResponseOK();
        }

        [BearerAuthorize]
        [HttpGet("get-teams/{id}")]
        public async Task<IActionResult> GetTeams(Guid id)
        {
            return ResponseOK(await _teamService.GetByEvent(id));
        }
    }
}
