using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PetShop.Infraestructure.Data.Migrations.Oracle
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    Code = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Image = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    Type = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ProductId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Count = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenItems_Ordenes_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenItems_Productos_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_UserId",
                table: "Ordenes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItems_OrderId",
                table: "OrdenItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItems_ProductId",
                table: "OrdenItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenItems");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
