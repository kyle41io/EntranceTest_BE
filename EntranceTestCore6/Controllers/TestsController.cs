using AutoMapper;
using EntranceTestCore6.Data;
using EntranceTestCore6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("[controller]")]
public class TestsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _dbContext;

    public TestsController(IMapper mapper, AppDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TestModel>>> GetAllTests()
    {
        var tests = await _dbContext.Tests.ToListAsync();
        return _mapper.Map<List<TestModel>>(tests);
    }

    [HttpGet("{testId}")]
    public async Task<ActionResult<TestModel>> GetTest(int testId)
    {
        var test = await _dbContext.Tests.FindAsync(testId);

        if (test == null)
        {
            return NotFound();
        }

        return _mapper.Map<TestModel>(test);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTest(TestModel model)
    {
        // Map TestModel to Test entity using AutoMapper
        var test = _mapper.Map<Test>(model);

        // Add the new test to the Tests DbSet
        _dbContext.Tests.Add(test);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTest), new { testId = test.TestId }, _mapper.Map<TestModel>(test));
    }


    [HttpPut("{testId}")]
    public async Task<IActionResult> UpdateTest(int testId, TestModel testModel)
    {
        var test = await _dbContext.Tests.FindAsync(testId);

        if (test == null)
        {
            return NotFound();
        }

        _mapper.Map(testModel, test);

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!TestExists(testId))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{testId}")]
    public async Task<IActionResult> DeleteTest(int testId)
    {
        var test = await _dbContext.Tests.FindAsync(testId);

        if (test == null)
        {
            return NotFound();
        }

        _dbContext.Tests.Remove(test);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    private bool TestExists(int testId)
    {
        return _dbContext.Tests.Any(e => e.TestId == testId);
    }
}