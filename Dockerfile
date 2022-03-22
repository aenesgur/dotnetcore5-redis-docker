#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Docker-Redis-Sample.API/Docker-Redis-Sample.API.csproj", "Docker-Redis-Sample.API/"]
COPY ["Docker-Redis-Sample.Cache/Docker-Redis-Sample.Cache.csproj", "Docker-Redis-Sample.Cache/"]
COPY ["Docker-Redis-Sample.Core/Docker-Redis-Sample.Core.csproj", "Docker-Redis-Sample.Core/"]
COPY ["Docker-Redis-Sample.Service/Docker-Redis-Sample.Service.csproj", "Docker-Redis-Sample.Service/"]

RUN dotnet restore "Docker-Redis-Sample.API/Docker-Redis-Sample.API.csproj"
COPY . .
WORKDIR "/src/Docker-Redis-Sample.API"
RUN dotnet build "Docker-Redis-Sample.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker-Redis-Sample.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker-Redis-Sample.API.dll"]