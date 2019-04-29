using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDNC.Models;

namespace WebAPIDNC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly AptitudeTestContext _context;

        public QuestionsController(AptitudeTestContext context)
        {
            _context = context;
        }

        // GET: api/Admin
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return _context.Question.ToList();
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public Question Get(int id)
        {
            return _context.Question.Find(id);

        }

        // POST: api/Admin
        [HttpPost]
        public async Task<ActionResult<Question>> Post([FromBody]Question ques)
        {
            try
            {
                _context.Question.Add(ques);
                await _context.SaveChangesAsync();
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
        public async Task<ActionResult<Question>> Put(int id, Question ques)
        {
            if (id != ques.QuesId)
            {
                return BadRequest();
            }

            _context.Entry(ques).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> Delete(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return BadRequest();
            }
            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();
            return teacher;

        }
    }
}