using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PetShop.Api.Helpers.AutoMapper;
using PetShop.Domain.SeedWork.Contracts;
using PetShop.Infraestructure.UnitOfWork;
using System;

namespace PetShop.Api.Helpers
{
    public static class Ioc
    {
        public static void AddPetShopRegistrationHttpContext(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
        public static void AddPetShopCors(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAnyOrigin", options =>
                options.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
        }
        public static void AddPetShopRegisterUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void AddPetShopAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
        }
        public static void AddPetShopSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PetShop.Api",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Email = "ltsa0314@gmail.com",
                        Name = "Leidy Tatiana Sanchez Arevalo ",
                        Url = new Uri("https://www.carvajal.com/index.php/tecnologia-y-servicios/")
                    },
                });
            });
        }
    }
}
