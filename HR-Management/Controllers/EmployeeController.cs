using HR_Management.Models;
using HR_Management.Network;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_Management.Services;

namespace HR_Management.Controllers;

[ApiController]
[Route("employee")]
public class EmployeeController : ControllerBase
{
    private readonly HHRRContext _context;

    public EmployeeController(HHRRContext context)
    {
        this._context = context;
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

        var e = this._context.Employees.SingleOrDefault(e => e.Id == id);
        if (e is null) return NotFound();

        _context.Entry(e).State = EntityState.Detached;

        this._context.Employees.Update(employee);
        this._context.SaveChanges();

        return employee;
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Employee> Delete(int id)
    {
        var employee = this._context.Employees.SingleOrDefault(e => e.Id == id);

        if (employee is null) return NotFound();

        this._context.Employees.Remove(employee);
        this._context.SaveChanges();

        return employee;
    }
}