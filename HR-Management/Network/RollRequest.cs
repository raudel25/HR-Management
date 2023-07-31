using HR_Management.Models;

namespace HR_Management.Network;

public class RollRequest
{
    public string Name { get; set; } = null!;

    public int PeriodMoths { get; set; }

    public double Augment { get; set; }

    public Roll Roll() => new Roll(this.Name, this.PeriodMoths, this.Augment);
}