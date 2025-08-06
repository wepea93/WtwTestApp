FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de proyecto (.csproj) usando rutas relativas al contexto actual
COPY Api/Requests.Api.csproj Api/
COPY Core/Requests.Core.csproj Core/
COPY Infrastructure/Requests.Infrastructure.csproj Infrastructure/

# Restaurar dependencias
RUN dotnet restore "Api/Requests.Api.csproj"

# Copiar el resto del código fuente
COPY . .

# Compilar el proyecto
RUN dotnet build "Api/Requests.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api/Requests.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Ejecutar migraciones EF Core y luego levantar la API
ENTRYPOINT ["/bin/sh", "-c", "dotnet ef database update --no-build --project /src/Infrastructure/Requests.Infrastructure.csproj --startup-project /app/Requests.Api.dll; dotnet Requests.Api.dll"]
