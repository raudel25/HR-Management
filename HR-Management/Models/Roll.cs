using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Models;

public class Roll
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public int PeriodMoths { get; set; }

    public int Augment { get; set; }

    public Roll(string name, int periodMoths, int augment)
    {
        this.Name = name;
        this.PeriodMoths = periodMoths;
        this.Augment = augment;
    }
}