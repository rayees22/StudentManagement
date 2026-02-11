# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["StudentApi/StudentApi.csproj", "StudentApi/"]
RUN dotnet restore "StudentApi/StudentApi.csproj"
COPY . .
WORKDIR "/src/StudentApi"
RUN dotnet publish "StudentApi.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "StudentApi.dll"]
