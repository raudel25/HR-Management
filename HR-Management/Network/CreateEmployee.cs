using System.Runtime.CompilerServices;
using HR_Management.Models;

namespace HR_Management.Network;

public class CreateEmployee : EmployeeRequest
{
    public int Salary { get; set; }

    public SalaryHistory SalaryHistory(int id) => new SalaryHistory(id, this.InitDate, this.Salary, 0);
}