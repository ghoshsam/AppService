#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/App/AppService.Api.csproj", "src/App/"]
COPY ["src/Core/AppService.Core/AppService.Core.csproj", "src/Core/AppService.Core/"]
COPY ["src/Infrastructure/AppService.Infrastructure/AppService.Infrastructure.csproj", "src/Infrastructure/AppService.Infrastructure/"]
RUN dotnet restore "src/App/AppService.Api.csproj"
COPY . .
WORKDIR "/src/src/App"
RUN dotnet build "AppService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppService.Api.dll"]