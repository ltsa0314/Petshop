# Prueba Tecnica Carvajal (Leidy Tatiana Sanchez Arevalo)

## Requisitos 
 * Net core 5.0
 * Node v16.14.0
 * Npm 8.4.1
 * Angular 13.2.3
 * EF Core 5.0.10


## Pasos para Ejecutar el proyecto

Validar la cadena de conexion en el archivo appsettings.json
~~~
  "Provider": "SQLServer",
  "ConnectionStrings": {
    "SQLServer": "Server=localhost;Database=PetShopDB;User Id=sa;Password=Carvaj@l2022;",
    "Oracle": "Server=localhost;port=3306;database=PetShopDB;user=root;password=root"
  }
~~~

### 1. Aplicar Migracion 

Crear  migraciones
~~~
dotnet ef migrations add v1.2 -c PetShopSqlServerContext -o Data/Migrations/SqlServer
~~~
Aplicar migraciones
~~~
cd PetShop.Infraestructure\
dotnet ef database update -c PetShopSqlServerContext
~~~

### 2. Ejecutar Proyecto BackEnd
~~~
cd PetShop.Api\
dotnet run .\PetShop.Api.csproj
~~~

### 2. Ejecutar Proyecto FrontEnd
~~~
cd .\PetShop\ 
npm install
ng serve -o
~~~