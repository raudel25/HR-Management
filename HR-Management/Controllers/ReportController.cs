using HR_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_Management.Services;

namespace HR_Management.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    private readonly HRContext _context;

    public ReportController(HRContext context)
    {
        this._context = context;
    }
    
    [HttpGet]
    public async Task<IEnumerable<EmployeeInfo>> GetAllEmployees()
    {
        return await _context.EmployeeInfos.FromSql($"CALL GetAllEmployees()").ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<IEnumerable<SalaryHistory>> GetAllEmployees(int id)
    {
        return await _context.SalaryHistories.FromSql($"CALL GetSalaryHistory({id})").ToListAsync();
    }
}