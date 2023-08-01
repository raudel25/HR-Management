using HR_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_Management.Services;
using HR_Management.Network;

namespace HR_Management.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    private readonly HHRRContext _context;

    public ReportController(HHRRContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public IEnumerable<GetAllEmployees> GetAllEmployees()
    {
        return _context.Database.SqlQuery<GetAllEmployees>($"CALL GetAllEmployees()").ToList();
    }
    
    [HttpGet("{id:int}")]
    public IEnumerable<SalaryHistory> GetAllEmployees(int id)
    {
        return _context.SalaryHistories.FromSql($"CALL GetSalaryHistory({id})").ToList();
    }
}