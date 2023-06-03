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
    public class TestAttemptListsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestAttemptListsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TestAttemptLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestAttemptList>>> GetTestAttemptLists()
        {
            if (_context.TestAttemptLists == null)
            {
                return NotFound();
            }
            return await _context.TestAttemptLists.ToListAsync();
        }

        // GET: api/TestAttemptLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestAttemptList>> GetTestAttemptList(int id)
        {
            if (_context.TestAttemptLists == null)
            {
                return NotFound();
            }
            var testAttemptList = await _context.TestAttemptLists.FindAsync(id);

            if (testAttemptList == null)
            {
                return NotFound();
            }

            return testAttemptList;
        }

        // PUT: api/TestAttemptLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestAttemptList(int id, TestAttemptList testAttemptList)
        {
            if (id != testAttemptList.AttemptId)
            {
                return BadRequest();
            }

            _context.Entry(testAttemptList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestAttemptListExists(id))
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

        // POST: api/TestAttemptLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestAttemptList>> PostTestAttemptList(TestAttemptList testAttemptList)
        {
            if (_context.TestAttemptLists == null)
            {
                return Problem("Entity set 'AppDbContext.TestAttemptLists'  is null.");
            }
            _context.TestAttemptLists.Add(testAttemptList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestAttemptList", new { id = testAttemptList.AttemptId }, testAttemptList);
        }

        // DELETE: api/TestAttemptLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestAttemptList(int id)
        {
            if (_context.TestAttemptLists == null)
            {
                return NotFound();
            }
            var testAttemptList = await _context.TestAttemptLists.FindAsync(id);
            if (testAttemptList == null)
            {
                return NotFound();
            }

            _context.TestAttemptLists.Remove(testAttemptList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestAttemptListExists(int id)
        {
            return (_context.TestAttemptLists?.Any(e => e.AttemptId == id)).GetValueOrDefault();
        }
    }
}
