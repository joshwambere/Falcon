FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Searching.Api/Searching.Api.csproj", "Searching.Api/"]
RUN dotnet restore "Searching.Api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Searching.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Searching.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Searching.Api.dll"]
