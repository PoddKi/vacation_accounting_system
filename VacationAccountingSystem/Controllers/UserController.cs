using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationAccountingSystem.Data;
using VacationAccountingSystem.Domain.Entities;

namespace VacationAccountingSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly VacationDbContext _vacationDbContext;

    public UserController(VacationDbContext vacationDbContext) => _vacationDbContext = vacationDbContext;

    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await _vacationDbContext.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<User?> GetById(int id)
    {
        return await _vacationDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] User user)
    {
        if (string.IsNullOrWhiteSpace(user.Email) ||
            string.IsNullOrWhiteSpace(user.Password) ||
            string.IsNullOrWhiteSpace(user.Role) ||
            string.IsNullOrWhiteSpace(user.FullName) ||
            string.IsNullOrWhiteSpace(user.Function))
        {
            return BadRequest("Invalid Request");
        }

        await _vacationDbContext.Users.AddAsync(user);
        await _vacationDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = user.Id}, user);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] User user)
    {
        if (user.Id == 0 ||
            string.IsNullOrWhiteSpace(user.Email) ||
            string.IsNullOrWhiteSpace(user.Password) ||
            string.IsNullOrWhiteSpace(user.Role) ||
            string.IsNullOrWhiteSpace(user.FullName) ||
            string.IsNullOrWhiteSpace(user.Function))
        {
            return BadRequest("Invalid Request");
        }

        _vacationDbContext.Users.Update(user);
        await _vacationDbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var user = await GetById(id);
        if (user is null)
            return NotFound();
        
        _vacationDbContext.Remove(user);
        await _vacationDbContext.SaveChangesAsync();

        return Ok();

    }
}
