using JwtAuth.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Service.A.Api.Services;

namespace Service.A.Api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase {
        private readonly IJwtAuthService _jwtAuthService;
        private readonly IUserService _userService;

        public AuthController(IJwtAuthService jwtAuthService, IUserService userService) {
            _jwtAuthService = jwtAuthService;
            _userService = userService;
        }

        /// <summary>
        /// 登入帳密驗證
        /// </summary>
        /// <param name="request">使用者帳密</param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request) {
            if (_userService.ValidateCredentials(request.Username, request.Password)) {
                var token = _jwtAuthService.GenerateToken(request.Username, new[] { "ServiceAUser" });
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}