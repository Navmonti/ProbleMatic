# ProbleMatic

ProbleMatic is a .NET support-ticket management API designed around a service-oriented, layered architecture. The project models a business workflow for handling customer requests, assigning tickets to departments and employees, and managing users, roles, and account-related records.

## Overview

The solution currently exposes a REST API for managing:

- Customers
- Departments
- Employees
- Roles
- Users
- User-role assignments
- Tickets and ticket assignment

The system is built to support a helpdesk or internal support workflow where tickets can be created, updated, assigned, and tracked across departments.

## Architecture

This repository follows a layered clean-architecture style with separate projects for domain, application, infrastructure, and API:

- `src/ProbleMatic.Domain` — domain entities, enums, exceptions, and core business concepts
- `src/ProbleMatic.Application` — application services, interfaces, repositories, and business logic orchestration
- `src/ProbleMatic.Infrastructure` — EF Core persistence, repositories, and dependency registration
- `src/ProbleMatic.Api` — ASP.NET Core Web API project exposing endpoints through controllers

The API uses:

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Dependency injection

## Current Features

### Ticket workflow

The project includes ticket-related functionality such as:

- Create ticket
- Get all tickets
- Get tickets by department
- Get ticket by ID
- Update ticket
- Assign employee to a ticket
- Delete ticket

This aligns with the planned workflow described in the project: a ticket is created, associated with a department, and then assigned to an employee for resolution.

### Business entities

The data model includes:

- `Customer`
- `Department`
- `Employee`
- `Role`
- `User`
- `UserRole`
- `Ticket`

The application also contains account-related DTOs and controller endpoints for login and registration flows, even though the current codebase is primarily focused on the ticketing domain.

## Solution Structure

```text
ProbleMatic/
├── src/
│   ├── ProbleMatic.Api/
│   │   ├── Controllers/
│   │   ├── DTOs/
│   │   ├── Middleware/
│   │   ├── Extensions/
│   │   ├── Program.cs
│   │   └── appsettings*.json
│   ├── ProbleMatic.Application/
│   │   ├── Features/
│   │   ├── Interfaces/
│   │   ├── IRepositories/
│   │   ├── Services/
│   │   └── Behaviors/
│   ├── ProbleMatic.Domain/
│   │   ├── Entities/
│   │   ├── Enums/
│   │   ├── Events/
│   │   └── ValueObjects/
│   └── ProbleMatic.Infrastructure/
│       ├── Persistence/
│       ├── Repositories/
│       ├── Configurations/
│       ├── Identity/
│       └── Migrations/
├── tests/
│   ├── ProbleMatic.Application.Tests/
│   ├── ProbleMatic.Domain.Tests/
│   └── ProbleMatic.IntegrationTests/
├── ProbleMatic.sln
├── README.md
└── .gitignore
```

## Tech Stack

- C# / .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger UI
- xUnit test projects

## Prerequisites

Before running the project, ensure you have:

- .NET 10 SDK installed
- SQL Server instance available
- Access to a local or remote database that matches the connection string configuration

## Configuration

The API is configured in `src/ProbleMatic.Api/appsettings.json` using a SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ProbleMaticDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
```

If you are using a different database server or database name, update the connection string before running the application.

## Getting Started

### 1. Restore dependencies

```bash
dotnet restore
```

### 2. Build the solution

```bash
dotnet build ProbleMatic.sln --nologo
```

### 3. Run the API

```bash
dotnet run --project src/ProbleMatic.Api
```

### 4. Open Swagger

Once the API is running, browse to:

```text
https://localhost:<port>/swagger
```

The project also runs database migrations automatically during startup, which is configured in `Program.cs`.

## Development Roadmap

The current project describes a staged approach to ticket assignment:

1. Manual assignment
   - A user can review open tickets and assign them to the correct department and employee.
2. AI-powered assignment
   - A future phase would use intelligent logic to route tickets automatically to the most appropriate team member or department.

This repository is therefore a strong starting point for a support ticket system that can evolve into a smarter, automated operations platform.

## Notes

This repository already includes a working .NET solution and test projects, and the current build is set up to run as a modern ASP.NET Core API with EF Core data access and Swagger support.

## License

This project does not currently declare a license in the repository metadata. If you plan to publish or distribute it publicly, add an appropriate open-source license file and update this section.
