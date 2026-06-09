## Entity Framework Core Project (`learning-entity-framework`)

This project focuses on using EF Core to handle database operations through domain entities.

### Features
- **Code-First Approach**: Defining entities like `User` and generating database schema via migrations.
- **Change Tracking**: Demonstrates how EF Core tracks entity states (`Added`, `Unchanged`, `Modified`, etc.) before and after saving.
- **DbContext Configuration**: Dependency injection setup for PostgreSQL.

### Prerequisites & Setup
1. **EF Core Tools**: Install EF Core tools globally if you haven't:
   ```bash
   dotnet tool install --global dotnet-ef
   ```
2. **PostgreSQL Provider**: Installed via `dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL`.
3. **Database Migrations**:
   - List migrations: `dotnet ef migrations list`
   - Add new migration: `dotnet ef migrations add "YourMigrationName"`
   - Apply migrations: `dotnet ef database update`

---

## Getting Started

1. Clone the repository.
2. Ensure you have a PostgreSQL server running locally.
3. Update connection strings in `Program.cs` for both projects.
4. Run the projects using:
   ```bash
   dotnet run --project learning-ado-net
   # OR
   dotnet run --project learning-entity-framework
   ```

## Learning Objectives
- Understanding the difference between low-level (ADO.NET) and high-level (ORM) database access.
- Learning how to use PostgreSQL as a database provider in .NET.
- Managing database schema via SQL scripts vs. EF Core Migrations.
- Understanding the role of the EF Core `ChangeTracker`.