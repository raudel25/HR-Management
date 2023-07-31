using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Models;

public class SalaryHistory
{
    [Key]
    [ForeignKey("Employee")]
    public int IdEmployee { get; set; }

    public Employee Employee { get; set; } = null!;
    
    [Key]
    public DateTime Date { get; set; }
    
    public int Salary { get; set; }
    
    public int Augment { get; set; }
}