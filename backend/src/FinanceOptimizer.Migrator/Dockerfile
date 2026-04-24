FROM mcr.microsoft.com/dotnet/runtime:10.0 AS runtime
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY FinanceOptimizer.sln ./
COPY src/FinanceOptimizer.Api/FinanceOptimizer.Api.csproj src/FinanceOptimizer.Api/
COPY src/FinanceOptimizer.Application/FinanceOptimizer.Application.csproj src/FinanceOptimizer.Application/
COPY src/FinanceOptimizer.Domain/FinanceOptimizer.Domain.csproj src/FinanceOptimizer.Domain/
COPY src/FinanceOptimizer.Infrastructure/FinanceOptimizer.Infrastructure.csproj src/FinanceOptimizer.Infrastructure/
COPY src/FinanceOptimizer.Migrator/FinanceOptimizer.Migrator.csproj src/FinanceOptimizer.Migrator/

RUN dotnet restore src/FinanceOptimizer.Migrator/FinanceOptimizer.Migrator.csproj

COPY . .

RUN dotnet publish src/FinanceOptimizer.Migrator/FinanceOptimizer.Migrator.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

FROM runtime AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FinanceOptimizer.Migrator.dll"]