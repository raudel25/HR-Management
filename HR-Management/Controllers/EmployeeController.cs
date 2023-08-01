using HR_Management.Models;
using HR_Management.Network;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_Management.Services;

namespace HR_Management.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly HRContext _context;
    private readonly Salaries _salaries;

    public EmployeeController(HRContext context, Salaries salaries)
    {
        this._context = context;
        this._salaries = salaries;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> Get()
    {
        return await this._context.Employees.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Employee>> Get(int id)
    {
        var employee = await this._context.Employees.SingleOrDefaultAsync(e => e.Id == id);
        if (employee is null) return NotFound(new { msg = "Employee not found" });

        return employee;
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> Post(CreateEmployee request)
    {
        var e = await _context.Employees.SingleOrDefaultAsync(e =>
            e.Name == request.Name && e.LastName == request.LastName);
        if (e is not null) return BadRequest(new { msg = "The employee already exists" });

        var employee = request.Employee();

        this._context.Employees.Add(employee);
        await this._context.SaveChangesAsync();

        this._context.SalaryHistories.Add(request.SalaryHistory(employee.Id));
        await this._context.SaveChangesAsync();

        return employee;
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Employee>> Put(int id, EmployeeRequest request)
    {
        var employee = request.Employee();
        employee.Id = id;

        var e1 = await this._context.Employees.SingleOrDefaultAsync(e => e.Id == id);
        if (e1 is null) return NotFound(new { msg = "Employee not found" });

        var e2 = await _context.Employees.SingleOrDefaultAsync(e =>
            e.Name == request.Name && e.LastName == request.LastName && e.Id != id);
        if (e2 is not null) return BadRequest(new { msg = "The employee already exists" });

        _context.Entry(e1).State = EntityState.Detached;

        this._context.Employees.Update(employee);
        await this._context.SaveChangesAsync();

        return employee;
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = await this._context.Employees.SingleOrDefaultAsync(e => e.Id == id);

        if (employee is null) return NotFound(new { msg = "Employee not found" });

        this._context.Employees.Remove(employee);
        await this._context.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("{idEmployee:int}/roll/{idRoll:int}")]
    public async Task<IActionResult> AddRoll(int idEmployee, int idRoll)
    {
        var e = await this._context.Employees.SingleOrDefaultAsync(e => e.Id == idEmployee);
        var r = await this._context.Rolls.SingleOrDefaultAsync(r => r.Id == idRoll);

        if (e is null || r is null) return NotFound(new { msg = "Employee or roll not found" });

        this._context.EmployeeRolls.Add(new EmployeeRoll(idEmployee, idRoll));
        await this._context.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("salary/{id:int}")]
    public async Task<IActionResult> UpdateSalary(int id)
    {
        var ok = await this._salaries.UpdateSalary(id);

        return ok ? Ok() : NotFound(new { msg = "Employee not found" });
    }

    [HttpPost("salary")]
    public async Task<IActionResult> UpdateSalary()
    {
        await this._salaries.UpdateSalary();
        return Ok();
    }
}