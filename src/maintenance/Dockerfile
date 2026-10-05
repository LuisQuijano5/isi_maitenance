# STAGE 1: Build & Publish
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Maintenance.csproj", "./"]
RUN dotnet restore "./Maintenance.csproj"

COPY . .
RUN dotnet publish "./Maintenance.csproj" -c Release -o /app/publish /p:UseAppHost=false

# STAGE 2: Final Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
USER app
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Maintenance.dll"]