# Multi-stage build for ASP.NET Core MVC application
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src

# Copy csproj and restore as distinct layers for better caching
COPY ["StudentManagement.csproj", "./"]
RUN dotnet restore "StudentManagement.csproj"

# Copy everything else and publish
COPY . .
RUN dotnet publish "StudentManagement.csproj" -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:latest AS runtime
WORKDIR /app
COPY --from=build /app .

# Listen on port 80 by default (Render uses the PORT env variable if provided)
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "StudentManagement.dll"]

