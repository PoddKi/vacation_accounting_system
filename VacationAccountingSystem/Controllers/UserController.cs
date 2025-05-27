using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationAccountingSystem.Data;
using VacationAccountingSystem.Domains.Entities;

namespace VacationAccountingSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly VacationDbContext _vacationDbContext;

    public UserController(VacationDbContext vacationDbContext) => _vacationDbContext = vacationDbContext;

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        return _vacationDbContext.Users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User?>> GetById(int id)
    {
        return await _vacationDbContext.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
    }

    [HttpPost]
    public async Task<ActionResult> Create(User user)
    {
        await _vacationDbContext.Users.AddAsync(user);
        await _vacationDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = user.Id}, user);
    }

    [HttpPut]
    public async Task<ActionResult> Update(User user)
    {
        _vacationDbContext.Users.Update(user);
        await _vacationDbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Detele(int id)
    {
        var userGetByIdResult = await GetById(id);
        if (userGetByIdResult is null)
            return NotFound();
        
        _vacationDbContext.Remove(userGetByIdResult.Value);
        await _vacationDbContext.SaveChangesAsync();
        return Ok();

    }
}
