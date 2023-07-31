using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Models;

public class EmployeeRoll
{
    [Key] [ForeignKey("Employee")] public int IdEmployee { get; }

    public Employee Employee { get; set; } = null!;

    [Key] [ForeignKey("Roll")] public int IdRoll { get; }

    public Roll Roll { get; set; } = null!;

    public EmployeeRoll(int idEmployee, int idRoll)
    {
        this.IdEmployee = idEmployee;
        this.IdRoll = idRoll;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not EmployeeRoll roll) return false;

        return roll.IdEmployee == this.IdEmployee && roll.IdRoll == this.IdRoll;
    }

    public override int GetHashCode()
    {
        return this.IdEmployee * this.IdRoll;
    }
}