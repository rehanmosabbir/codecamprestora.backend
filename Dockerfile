FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy AS build
WORKDIR /

COPY ["src/CodeCampRestora.Api/CodeCampRestora.Api.csproj", "src/CodeCampRestora.Api/"]
COPY ["src/CodeCampRestora.Domain/CodeCampRestora.Domain.csproj", "src/CodeCampRestora.Domain/"]
COPY ["src/CodeCampRestora.Infrastructure/CodeCampRestora.Infrastructure.csproj", "src/CodeCampRestora.Infrastructure/"]
COPY ["src/CodeCampRestora.Application/CodeCampRestora.Application.csproj", "src/CodeCampRestora.Application/"]


RUN dotnet restore "src/CodeCampRestora.Api/CodeCampRestora.Api.csproj" --disable-parallel

# Copy everything else and build
COPY . .
WORKDIR "/src/CodeCampRestora.Api/"
RUN dotnet publish "CodeCampRestora.Api.csproj" -c Release -o /app/publish

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

COPY --from=build /app/publish .

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

ENV ASPNETCORE_ENVIRONMENT Staging
ENV ASPNETCORE_URLS=http://+:5219
EXPOSE 5219

ENTRYPOINT ["dotnet", "CodeCampRestora.Api.dll"]