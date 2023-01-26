using AlcanceVOLTS.API.Auth;
using AlcanceVOLTS.API.Controllers.Common;
using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Interfaces.Services;
using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlcanceVOLTS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : AuthenticatedController
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [BearerAuthorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromBody] Area area)
        {
            await _areaService.SaveAsync(area);
            return ResponseOK();
        }

        [BearerAuthorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _areaService.DeleteAsync(Guid.Parse(id));
            return ResponseOK();
        }

        [BearerAuthorize]
        [HttpPost("list")]
        public async Task<IActionResult> ListAreas([FromBody] FilterDTO filter)
        {
            return ResponseOK(await _areaService.GetAllByFilter(filter));
        }
    }
}
