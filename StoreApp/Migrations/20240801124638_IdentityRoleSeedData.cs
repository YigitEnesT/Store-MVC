using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class IdentityRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7d9012e-a668-4993-aa53-287b3cd97a0d", "ec081bff-a8fd-492c-9c1f-778904df6105", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5599374-eb90-4788-8ccb-8b1b099868f2", "a502f42b-5877-4947-bc22-e37f9e7d94f8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f6f7b5d1-a6a1-4863-9b13-e3ea0c9e5eb5", "91b6cc18-7edc-444c-b4d8-3325bfec6d96", "Editor", "EDITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7d9012e-a668-4993-aa53-287b3cd97a0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5599374-eb90-4788-8ccb-8b1b099868f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6f7b5d1-a6a1-4863-9b13-e3ea0c9e5eb5");
        }
    }
}
