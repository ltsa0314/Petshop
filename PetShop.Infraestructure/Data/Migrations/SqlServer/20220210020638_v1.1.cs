using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShop.Infraestructure.Data.Migrations.SqlServer
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Usuarios",
                columns: new[] { "Id", "FullName", "Password", "Type", "UserName" },
                values: new object[] { 1L, "Leidy Tatina", "123456", 0, "leidy" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Usuarios",
                columns: new[] { "Id", "FullName", "Password", "Type", "UserName" },
                values: new object[] { 2L, "Pepito Perez", "123456", 1, "pepito" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "dbo",
                table: "Usuarios");
        }
    }
}
