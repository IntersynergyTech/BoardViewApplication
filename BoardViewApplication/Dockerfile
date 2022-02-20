FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BoardViewApplication.csproj", "BoardViewApplication/"]
RUN dotnet restore "BoardViewApplication/BoardViewApplication.csproj"

WORKDIR "/src/BoardViewApplication"
COPY . .

RUN dotnet build "BoardViewApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BoardViewApplication.csproj" -c Release -o /app/publish

FROM base AS final
LABEL vendor1="Intersynergy Technologies Ltd"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BoardViewApplication.dll"]
