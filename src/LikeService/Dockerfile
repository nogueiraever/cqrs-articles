#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/LikeService/LikeService.csproj", "src/LikeService/"]
RUN dotnet restore "src/LikeService/LikeService.csproj"
COPY . .
WORKDIR "/src/src/LikeService"
RUN dotnet build "LikeService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LikeService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LikeService.dll"]