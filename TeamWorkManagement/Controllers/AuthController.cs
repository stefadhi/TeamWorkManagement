namespace TeamWorkManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLogin userlogin)
        {
            var result = await _authService.Login(userlogin);
            return Ok(result);
        }
    }
}
