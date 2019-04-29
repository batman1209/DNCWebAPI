
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using WebAPIDNC.Models;

//namespace JWTwebAPI.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/login")]
//    public class LoginController : Controller
//    {
//        private readonly AptitudeTestContext _context;
//        public IActionResult GenerateToken()
//        {
//            var header = Request.Headers["Authorization"];
//            if (header.ToString().StartsWith("Basic"))
//            {
//                var credValue = header.ToString().Substring("Basic".Length).Trim();
//                var usernameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));//admin:pass
//                var usernameAndPass = usernameAndPassenc.Split(":");
//                //check if DB username ans password exists

//                if (usernameAndPass[0] == "Admin" && usernameAndPass[1] == "pass")
//                {
//                    var claimsdata = new[] { new Claim(ClaimTypes.Name, usernameAndPass[0]) };
//                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopqwertyuiop"));
//                    var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
//                    var token = new JwtSecurityToken(
//                        issuer: "mysite.com",
//                        audience: "mysite.com",
//                        expires: DateTime.Now.AddMinutes(1),
//                        claims: claimsdata,
//                        signingCredentials: signInCred
//                        );
//                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
//                    return Ok(tokenString);
//                }
//                //return View();}

//            }
//            return BadRequest("wrong request");
//        }


//        [HttpPost("token")]
//        public async Task<IActionResult> Token([FromBody] Teacher admin)
//        {

//            var user = await _context.Teacher.FindAsync(admin.Email);

//            if (user == null)
//            {
//                return BadRequest();
//            }
//            var header = Request.Headers["Authorization"];
//            if (header.ToString().StartsWith("Basic"))
//            {
//                var credValue = admin.ToString().Substring("Basic".Length).Trim();
//                var usernameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));//admin:pass
//                var usernameAndPass = usernameAndPassenc.Split(":");
//                //check if DB username ans password exists

//                if (usernameAndPass[0] == "Admin" && usernameAndPass[1] == "pass")
//                {
//                    var claimsdata = new[] { new Claim(ClaimTypes.Name, usernameAndPass[0]) };
//                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopqwertyuiop"));
//                    var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
//                    var token = new JwtSecurityToken(
//                        issuer: "mysite.com",
//                        audience: "mysite.com",
//                        expires: DateTime.Now.AddMinutes(1),
//                        claims: claimsdata,
//                        signingCredentials: signInCred
//                        );
//                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
//                    return Ok(tokenString);
//                }
//                //return View();}

//            }
//            return BadRequest("wrong request");
//        }

//    }

//}

////        private Task GenarateToken(Teacher user)
////        {
////            throw new NotImplementedException();
////        }
////    }
////}