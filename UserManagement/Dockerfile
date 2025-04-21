# Use the official .NET image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "src/UserManagement.csproj"
RUN dotnet publish "src/UserManagement.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS publish
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

WORKDIR /app
COPY --from=build /app/publish .


ENTRYPOINT ["dotnet", "UserManagement.dll"]