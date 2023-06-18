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
    public class TestQuestionAttemptsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestQuestionAttemptsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TestQuestionAttempts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestQuestionAttempt>>> GetTestQuestionAttempts()
        {
          if (_context.TestQuestionAttempts == null)
          {
              return NotFound();
          }
            return await _context.TestQuestionAttempts.ToListAsync();
        }

        // GET: api/TestQuestionAttempts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestQuestionAttempt>> GetTestQuestionAttempt(int id)
        {
          if (_context.TestQuestionAttempts == null)
          {
              return NotFound();
          }
            var testQuestionAttempt = await _context.TestQuestionAttempts.FindAsync(id);

            if (testQuestionAttempt == null)
            {
                return NotFound();
            }

            return testQuestionAttempt;
        }

        // PUT: api/TestQuestionAttempts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestQuestionAttempt(int id, TestQuestionAttempt testQuestionAttempt)
        {
            if (id != testQuestionAttempt.AttemptQuestionId)
            {
                return BadRequest();
            }

            _context.Entry(testQuestionAttempt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestQuestionAttemptExists(id))
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

        // POST: api/TestQuestionAttempts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestQuestionAttempt>> PostTestQuestionAttempt(TestQuestionAttempt testQuestionAttempt)
        {
          if (_context.TestQuestionAttempts == null)
          {
              return Problem("Entity set 'AppDbContext.TestQuestionAttempts'  is null.");
          }
            _context.TestQuestionAttempts.Add(testQuestionAttempt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestQuestionAttempt", new { id = testQuestionAttempt.AttemptQuestionId }, testQuestionAttempt);
        }

        // DELETE: api/TestQuestionAttempts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestQuestionAttempt(int id)
        {
            if (_context.TestQuestionAttempts == null)
            {
                return NotFound();
            }
            var testQuestionAttempt = await _context.TestQuestionAttempts.FindAsync(id);
            if (testQuestionAttempt == null)
            {
                return NotFound();
            }

            _context.TestQuestionAttempts.Remove(testQuestionAttempt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestQuestionAttemptExists(int id)
        {
            return (_context.TestQuestionAttempts?.Any(e => e.AttemptQuestionId == id)).GetValueOrDefault();
        }
    }
}
