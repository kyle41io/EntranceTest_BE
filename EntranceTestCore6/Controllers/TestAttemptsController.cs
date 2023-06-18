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
    public class TestAttemptsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestAttemptsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TestAttempts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestAttempt>>> GetTestAttempts()
        {
            if (_context.TestAttempts == null)
            {
                return NotFound();
            }
            return await _context.TestAttempts.ToListAsync();
        }

        // GET: api/TestAttempts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestAttempt>> GetTestAttempt(int id)
        {
            if (_context.TestAttempts == null)
            {
                return NotFound();
            }
            var testAttempt = await _context.TestAttempts.FindAsync(id);

            if (testAttempt == null)
            {
                return NotFound();
            }

            return testAttempt;
        }

        // PUT: api/TestAttempts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestAttempt(int id, TestAttempt testAttempt)
        {
            if (id != testAttempt.AttemptId)
            {
                return BadRequest();
            }

            _context.Entry(testAttempt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestAttemptExists(id))
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

        // POST: api/TestAttempts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestAttempt>> PostTestAttempt(TestAttempt testAttempt)
        {
            if (_context.TestAttempts == null)
            {
                return Problem("Entity set 'AppDbContext.TestAttempts'  is null.");
            }
            _context.TestAttempts.Add(testAttempt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestAttempt", new { id = testAttempt.AttemptId }, testAttempt);
        }

        // DELETE: api/TestAttempts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestAttempt(int id)
        {
            if (_context.TestAttempts == null)
            {
                return NotFound();
            }
            var testAttempt = await _context.TestAttempts.FindAsync(id);
            if (testAttempt == null)
            {
                return NotFound();
            }

            _context.TestAttempts.Remove(testAttempt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestAttemptExists(int id)
        {
            return (_context.TestAttempts?.Any(e => e.AttemptId == id)).GetValueOrDefault();
        }
    }
}
