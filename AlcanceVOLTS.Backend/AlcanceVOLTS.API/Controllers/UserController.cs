using AlcanceVOLTS.API.Auth;
using AlcanceVOLTS.API.Controllers.Common;
using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlcanceVOLTS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AuthenticatedController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [BearerAuthorize]
        [HttpPost("list")]
        public async Task<IActionResult> ListUsers([FromBody] FilterDTO filter)
        {
            return ResponseOK(await this._userService.GetAllByFilter(filter));
        }
    }
}
