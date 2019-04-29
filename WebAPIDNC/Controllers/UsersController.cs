using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPIDNC.Models;

namespace WebAPIDNC.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    //[Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AptitudeTestContext _context;

        public UsersController(AptitudeTestContext context)
        {
            _context = context;
        }

        // GET: api/Admin
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _context.Users.ToList();

        }

        // GET: api/Admin/5
        [HttpGet("{id}", Name = "Get")]
        public Users Get(int id)
        {
            Users user = _context.Users.Find(id);
            UserRole userRole = _context.UserRole.FirstOrDefault(c => c.UserId == id);
            if (userRole != null)
            {
                user.RoleID = userRole.RoleId;
            }
            // user.RoleID = userRole.RoleId;
            return user;
        }

        // POST: api/Admin
        [HttpPost]
        public async Task<ActionResult<Users>> Post([FromBody]Users user)
        {
            try
            {
                _context.Users.Add(user);

                await _context.SaveChangesAsync();
                if (user != null)
                {
                    var userRole = new UserRole();
                    //var role = new Role();
                    userRole.UserId = user.UserId;
                    userRole.RoleId = user.RoleID;
                    _context.UserRole.Add(userRole);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Users>> Put(int id, Users user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;

        }

        // GET: api/Admin
        [HttpGet("getRole")]
        public IEnumerable<Role> GetRoles()
        {
            return _context.Role.ToList();
        }

        public string Token()
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopqwertyuiop"));
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: signInCred
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            var user = _context.Users.FirstOrDefault(t => t.Name == model.UserName && t.Password == model.Password);

            if (user != null)
            {
                return Ok(Token());
            }
            else
            {
                return BadRequest(false);
            }
        }

    }
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
