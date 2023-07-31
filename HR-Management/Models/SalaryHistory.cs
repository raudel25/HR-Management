using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Models;

public class SalaryHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("Employee")] public int IdEmployee { get; set; }

    public Employee Employee { get; set; } = null!;

    public DateTime Date { get; set; }

    public double Salary { get; set; }

    public double Augment { get; set; }

    public SalaryHistory(int idEmployee, DateTime date, double salary, double augment)
    {
        this.IdEmployee = idEmployee;
        this.Date = date;
        this.Salary = salary;
        this.Augment = augment;
    }
}