using AlcanceVOLTS.API.Auth;
using AlcanceVOLTS.API.Controllers.Common;
using AlcanceVOLTS.Domain.Dtos.Auth;
using AlcanceVOLTS.Domain.Dtos.User;
using AlcanceVOLTS.Domain.Infra.Helpers;
using AlcanceVOLTS.Domain.Infra.Settings;
using AlcanceVOLTS.Domain.Interfaces.Services;
using AlcanceVOLTS.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Net;

namespace AlcanceVOLTS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : AuthenticatedController
    {
        private readonly IUserService _userService;
        private readonly IDistributedCache _cache;
        private readonly AppSettings _appSettings;
        private readonly SigningConfigurations _signingConfigurations;

        public LoginController(IUserService userService,
            IDistributedCache cache,
            AppSettings appSettings,
            SigningConfigurations signingConfigurations)
        {
            this._userService = userService;
            this._cache = cache;
            this._appSettings = appSettings;
            this._signingConfigurations = signingConfigurations;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthRequestDTO authRequestDTO)
        {
            var user = await _userService.UserAuthenticate(authRequestDTO.Email, authRequestDTO.Password);
            if (user == null)
                user = await GetUserByRefreshToken(authRequestDTO);

            if (user == null)
                return StatusCode((int)HttpStatusCode.Forbidden, new AuthResultDTO { Authenticated = false, Message = "Usuário e/ou senha inválidos" });
            else
                return ResponseOK(AuthConfigHelper.GenerateToken(new UserDTO(user), _appSettings, _cache, _signingConfigurations));
        }

        private async Task<User> GetUserByRefreshToken(AuthRequestDTO authRequestDTO)
        {
            if (string.IsNullOrWhiteSpace(authRequestDTO?.Email) || string.IsNullOrWhiteSpace(authRequestDTO?.RefreshToken))
                return null;

            var storedToken = _cache.GetString(authRequestDTO.RefreshToken);

            if (string.IsNullOrWhiteSpace(storedToken))
                return null;

            var refreshTokenDataStored = JsonConvert.DeserializeObject<RefreshTokenData>(storedToken);

            if (refreshTokenDataStored == null)
                return null;

            if (authRequestDTO.Email == refreshTokenDataStored.Email && authRequestDTO.RefreshToken == refreshTokenDataStored.RefreshToken)
                return await _userService.GetUserByEmail(authRequestDTO.Email);

            return null;
        }
    }
}
