using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShop.Infraestructure.Data.Migrations.SqlServer
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Productos",
                columns: new[] { "Id", "Code", "Description", "Image", "Name", "Price" },
                values: new object[] { 1L, "Lata", "Alimento prescrito de presentación húmeda que ayuda a la regulación de la microbiota intestinal, mejorando la salud digestiva ante enfermedades fibro-responsivas.\r\n                                Su tecnología ActivBome+ favorece la salud y bienestar del tracto digestivo al nutrir el microbioma intestinal.\r\n                                Contiene altos niveles de ácidos grasos omega 3 (EPA y DHA) que ayudan a reducir los procesos inflamatorios derivados de la enfermedad intestinal.\r\n                                Ha demostrado clínicamente que ayuda a reducir las heces líquidas en 24 horas.", "https://www.gabrica.co/wp-content/uploads/2020/05/11001097-hills-prescription-diet-lata-GastroBiome.png", "Hill’s Prescription Diet Lata GastroBiome", 12000m });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Productos",
                columns: new[] { "Id", "Code", "Description", "Image", "Name", "Price" },
                values: new object[] { 2L, "Synergy", "Indicado para ayudar la salud e higiene bucal en los perros dejando máxima blancura en los dientes.\r\n                                – Sin alcohol, sin azúcar, sin detergentes y sin sabores picantes de menta.\r\n                                – La fórmula se activa al contacto con la placa bacteriana y los gérmenes en la cavidad oral, eliminando bacterias y el mal olor causado por ellas.\r\n                                – Protege las encías y ayuda a prevenir y tratar la gingivitis.", "https://www.gabrica.co/wp-content/uploads/2019/04/DENTAL-FRESH-Advanced-Whitening-Perros.png", "Dental Fresh Advanced Whitening Perros", 25000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
