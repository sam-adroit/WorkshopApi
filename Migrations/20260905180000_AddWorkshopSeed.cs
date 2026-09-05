using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using WorkshopApi.Data;

namespace WorkshopApi.Migrations;

[DbContext(typeof(AppDbContext))]
[Migration("20260905180000_AddWorkshopSeed")]
public class AddWorkshopSeed : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateIndex(
            name: "IX_Registrations_WorkshopId_StudentId",
            table: "Registrations",
            columns: new[] { "WorkshopId", "StudentId" },
            unique: true);

        migrationBuilder.InsertData(
            table: "Workshops",
            columns: new[] { "Id", "Capacity", "Date", "Description", "RegistrationDeadline", "Title", "Venue" },
            values: new object[,]
            {
                { 1, 20, new DateTime(2026, 10, 15, 14, 0, 0, DateTimeKind.Utc), "Learn the basics of C# programming.", new DateTime(2026, 10, 14, 23, 59, 0, DateTimeKind.Utc), "Introduction to C#", "Room 101" },
                { 2, 15, new DateTime(2026, 11, 5, 15, 0, 0, DateTimeKind.Utc), "Build practical PostgreSQL skills.", new DateTime(2026, 11, 4, 23, 59, 0, DateTimeKind.Utc), "PostgreSQL Essentials", "Lab 2" }
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(table: "Workshops", keyColumn: "Id", keyValue: 1);
        migrationBuilder.DeleteData(table: "Workshops", keyColumn: "Id", keyValue: 2);
        migrationBuilder.DropIndex(name: "IX_Registrations_WorkshopId_StudentId", table: "Registrations");
    }
}
