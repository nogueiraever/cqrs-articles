#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/LikeApi/LikeApi.csproj", "src/LikeApi/"]
RUN dotnet restore "src/LikeApi/LikeApi.csproj"
COPY . .
WORKDIR "/src/src/LikeApi"
RUN dotnet build "LikeApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LikeApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LikeApi.dll"]