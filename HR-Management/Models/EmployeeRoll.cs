using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Models;

public class EmployeeRoll
{
    [Key]
    [ForeignKey("Employee")]
    public int IdEmployee { get; set; }

    public Employee Employee { get; set; } = null!;
    
    [Key]
    [ForeignKey("Roll")]
    public int IdRoll { get; set; }

    public Roll Roll { get; set; } = null!;

}