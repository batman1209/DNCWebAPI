using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPIDNC.Models;

namespace WebAPIDNC.Controllers
{
    [Route("api/Teachers")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly AptitudeTestContext _context;

        public RolesController(AptitudeTestContext context)
        {
            _context = context;
        }

        // GET: Teachers
        [HttpGet, ActionName("GetAllTeachers")]
        public async Task<List<Role>> GetAllTeachers()
        {
            return await _context.Role.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<Role> GetbyId(int id)
        {
            return _context.Role.Find(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> Delete(int id)
        {
            var role = await _context.Role.FindAsync(id);
            if (role == null)
            {
                return BadRequest();
            }
            _context.Role.Remove(role);
            await _context.SaveChangesAsync();
            return role;

        }








        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TeacherId,Name,Email,Password,Gender,Image")] Teacher teacher)
        {

            _context.Add(teacher);
            _context.SaveChanges();
            //return RedirectToAction(actionName: nameof(GetAllTeachers));
            return RedirectToAction();


        }



    }
}
