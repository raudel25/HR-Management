using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Management.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetAllEmployees");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetSalaryHistory");
            migrationBuilder.Sql(@"
        CREATE PROCEDURE GetAllEmployees()
        BEGIN
            SELECT e.Id as IdEmployee, r.Id as IdRoll, e.Name, e.LastName, e.Email, e.Adders, e.InitDate, r.Name as Roll, r.PeriodMoths, r.Augment
            FROM Employees as e
            INNER JOIN EmployeeRolls as evr ON e.Id = evr.IdEmployee
            INNER JOIN Rolls as r ON evr.IdRoll = r.Id;
        END;
        ");

            migrationBuilder.Sql(@"
        CREATE PROCEDURE GetSalaryHistory(IN id INT)
        BEGIN
            SELECT * FROM SalaryHistories WHERE IdEmployee = id ORDER BY Date;
        END;
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetAllEmployees");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetSalaryHistory");
        }
    }
}
