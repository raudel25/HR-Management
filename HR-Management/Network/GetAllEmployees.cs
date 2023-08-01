namespace HR_Management.Network;

public class GetAllEmployees
{
    public int IdEmployee { get; set; }

    public int IdRoll { get; set; }


    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string? Phone { get; set; }

    public string? Adders { get; set; }

    public DateTime InitDate { get; set; }

    public int PeriodMoths { get; set; }

    public double Augment { get; set; }
}