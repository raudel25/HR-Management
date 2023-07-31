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
    private readonly HHRRContext _context;
    private readonly Salaries _salaries;

    public EmployeeController(HHRRContext context, Salaries salaries)
    {
        this._context = context;
        this._salaries = salaries;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> Get()
    {
        return this._context.Employees.ToList();
    }

    [HttpGet("{id:int}")]
    public ActionResult<Employee> Get(int id)
    {
        var employee = this._context.Employees.SingleOrDefault(e => e.Id == id);
        if (employee is null) return NotFound();

        return employee;
    }

    [HttpPost]
    public ActionResult<Employee> Post(CreateEmployee request)
    {
        var e = _context.Employees.SingleOrDefault(e => e.Name == request.Name && e.LastName == request.LastName);
        if (e is not null) return BadRequest();

        var employee = request.Employee();

        this._context.Employees.Add(employee);
        this._context.SaveChanges();

        this._context.SalaryHistories.Add(request.SalaryHistory(employee.Id));
        this._context.SaveChanges();

        return employee;
    }

    [HttpPut("{id:int}")]
    public ActionResult<Employee> Put(int id, EmployeeRequest request)
    {
        var employee = request.Employee();
        employee.Id = id;

        var e1 = this._context.Employees.SingleOrDefault(e => e.Id == id);
        if (e1 is null) return NotFound();

        var e2 = _context.Employees.SingleOrDefault(e =>
            e.Name == request.Name && e.LastName == request.LastName && e.Id != id);
        if (e2 is not null) return BadRequest();

        _context.Entry(e1).State = EntityState.Detached;

        this._context.Employees.Update(employee);
        this._context.SaveChanges();

        return employee;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var employee = this._context.Employees.SingleOrDefault(e => e.Id == id);

        if (employee is null) return NotFound();

        this._context.Employees.Remove(employee);
        this._context.SaveChanges();

        return Ok();
    }

    [HttpPost("{idE:int}/roll/{idR:int}")]
    public IActionResult AddRoll(int idE, int idR)
    {
        var e = this._context.Employees.SingleOrDefault(e => e.Id == idE);
        var r = this._context.Rolls.SingleOrDefault(r => r.Id == idR);

        if (e is null || r is null) return NotFound();

        this._context.EmployeeRolls.Add(new EmployeeRoll(idE, idR));
        this._context.SaveChanges();

        return Ok();
    }

    [HttpPut("salary/{id:int}")]
    public IActionResult UpdateSalary(int id)
    {
        var ok = this._salaries.UpdateSalary(id);

        return ok ? Ok() : BadRequest();
    }

    [HttpPut("salary")]
    public IActionResult UpdateSalary()
    {
        this._salaries.UpdateSalary();
        return Ok();
    }
}