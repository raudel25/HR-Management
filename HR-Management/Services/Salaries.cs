using HR_Management.Models;

namespace HR_Management.Services;

public class Salaries
{
    private readonly HHRRContext _context;
    
    public Salaries(HHRRContext context)
    {
        this._context = context;
    }
    public bool UpdateSalary(int id)
    {
        var salary = this._context.SalaryHistories.Where(e => e.IdEmployee == id).OrderByDescending(e => e.Date)
            .SingleOrDefault();

        if (salary is null) return true;

        var rolls = this._context.EmployeeRolls.Where(e => e.IdEmployee == id).Select(e => e.Roll).ToList();

        var m = (DateTime.Now.Year - salary.Date.Year) * 12 + DateTime.Now.Month - salary.Date.Month;
        double s = 0;

        foreach (var r in rolls)
        {
            var ind = m / r.PeriodMoths;
            if (ind == 0) continue;

            s += Math.Pow(r.Augment / 100, ind);
        }

        if (s == 0) return true;

        var newS = salary.Salary * (1 + s);

        var upSalary = new SalaryHistory(id, DateTime.Now, newS, s);

        this._context.SalaryHistories.Add(upSalary);
        this._context.SaveChanges();

        return true;
    }

   
    public void UpdateSalary()
    {
        var employees = this._context.Employees.Select(e => e.Id).ToList();

        var _ = employees.Select(UpdateSalary);
    }   
}