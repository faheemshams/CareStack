using BuisnessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BuisnessLayer.LoginImplementation
{
    public class Login : ILogin
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        public Login(IRepository<User> userRepository, IConfiguration configuration)
        {
            this._userRepository = userRepository;
            this._configuration = configuration; 
        }

        public string? login(User user)
        {
            var validateUser = _userRepository.GetAllItems().FirstOrDefault(x => x.username == user.username && x.password == user.password);

            if (validateUser != null)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims: new List<Claim>(),
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return JsonConvert.SerializeObject(tokenString);

            }
            else
                return null;
        }

        public void signUp(User userCredentials)
        {
            throw new NotImplementedException();
        }
    }
}
