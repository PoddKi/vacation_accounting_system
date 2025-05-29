using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using VacationAccountingSystem.Data;
using VacationAccountingSystem.Models;

namespace VacationAccountingSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly VacationDbContext _vacationDbContext;

    public DepartmentController(VacationDbContext vacationDbContext) => _vacationDbContext = vacationDbContext;

    [HttpGet]
    public async Task<List<Department>> Get()
    {
        return await _vacationDbContext.Departments.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Department?> GetById(int id)
    {
        return await _vacationDbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
    }

    //[HttpPost]
    //public async Task<ActionResult> Create([FromBody] Department department)
    //{
    //    if (string.IsNullOrWhiteSpace(department.Name))
    //    {
    //        return BadRequest("Invalid Request");
    //    }

    //    await _vacationDbContext.Departments.AddAsync(department);
    //    await _vacationDbContext.SaveChangesAsync();

    //    return CreatedAtAction(nameof(GetById), new { id = department.Id}, department);
    //}

    //[HttpPut]
    //public async Task<ActionResult> Update([FromBody] Department department)
    //{
    //    if (department.Id == 0 ||
    //        string.IsNullOrWhiteSpace(department.Name))
    //    {
    //        return BadRequest("Invalid Request");
    //    }

    //    _vacationDbContext.Departments.Update(department);
    //    await _vacationDbContext.SaveChangesAsync();

    //    return Ok();
    //}

    //[HttpDelete("{id}")]
    //public async Task<ActionResult> Delete(int id)
    //{
    //    var department = await GetById(id);
    //    if (department is null)
    //        return NotFound();
        
    //    _vacationDbContext.Remove(department);
    //    await _vacationDbContext.SaveChangesAsync();

    //    return Ok();

    //}
}
