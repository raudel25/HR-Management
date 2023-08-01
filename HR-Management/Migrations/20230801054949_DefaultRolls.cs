using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Management.Migrations
{
    /// <inheritdoc />
    public partial class DefaultRolls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Rolls (Name, PeriodMoths , Augment) VALUES ('Worker', 5, 3)");
            migrationBuilder.Sql("INSERT INTO Rolls (Name, PeriodMoths , Augment) VALUES ('Specialists', 8, 3)");
            migrationBuilder.Sql("INSERT INTO Rolls (Name, PeriodMoths , Augment) VALUES ('Managers', 12, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Rolls WHERE Name = 'Worker'");
            migrationBuilder.Sql("DELETE FROM Rolls WHERE Name = 'Specialists'");
            migrationBuilder.Sql("DELETE FROM Rolls WHERE Name = 'Managers'");
        }
    }
}
