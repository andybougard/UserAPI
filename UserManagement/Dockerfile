# Use the official .NET image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

#Use on github only
WORKDIR /src/UserManagement
#

RUN dotnet restore "UserManagement.csproj"
RUN dotnet publish "UserManagement.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS publish
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

WORKDIR /app
COPY --from=build /app/publish .


ENTRYPOINT ["dotnet", "UserManagement.dll"]