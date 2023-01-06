using AlcanceVOLTS.API.Auth;
using System.Security.Claims;

namespace AlcanceVOLTS.API.Controllers.Common
{
    [BearerAuthorize]
    public abstract class AuthenticatedController : BaseController
    {
        public Guid UserId { get { return Guid.Parse(this.GetClaim(ClaimTypes.NameIdentifier)); } }
        public string UserName { get { return this.GetClaim(ClaimTypes.Name); } }
        public string UserMail { get { return this.GetClaim(ClaimTypes.Email); } }
    }
}
