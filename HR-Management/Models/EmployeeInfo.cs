using System.ComponentModel.DataAnnotations;

namespace HR_Management.Models;

public class EmployeeInfo
{
    [Key] public int IdEmployee { get; set; }

    [Key] public int IdRoll { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Adders { get; set; }

    public DateTime InitDate { get; set; }

    public string Roll { get; set; } = null!;

    public int PeriodMoths { get; set; }

    public double Augment { get; set; }
}