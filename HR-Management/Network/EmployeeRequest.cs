using HR_Management.Models;

namespace HR_Management.Network;

public class EmployeeRequest
{
    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Adders { get; set; }

    public DateTime InitDate { get; set; }

    public Employee Employee() =>
        new Employee(this.Name, this.LastName, this.Email, this.InitDate, this.Phone, this.Adders);
}