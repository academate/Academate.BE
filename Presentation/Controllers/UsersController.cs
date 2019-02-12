using Application.Services.AccessControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IAuthenticationService authenticationService, ILogger<UsersController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        /// <summary>
        /// Generate Authentication Token.
        /// </summary>
        /// <param name="credential">User Credentials</param>
        /// <response code="200">Authentication passed</response>
        /// <response code="400">Authentication failed</response>
        /// 
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]CredentialViewModel credential)
        {
            var user = _authenticationService.Authenticate(credential.UserName, credential.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect!" });

            return Ok(user);
        }
    }
}
