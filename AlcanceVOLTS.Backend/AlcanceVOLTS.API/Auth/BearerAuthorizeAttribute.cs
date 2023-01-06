using Microsoft.AspNetCore.Authorization;

namespace AlcanceVOLTS.API.Auth
{
    public class BearerAuthorizeAttribute : AuthorizeAttribute
    {
        public BearerAuthorizeAttribute() : base("Bearer")
        {
        }

        public BearerAuthorizeAttribute(params string[] profiles) : base("Bearer") => this.Roles = string.Join(",", profiles);
    }
}
