FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/IdentityForge.Web/IdentityForge.Web.csproj", "src/IdentityForge.Web/"]
COPY ["src/IdentityForge.Infrastructure/IdentityForge.Infrastructure.csproj", "src/IdentityForge.Infrastructure/"]
COPY ["src/IdentityForge.Application/IdentityForge.Application.csproj", "src/IdentityForge.Application/"]
COPY ["src/IdentityForge.Domain/IdentityForge.Domain.csproj", "src/IdentityForge.Domain/"]

RUN dotnet restore "./src/IdentityForge.Web/IdentityForge.Web.csproj"
COPY . .

WORKDIR "/src/src/IdentityForge.Web"
RUN dotnet build "./IdentityForge.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IdentityForge.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityForge.Web.dll"]
