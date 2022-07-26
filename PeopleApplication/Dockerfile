FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PeopleApplication.csproj", "PeopleApplication.csproj"]
RUN dotnet restore "PeopleApplication.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "PeopleApplication.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PeopleApplication.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PeopleApplication.dll"]