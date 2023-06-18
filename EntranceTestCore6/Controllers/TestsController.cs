/*using System;
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
    public class TestListsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestListsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TestLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestList>>> GetTestLists()
        {
          if (_context.TestLists == null)
          {
              return NotFound();
          }
            return await _context.TestLists.ToListAsync();
        }

        // GET: api/TestLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestList>> GetTestList(int id)
        {
          if (_context.TestLists == null)
          {
              return NotFound();
          }
            var testList = await _context.TestLists.FindAsync(id);

            if (testList == null)
            {
                return NotFound();
            }

            return testList;
        }

        // PUT: api/TestLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestList(int id, TestList testList)
        {
            if (id != testList.TestId)
            {
                return BadRequest();
            }

            _context.Entry(testList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestListExists(id))
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

        // POST: api/TestLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestList>> PostTestList(TestList testList)
        {
          if (_context.TestLists == null)
          {
              return Problem("Entity set 'AppDbContext.TestLists'  is null.");
          }
            _context.TestLists.Add(testList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestList", new { id = testList.TestId }, testList);
        }

        // DELETE: api/TestLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestList(int id)
        {
            if (_context.TestLists == null)
            {
                return NotFound();
            }
            var testList = await _context.TestLists.FindAsync(id);
            if (testList == null)
            {
                return NotFound();
            }

            _context.TestLists.Remove(testList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestListExists(int id)
        {
            return (_context.TestLists?.Any(e => e.TestId == id)).GetValueOrDefault();
        }
    }
}
*/

