#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["applicationBanking.Api/applicationBanking.Api.csproj", "applicationBanking.Api/"]
COPY ["applicationBanking.Application/applicationBanking.Application.csproj", "applicationBanking.Application/"]
COPY ["applicationBanking.Infrastructure/applicationBanking.Infrastructure.csproj", "applicationBanking.Infrastructure/"]
COPY ["applicationBanking.Domain/applicationBanking.Domain.csproj", "applicationBanking.Domain/"]
COPY ["applicationBanking.Infrastructure.IoC/applicationBanking.Infrastructure.IoC.csproj", "applicationBanking.Infrastructure.IoC/"]
RUN dotnet restore "applicationBanking.Api/applicationBanking.Api.csproj"
COPY . .
WORKDIR "/src/applicationBanking.Api"
RUN dotnet build "applicationBanking.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "applicationBanking.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "applicationBanking.Api.dll"]