using AlcanceVOLTS.API.Auth;
using AlcanceVOLTS.API.Controllers.Common;
using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.Event;
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

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [BearerAuthorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromBody] RegisterEventDTO eventModel) 
        {
            await _eventService.SaveAsync(eventModel);
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
        public async Task<IActionResult> ListUsers([FromBody] FilterDTO filter)
        {
            return ResponseOK(await _eventService.GetAllByFilter(filter));
        }
    }
}
