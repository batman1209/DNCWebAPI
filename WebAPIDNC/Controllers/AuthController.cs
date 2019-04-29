//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using WebAPIDNC.Models;

//namespace WebAPIDNC.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]

//    public class AuthController : ControllerBase
//    {
//        private readonly AptitudeTestContext _context;
//        public AuthController(AptitudeTestContext context)
//        {
//            _context = context;
//        }


//        public string Token()
//        {
//            //var header = Request.Headers["Authorization"];
//            //if (header.ToString().StartsWith("Basic"))
//            //{
//            //    var credValue = header.ToString().Substring("Basic".Length).Trim();
//            //    var usernameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));//admin:pass
//            //    var usernameAndPass = usernameAndPassenc.Split(":");
//            //    //check if DB username and password exists

//            //    if (usernameAndPass[0] == "Admin" && usernameAndPass[1] == "pass")
//            //    {

//            //    }
//            //    //return View();}

//            //}
//            //return BadRequest("wrong request");
//            // var claimsdata = new[] { new Claim(ClaimTypes.Name, usernameAndPass[0]) };
//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopqwertyuiop"));
//            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
//            var token = new JwtSecurityToken(
//                issuer: "localhost",
//                audience: "localhost",
//                expires: DateTime.Now.AddMinutes(1),
//                signingCredentials: signInCred
//                );
//            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
//            return tokenString;
//        }

//        [HttpPost("login")]
//        public IActionResult Login([FromBody] LoginDto model)
//        {
//            //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
//            var user = _context.Teacher.FirstOrDefault(t => t.Email == model.Email && t.Password == model.Password);

//            if (user != null)
//            {
//                return Ok(Token());
//            }
//            else
//            {
//                return BadRequest(false);
//            }
//        }

//    }
//    public class LoginDto
//    {
//        public string Email { get; set; }
//        public string Password { get; set; }
//    }


//}