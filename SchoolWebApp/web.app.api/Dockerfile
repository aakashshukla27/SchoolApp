#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["web.app.api/web.app.api.csproj", "web.app.api/"]
RUN dotnet restore "web.app.api/web.app.api.csproj"
COPY . .
WORKDIR "/src/web.app.api"
RUN dotnet build "web.app.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "web.app.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "web.app.api.dll"]