using Microsoft.EntityFrameworkCore;
using HR_Management.Models;


namespace HR_Management.Services;

public class HRContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;

    public DbSet<Roll> Rolls { get; set; } = null!;

    public DbSet<SalaryHistory> SalaryHistories { get; set; } = null!;

    public DbSet<EmployeeRoll> EmployeeRolls { get; set; } = null!;

    public HRContext(DbContextOptions<HRContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeRoll>().HasKey(x => new { x.IdEmployee, x.IdRoll });
    }
}