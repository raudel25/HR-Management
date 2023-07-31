using Microsoft.EntityFrameworkCore;
using HR_Management.Models;


namespace HR_Management.Services;

public class HHRRContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;

    public DbSet<Roll> Rolls { get; set; } = null!;

    public DbSet<SalaryHistory> SalaryHistories { get; set; } = null!;

    public HHRRContext(DbContextOptions<HHRRContext> options)
        : base(options)
    {
    }
}