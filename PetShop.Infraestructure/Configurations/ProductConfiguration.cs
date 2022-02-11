using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Domain.Aggregates.ProductAggregate;
using System.Collections.Generic;

namespace PetShop.Infraestructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Image).IsRequired();


            builder.HasData(new List<Product>
            {
                new Product {
                    Id = 1,
                    Code = "Lata",
                    Name ="Hill’s Prescription Diet Lata GastroBiome",
                    Description=@"Alimento prescrito de presentación húmeda que ayuda a la regulación de la microbiota intestinal, mejorando la salud digestiva ante enfermedades fibro-responsivas.
                                Su tecnología ActivBome+ favorece la salud y bienestar del tracto digestivo al nutrir el microbioma intestinal.
                                Contiene altos niveles de ácidos grasos omega 3 (EPA y DHA) que ayudan a reducir los procesos inflamatorios derivados de la enfermedad intestinal.
                                Ha demostrado clínicamente que ayuda a reducir las heces líquidas en 24 horas.",
                    Image = "https://www.gabrica.co/wp-content/uploads/2020/05/11001097-hills-prescription-diet-lata-GastroBiome.png",
                    Price = 12000
                },
                new Product {
                    Id = 2,
                    Code = "Synergy",
                    Name ="Dental Fresh Advanced Whitening Perros",
                    Description=@"Indicado para ayudar la salud e higiene bucal en los perros dejando máxima blancura en los dientes.
                                – Sin alcohol, sin azúcar, sin detergentes y sin sabores picantes de menta.
                                – La fórmula se activa al contacto con la placa bacteriana y los gérmenes en la cavidad oral, eliminando bacterias y el mal olor causado por ellas.
                                – Protege las encías y ayuda a prevenir y tratar la gingivitis.",
                    Image = "https://www.gabrica.co/wp-content/uploads/2019/04/DENTAL-FRESH-Advanced-Whitening-Perros.png",
                    Price = 25000
                },
                new Product {
                    Id = 3,
                    Code = "Calming",
                    Name ="Calming Pet Naturals",
                    Description=@"Suplemento alimenticio para perros adultos, ayuda a reducir el estrés asociado a problemas de comportamiento como hiperactividad, agresión, control de esfínteres, rascado excesivo o destrucción.
                                – Recomendado para mascotas expuestas a ambientes de estrés alto.
                                – No afecta la personalidad del animal o su nivel de energía.
                                – Puede ser utilizado diariamente.
                                – Con Complejo Tranquilizante del Calostro, L-Teanina, Vitamina B, Lecitina y Calming derivado de plantas.",
                    Image = "https://www.gabrica.co/wp-content/uploads/2019/04/Calming-Pet-Naturals.png",
                    Price = 34000
                },
                new Product {
                    Id = 4,
                    Code = "Furminator",
                    Name ="Furminator Herramienta De Recolección De Pelos",
                    Description=@"Recoge rápidamente el pelo de las mascotas para una fácil limpieza Reutilizable: tan eficaz y dura más que un rodillo adhesivo.",
                    Image = "https://www.gabrica.co/wp-content/uploads/2020/05/furminator-desechar-perro-gato.png",
                    Price = 68000
                },
                new Product {
                    Id = 5,
                    Code = "Microchip",
                    Name ="Microchip",
                    Description=@"Es un dispostivo electronico que se implanta debajo de la piel de la mascota, es un metodo de idenfiticacion de la mascota, en caso de perdida, o robo.
                                Contiene datos de la mascota y del propietario.
                                Viene con un aplicador estéril que debe ser implantado por un medico veterinario.
                                El empaque es de color amarillo, viene con el aplicador, carnet del propietario y una medalla que contiene el codigo QR para poder realizar la lectura por medio de una pagina especificada en la caja de entrega..",
                    Image = "https://www.gabrica.co/wp-content/uploads/2020/07/microchip-3.png",
                    Price = 179000
                },
                new Product {
                    Id = 6,
                    Code = "Beeps ",
                    Name ="Beeps Champú Para Gatos",
                    Description=@"– Facilita el baño haciéndolo rápido y simple.
                                – Contiene avena que hidrata el pelaje.
                                – Indicado para gatos a partir de 4 semanas.
                                Fragancia de uva.",
                    Image = "https://www.gabrica.co/wp-content/uploads/2019/04/Beeps-Champu-Hidratante-Cat-Care.png",
                    Price = 22000
                }
            });


        }
    }
}
