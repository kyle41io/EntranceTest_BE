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
    public class TestQuestionAttemptListsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestQuestionAttemptListsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TestQuestionAttemptLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestQuestionAttemptList>>> GetTestQuestionAttemptLists()
        {
          if (_context.TestQuestionAttemptLists == null)
          {
              return NotFound();
          }
            return await _context.TestQuestionAttemptLists.ToListAsync();
        }

        // GET: api/TestQuestionAttemptLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestQuestionAttemptList>> GetTestQuestionAttemptList(int id)
        {
          if (_context.TestQuestionAttemptLists == null)
          {
              return NotFound();
          }
            var testQuestionAttemptList = await _context.TestQuestionAttemptLists.FindAsync(id);

            if (testQuestionAttemptList == null)
            {
                return NotFound();
            }

            return testQuestionAttemptList;
        }

        // PUT: api/TestQuestionAttemptLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestQuestionAttemptList(int id, TestQuestionAttemptList testQuestionAttemptList)
        {
            if (id != testQuestionAttemptList.AttemptQuestionId)
            {
                return BadRequest();
            }

            _context.Entry(testQuestionAttemptList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestQuestionAttemptListExists(id))
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

        // POST: api/TestQuestionAttemptLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestQuestionAttemptList>> PostTestQuestionAttemptList(TestQuestionAttemptList testQuestionAttemptList)
        {
          if (_context.TestQuestionAttemptLists == null)
          {
              return Problem("Entity set 'AppDbContext.TestQuestionAttemptLists'  is null.");
          }
            _context.TestQuestionAttemptLists.Add(testQuestionAttemptList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestQuestionAttemptList", new { id = testQuestionAttemptList.AttemptQuestionId }, testQuestionAttemptList);
        }

        // DELETE: api/TestQuestionAttemptLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestQuestionAttemptList(int id)
        {
            if (_context.TestQuestionAttemptLists == null)
            {
                return NotFound();
            }
            var testQuestionAttemptList = await _context.TestQuestionAttemptLists.FindAsync(id);
            if (testQuestionAttemptList == null)
            {
                return NotFound();
            }

            _context.TestQuestionAttemptLists.Remove(testQuestionAttemptList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestQuestionAttemptListExists(int id)
        {
            return (_context.TestQuestionAttemptLists?.Any(e => e.AttemptQuestionId == id)).GetValueOrDefault();
        }
    }
}
