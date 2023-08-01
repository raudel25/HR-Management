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
    private readonly HRContext _context;

    public ReportController(HRContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public IEnumerable<GetAllEmployees> GetAllEmployees()
    {
        // try
        // {
            return _context.Database.SqlQuery<GetAllEmployees>($"CALL GetAllEmployees()").ToList();
        // }
        // catch (Exception)
        // {
        //     return new List<GetAllEmployees>();
        // }
    }

    [HttpGet("{id:int}")]
    public async Task<IEnumerable<SalaryHistory>> GetAllEmployees(int id)
    {
        return await _context.SalaryHistories.FromSql($"CALL GetSalaryHistory({id})").ToListAsync();
    }
}