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
                    QuestionId = q.QuestionId,
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
                    QuestionId = q.QuestionId,
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
                QuestionId = questionModel.QuestionId,
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
            if (id != questionModel.QuestionId)
            {
                return BadRequest();
            }
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            question.QuestionId = question.QuestionId;
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