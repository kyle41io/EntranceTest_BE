using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntranceTestCore6.Data;

namespace EntranceTestCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionListsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuestionListsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/QuestionLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionList>>> GetQuestionLists()
        {
          if (_context.QuestionLists == null)
          {
              return NotFound();
          }
            return await _context.QuestionLists.ToListAsync();
        }

        // GET: api/QuestionLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionList>> GetQuestionList(int id)
        {
          if (_context.QuestionLists == null)
          {
              return NotFound();
          }
            var questionList = await _context.QuestionLists.FindAsync(id);

            if (questionList == null)
            {
                return NotFound();
            }

            return questionList;
        }

        // PUT: api/QuestionLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionList(int id, QuestionList questionList)
        {
            if (id != questionList.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(questionList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QuestionLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionList>> PostQuestionList(QuestionList questionList)
        {
          if (_context.QuestionLists == null)
          {
              return Problem("Entity set 'AppDbContext.QuestionLists'  is null.");
          }
            _context.QuestionLists.Add(questionList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionList", new { id = questionList.QuestionId }, questionList);
        }

        // DELETE: api/QuestionLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionList(int id)
        {
            if (_context.QuestionLists == null)
            {
                return NotFound();
            }
            var questionList = await _context.QuestionLists.FindAsync(id);
            if (questionList == null)
            {
                return NotFound();
            }

            _context.QuestionLists.Remove(questionList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionListExists(int id)
        {
            return (_context.QuestionLists?.Any(e => e.QuestionId == id)).GetValueOrDefault();
        }
    }
}
