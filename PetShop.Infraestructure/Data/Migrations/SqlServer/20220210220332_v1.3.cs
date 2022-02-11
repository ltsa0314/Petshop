using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShop.Infraestructure.Data.Migrations.SqlServer
{
    public partial class v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Productos",
                columns: new[] { "Id", "Code", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 3L, "Calming", "Suplemento alimenticio para perros adultos, ayuda a reducir el estrés asociado a problemas de comportamiento como hiperactividad, agresión, control de esfínteres, rascado excesivo o destrucción.\r\n                                – Recomendado para mascotas expuestas a ambientes de estrés alto.\r\n                                – No afecta la personalidad del animal o su nivel de energía.\r\n                                – Puede ser utilizado diariamente.\r\n                                – Con Complejo Tranquilizante del Calostro, L-Teanina, Vitamina B, Lecitina y Calming derivado de plantas.", "https://www.gabrica.co/wp-content/uploads/2019/04/Calming-Pet-Naturals.png", "Calming Pet Naturals", 34000m },
                    { 4L, "Furminator", "Recoge rápidamente el pelo de las mascotas para una fácil limpieza Reutilizable: tan eficaz y dura más que un rodillo adhesivo.", "https://www.gabrica.co/wp-content/uploads/2020/05/furminator-desechar-perro-gato.png", "Furminator Herramienta De Recolección De Pelos", 68000m },
                    { 5L, "Microchip", "Es un dispostivo electronico que se implanta debajo de la piel de la mascota, es un metodo de idenfiticacion de la mascota, en caso de perdida, o robo.\r\n                                Contiene datos de la mascota y del propietario.\r\n                                Viene con un aplicador estéril que debe ser implantado por un medico veterinario.\r\n                                El empaque es de color amarillo, viene con el aplicador, carnet del propietario y una medalla que contiene el codigo QR para poder realizar la lectura por medio de una pagina especificada en la caja de entrega..", "https://www.gabrica.co/wp-content/uploads/2020/07/microchip-3.png", "Microchip", 179000m },
                    { 6L, "Beeps ", "– Facilita el baño haciéndolo rápido y simple.\r\n                                – Contiene avena que hidrata el pelaje.\r\n                                – Indicado para gatos a partir de 4 semanas.\r\n                                Fragancia de uva.", "https://www.gabrica.co/wp-content/uploads/2019/04/Beeps-Champu-Hidratante-Cat-Care.png", "Beeps Champú Para Gatos", 22000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
