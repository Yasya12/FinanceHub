FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["FinanceHub.API/FinanceHub.API.csproj", "FinanceHub.API/"]
COPY ["FinanceHub.Domain/FinanceHub.Domain.csproj", "FinanceHub.Domain/"]
COPY ["FinanceHub.Infrastructure/FinanceHub.Infrastructure.csproj", "FinanceHub.Infrastructure/"]
COPY ["FinanceHub.Application/FinanceHub.Application.csproj", "FinanceHub.Application/"]

RUN dotnet restore "FinanceHub.API/FinanceHub.API.csproj"

COPY . .

WORKDIR "/src/FinanceHub.API"
RUN dotnet build "FinanceHub.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinanceHub.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Копіюємо конфігураційні файли
COPY ["FinanceHub.API/appsettings.json", "./"]
COPY ["FinanceHub.API/appsettings.Development.json", "./"]

# Встановлюємо змінні середовища для Azure
ENV AZURE_TENANT_ID=$AZURE_TENANT_ID
ENV AZURE_CLIENT_ID=$AZURE_CLIENT_ID
ENV AZURE_CLIENT_SECRET=$AZURE_CLIENT_SECRET

ENTRYPOINT ["dotnet", "FinanceHub.API.dll"]