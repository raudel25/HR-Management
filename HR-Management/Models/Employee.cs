using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Management.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string? Phone { get; set; }

    public string? Adders { get; set; }

    public DateTime InitDate { get; set; }

    public Employee(string name, string lastName, string email, DateTime initDate, string? phone = null,
        string? adders = null)
    {
        this.Name = name;
        this.LastName = lastName;
        this.Email = email;
        this.InitDate = initDate;
        this.Phone = phone;
        this.Adders = adders;
    }
}