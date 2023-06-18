/*using EntranceTestCore6.Data;
using EntranceTestCore6.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationUserRepository _userRepository;

    public UserController(ApplicationUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userRepository.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var user = _userRepository.GetById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Add(ApplicationUser user)
    {
        _userRepository.Add(user);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, ApplicationUser user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }
        _userRepository.Update(user);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _userRepository.Delete(id);
        return Ok();
    }
}*/