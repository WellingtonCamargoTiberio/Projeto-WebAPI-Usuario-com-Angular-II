using Api_Usuario.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mvc_Api_Usuario.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Api_Usuario.Controllers
{
    [EnableCors("CorsApi")]
    public class TokenController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

    public TokenController(SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]

        public async Task<IActionResult> CreateToken([FromBody] InputModel Input)
        {
            if(string.IsNullOrWhiteSpace(Input.UserName) || string.IsNullOrWhiteSpace(Input.Password))
                    return Unauthorized();
            var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
            {
                var token = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("Security_Key-12345678"))
                    .AddSubject("Senhor Caixa")
                    .AddIssuer("ApiUsuario.Security.Bearer")
                    .AddAudience("ApiUsuario.Security.Bearer")
                    .AddClaim("ApiUsuarioNumero", "1")
                    .AddExpiry(5)
                    .Builder();

                return Ok(token.value);
            }
                else
            {
                return Unauthorized();
            }
        }
    }
}
