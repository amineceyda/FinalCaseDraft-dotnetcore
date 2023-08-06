# SiteManangmentAPI 
SiteManangmentAPI is a web project built using .NET that allows administrators to manage dues and common utility bills for apartments on a site. The system supports two types of users: Admins and Users. Admins have full control over the system, while Users have limited functionality.

## Table of Contents

- [Project Overview](#project-overview)
- [Layers](#layers)
- [Database Setup](#database-setup)
- [Usage](#usage)
- [Requirements](#requirements)
- [Contact](#contact)

## Project Overview

SiteManangmentAPI is a web application that provides the following functionalities:

- Admins can enter apartment information, resident user information, dues and billing information, view incoming payments, view messages, see the monthly debt-credit list, manage contacts, and perform CRUD operations on flat/housing information.
- Admins can send daily email reminders to users who have not paid their bills.
- Users can view invoice and dues information assigned to them, and make credit card payments.
- Users can send messages to the administrator.

## Layers

The project is organized into four layers:

1. `SiteManangmentAPI.Business`: This layer contains the business logic and service implementations.
2. `SiteManangmentAPI.Web`: This is the web layer and contains the controllers, middleware, and API endpoints.
3. `SiteManangmentAPI.Data`: This layer handles the data access and contains the database context, repositories, and migrations.
4. `SiteManangmentAPI.Base`: This layer contains shared base classes and utilities used across the application.

## Database Setup

To set up the database, follow these steps:

1. Update the database using the following command:

```
dotnet ef database update --project "./SiteManangmentAPI.Data" --startup-project "./SiteManangmentAPI.Web"
```

2. Perform database migration using the following commands:

```
dotnet ef migrations add InitialMigrations -s ..\SiteManangmentAPI.Web\
dotnet ef migrations add SeedData -s ..\SiteManangmentAPI.Web\
```

3. Update the connection string in `appsettings.json` with your database connection information:

```json
{
   "Logging": {
     "LogLevel": {
       "Default": "Information",
       "Microsoft.AspNetCore": "Warning"
     }
   },
   "AllowedHosts": "*",

   // Connection String for DB
   "ConnectionStrings": {
     "DbType": "MsSql",
     "MsSqlConnection": "Server=localhost\\SQLEXPRESS;Database=siteManangmentDb;Trusted_Connection=True;Encrypt=False;"
   }
}
```

## Usage

To run the SiteManangmentAPI project, use the following commands:

```
cd ./SiteManangmentAPI.Web
dotnet run
```

The application will start and be accessible at `http://localhost:5000` or `https://localhost:5001` in your browser.

## Requirements

- .NET SDK
- Entity Framework Core
- Microsoft SQL Server
