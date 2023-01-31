using EMS.Models.Domain;
using EMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenhandler tokenhandler;

        public AuthController(IUserRepository userRepository, ITokenhandler tokenhandler)
        {
            this.userRepository = userRepository;
            this.tokenhandler = tokenhandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAync([FromBody] Models.DTO.LoginRequest loginReq)
        {
            // Check if user is authenticated
            // check username and password
            var user = await userRepository.AuthenticateAsync(loginReq.Email, loginReq.Password);

            if (user != null)
            {
                // Generate JWT token
                var token = await tokenhandler.CreateTokenAsync(user);
                var tk = new Token()
                {
                    Tokenn = token,
                };
                return Ok(tk);

            }

            return BadRequest("Username and password is incorrect");

        }
    }
}
