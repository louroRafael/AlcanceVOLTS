using AlcanceVOLTS.Domain.Dtos.Common;
using Microsoft.AspNetCore.Mvc;

namespace AlcanceVOLTS.API.Controllers.Common
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ResponseOK(object result = null)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            if (result == null)
                return Ok();

            return Ok(result);
        }

        protected IActionResult ResponseFail(Exception ex = null)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            if (ex == null)
                return BadRequest();

            return Ok(new FailDTO(ex));
        }

        protected string GetClaim(string claimType) => User?.Claims?.FirstOrDefault(x => x.Type == claimType)?.Value;
    }
}
