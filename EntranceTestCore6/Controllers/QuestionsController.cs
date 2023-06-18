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
    public class QuestionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuestionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
          if (_context.Questions == null)
          {
              return NotFound();
          }
            return await _context.Questions.ToListAsync();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
          if (_context.Questions == null)
          {
              return NotFound();
          }
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
          if (_context.Questions == null)
          {
              return Problem("Entity set 'AppDbContext.Questions'  is null.");
          }
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.QuestionId }, question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            if (_context.Questions == null)
            {
                return NotFound();
            }
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.QuestionId == id)).GetValueOrDefault();
        }
    }
}*/
using EntranceTestCore6.Data;
using EntranceTestCore6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntranceTestCore6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuestionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionModel>>> GetQuestions()
        {
            var questions = await _context.Questions
                .Select(q => new QuestionModel
                {
                    TestId = q.TestId,
                    Content = q.Content,
                    Answer1 = q.Answer1,
                    Answer2 = q.Answer2,
                    Answer3 = q.Answer3,
                    Answer4 = q.Answer4,
                    CorrectAnswer = q.CorrectAnswer
                })
                .ToListAsync();

            return questions;
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionModel>> GetQuestion(int id)
        {
            var question = await _context.Questions
                .Where(q => q.QuestionId == id)
                .Select(q => new QuestionModel
                {
                    TestId = q.TestId,
                    Content = q.Content,
                    Answer1 = q.Answer1,
                    Answer2 = q.Answer2,
                    Answer3 = q.Answer3,
                    Answer4 = q.Answer4,
                    CorrectAnswer = q.CorrectAnswer
                })
                .FirstOrDefaultAsync();

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // POST: api/Questions
        [HttpPost]
        public async Task<ActionResult<Question>> CreateQuestion(QuestionModel questionModel)
        {
            var question = new Question
            {
                TestId = questionModel.TestId,
                Content = questionModel.Content,
                Answer1 = questionModel.Answer1,
                Answer2 = questionModel.Answer2,
                Answer3 = questionModel.Answer3,
                Answer4 = questionModel.Answer4,
                CorrectAnswer = questionModel.CorrectAnswer
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestion), new { id = question.QuestionId }, question);
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, QuestionModel questionModel)
        {
            if (id != questionModel.TestId)
            {
                return BadRequest();
            }

            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            question.TestId = questionModel.TestId;
            question.Content = questionModel.Content;
            question.Answer1 = questionModel.Answer1;
            question.Answer2 = questionModel.Answer2;
            question.Answer3 = questionModel.Answer3;
            question.Answer4 = questionModel.Answer4;
            question.CorrectAnswer = questionModel.CorrectAnswer;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}