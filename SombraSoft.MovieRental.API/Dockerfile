#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SombraSoft.MovieRental.API/SombraSoft.MovieRental.API.csproj", "SombraSoft.MovieRental.API/"]
COPY ["SombraSoft.MovieRental.MongoDB/SombraSoft.MovieRental.MongoDB.csproj", "SombraSoft.MovieRental.MongoDB/"]
RUN dotnet restore "SombraSoft.MovieRental.API/SombraSoft.MovieRental.API.csproj"
COPY . .
WORKDIR "/src/SombraSoft.MovieRental.API"
RUN dotnet build "SombraSoft.MovieRental.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SombraSoft.MovieRental.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SombraSoft.MovieRental.API.dll"]
