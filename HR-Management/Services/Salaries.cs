using HR_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Services;

public interface ISalaries
{
    public Task<bool> UpdateSalary(int id);

    public Task UpdateSalary();
}

public class Salaries : ISalaries
{
    private readonly HRContext _context;

    public Salaries(HRContext context)
    {
        this._context = context;
    }

    public async Task<bool> UpdateSalary(int id)
    {
        var salaries = await this._context.SalaryHistories.Where(e => e.IdEmployee == id).OrderByDescending(e => e.Date)
            .ToListAsync();

        if (salaries.Count == 0) return false;

        Console.WriteLine("aaaa");

        var salary = salaries[0];

        var rolls = await this._context.EmployeeRolls.Where(e => e.IdEmployee == id).Select(e => e.Roll).ToListAsync();

        var m = (DateTime.Now.Year - salary.Date.Year) * 12 + DateTime.Now.Month - salary.Date.Month;
        double s = 0;

        Console.WriteLine(salary.Date.Month);

        foreach (var r in rolls)
        {
            Console.WriteLine((r.PeriodMoths, r.Augment, m));
            var ind = m / r.PeriodMoths;
            if (ind == 0) continue;

            s += Math.Pow(r.Augment / 100, ind);
        }

        if (s == 0) return true;

        var newS = salary.Salary * (1 + s);

        var upSalary = new SalaryHistory(id, DateTime.Now, newS, s);

        this._context.SalaryHistories.Add(upSalary);
        await this._context.SaveChangesAsync();

        return true;
    }


    public async Task UpdateSalary()
    {
        var employees = await this._context.Employees.Select(e => e.Id).ToListAsync();

        foreach (var id in employees)
        {
            await UpdateSalary(id);
        }
    }
}