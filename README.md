# Finance Optimizer

Backend application for analyzing personal financial data and generating actionable insights to reduce unnecessary expenses.

## Tech Stack

- .NET 10
- ASP.NET Core
- PostgreSQL
- Entity Framework Core
- Docker Compose
- Swagger / OpenAPI

## Architecture

Hexagonal Architecture:

    src/
      FinanceOptimizer.Api
      FinanceOptimizer.Application
      FinanceOptimizer.Domain
      FinanceOptimizer.Infrastructure

Dependency rules:

    Domain -> no dependencies
    Application -> Domain
    Infrastructure -> Application + Domain
    Api -> Application + Infrastructure

## Current Status

- API running
- PostgreSQL running with Docker Compose
- Swagger enabled
- Health check enabled
- Initial project structure created

## Run PostgreSQL

    docker compose up -d

## Run API

    dotnet run --project src/FinanceOptimizer.Api

## URLs

    Swagger: http://localhost:5000/swagger
    Health:  http://localhost:5000/health

## Database

Connection string:

    {
      "ConnectionStrings": {
        "Postgres": "Host=localhost;Port=5432;Database=financeoptimizer;Username=finance;Password=finance_password"
      }
    }

## Docker

PostgreSQL service:

    services:
      postgres:
        image: postgres:17
        container_name: financeoptimizer-postgres
        environment:
          POSTGRES_DB: financeoptimizer
          POSTGRES_USER: finance
          POSTGRES_PASSWORD: finance_password
        ports:
          - "5432:5432"

## Next Steps

- Add transaction persistence
- Add POST /transactions
- Add EF Core mappings
- Add migrations
- Add CSV import
- Add spending insights