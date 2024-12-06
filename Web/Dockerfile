#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TibberRobot.Web/TibberRobot.Web.csproj", "TibberRobot.Web/"]
COPY ["TibberRobot.Application/TibberRobot.Application.csproj", "TibberRobot.Application/"]
COPY ["TibberRobot.Domain/TibberRobot.Domain.csproj", "TibberRobot.Domain/"]
COPY ["TibberRobot.Infrastructure/TibberRobot.Infrastructure.csproj", "TibberRobot.Infrastructure/"]


RUN dotnet restore "./TibberRobot.Web/./TibberRobot.Web.csproj"
COPY . .
WORKDIR "/src/TibberRobot.Web"
RUN dotnet build "./TibberRobot.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TibberRobot.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TibberRobot.Web.dll"]