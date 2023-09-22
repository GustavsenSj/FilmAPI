FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FilmAPI/FilmAPI.csproj", "FilmAPI/"]
RUN dotnet restore "FilmAPI/FilmAPI.csproj"
COPY . .
WORKDIR "/src/FilmAPI"
RUN dotnet build "FilmAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FilmAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FilmAPI.dll"]
