using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tekever.ShowTracker.Domain.Domain;
using Tekever.ShowTracker.Domain.Interfaces;
using Tekever.ShowTracker.Services.Interfaces;

namespace Tekever.ShowTracker.Web.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
	{
        private readonly IConfiguration _config;
        private readonly IGoogleAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IConfiguration config, 
                    IGoogleAuthenticationService authenticationService, 
                    ITokenService tokenService,
                    IUserRepository userRepository)
        {
            _config = config;
            _authenticationService = authenticationService;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("authentication")]
        public async void Authentication()
        {
            Response.Redirect(await _authenticationService.Authentication());
            //return await _authenticationService.Authentication();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Route("authentication-dev")]
        public async void AuthenticationDevelopment()
        {
            Response.Redirect(await _authenticationService.Authentication());
        }

        //  [EnableCors]
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Route("authentication/google-login")]
        public async Task<string> GoogleLogin([FromQuery] string code)
        {
            var idToken = await _authenticationService.GetIdToken(code);

            var token = _tokenService.ReadGoogleToken(idToken);

            var user = await _userRepository.GetByEmail(token.Email);
            if (user == null)
            {
                user = await _userRepository.AddUser(
                    new User(
                        _tokenService.GoogleIdToGuid(token.Id), 
                        token.Name + " " + token.Surname, 
                        token.Email)
                    );
            }

            token.Id = user.Id.ToString();
            var appTokenString = _tokenService.WriteJwtAppToken(token);
            return appTokenString;
            /*HttpContext.Session.SetString(_config["CookieTokenKey"], appTokenString);
            Response.Cookies.Append(_config["CookieTokenKey"], appTokenString);

            return RedirectPermanent(_config["redirectUrl"]);*/
        }
        /*
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Route("authentication/google-logout")]
        public async Task<IActionResult> GoogleLogout()
        {
            return await Task.Run(() =>
            {
                HttpContext.Session.Remove(_config["CookieTokenKey"]);
                Response.Cookies.Delete(_config["CookieTokenKey"]);
                return StatusCode(200);
            });
        }*/
    }
}
