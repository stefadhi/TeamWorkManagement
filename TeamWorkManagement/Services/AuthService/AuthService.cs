using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TeamWorkManagement.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Task<string> Login(UserLogin userLogin)
        {
            var token = "";

            var user = _context.Users.Where(x => x.Username == userLogin.Username).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidOperationException("Invalid username or password.");
            }
            else if (!BCrypt.Net.BCrypt.Verify(userLogin.Password, user.PasswordHash))
            {
                throw new InvalidOperationException("Invalid username or password.");
            }
            else
            {
                token = CreateToken(user);
            }

            return Task.FromResult(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
