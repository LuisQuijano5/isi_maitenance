# STAGE 1: Build & Publish
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["src/gateway/Gateway.csproj", "src/gateway/"]
RUN dotnet restore "src/gateway/Gateway.csproj"

COPY src/gateway/ src/gateway/
RUN dotnet publish "src/gateway/Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

# STAGE 2: Final Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
USER app
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Gateway.dll"]