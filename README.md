# Patient Management System

A full-stack Patient Management Application developed using the following(s) technologies.

## Technology Stack

### Backend

- .NET 8 Web API
- ASP.NET Core
- C#
- SQL Server
- Dapper
- MediatR
- CQRS Pattern
- FluentValidation
- API Versioning
- In-Memory Caching
- Serilog
- Swagger
- Dependency Injection
- RESTful API Design

### Frontend

- Angular 20
- TypeScript
- Angular Material
- Reactive Forms
- Angular Routing
- HTTP Client
- RxJS

---

# Project Structure

```text
PatientManagement
│
├── backend
│   └── PatientManagement
│       ├── PatientManagement.API
│       ├── PatientManagement.Application
│       ├── PatientManagement.Domain
│       └── PatientManagement.Infrastructure
│
├── frontend
│   └── src
│       ├── app
│       │   ├── core
│       │   │   ├── interceptors
│       │   │   ├── models
│       │   │   ├── services
│       │   │   └── validators
│       │   │
│       │   ├── features
│       │   │   └── patients
│       │   │       ├── patient-details
│       │   │       ├── patient-form
│       │   │       └── patient-list
│       │   │
│       │   ├── shared
│       │   │   ├── components
│       │   │   ├── confirm-dialog
│       │   │   ├── loading-spinner
│       │   │   ├── material
│       │   │   └── utils
│       │   │
│       │   ├── app.config.ts
│       │   ├── app.html
│       │   ├── app.routes.ts
│       │   ├── app.scss
│       │   └── app.ts
│       │
│       └── environments
│
├── database
│   ├── 001_Create_Database.sql
│   ├── 002_Create_Patients_Table.sql
│   └── 003_Seed_Data.sql
│
├── postman
│   └── Patient Management API.postman_collection.json
│
└── README.md
```

---

# Features

## Backend

- CRUD APIs
- Clean Architecture
- CQRS with MediatR
- Dapper Repository Pattern
- FluentValidation
- Global Exception Handling
- API Versioning
- In-Memory Caching
- Serilog Logging
- Swagger Documentation
- Soft Delete

## Frontend

- Patient Dashboard
- Search
- Server-side Pagination
- Add Patient
- Edit Patient
- Delete Patient
- View Patient
- Responsive UI
- Angular Material
- Snackbar Notifications
- Loading Indicator

---

# Database Setup

1. Open SQL Server Management Studio (SSMS).
2. Execute the following scripts in order:

```text
001_Create_Database.sql
002_Create_Patients_Table.sql
003_Seed_Data.sql
```

3. Update the SQL Server connection string in `appsettings.json` if required.

```text
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=PatientManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
```

---

# Backend Setup

Navigate to the backend solution:

```bash
cd backend/PatientManagement
```

Restore NuGet packages:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

Open Swagger:

```text
https://localhost:xxxx/swagger
```

---

# Frontend Setup

Navigate to the Angular project:

```bash
cd frontend/PatientManagement-UI
```

Install dependencies:

```bash
npm install
```

Run the application:

```bash
ng serve -o
```

Copy Paste in Browser if required:

```text
http://localhost:4200
```

---

# API Endpoints

| Method | Endpoint                | Description             |
| ------ | ----------------------- | ----------------------- |
| GET    | /api/v1/patients        | Get All Patients        |
| GET    | /api/v1/patients/{id}   | Get Patient By Id       |
| POST   | /api/v1/patients/upsert | Create / Update Patient |
| DELETE | /api/v1/patients/{id}   | Soft Delete Patient     |

---

# Deliverables

The submission includes:

- Complete Visual Studio 2022 Solution (.NET 8)
- Angular 20 Application
- SQL Server 2022 Database Scripts
- Postman API Collection
- README Documentation

# Assumptions

- Soft Delete is implemented using the `IsActive` column.
- Both Active and Inactive patients are displayed in the dashboard.
- Edit and Delete actions are disabled for inactive patients.
- Patient list supports server-side pagination and search.
- In-Memory Cache is invalidated after Create, Update and Delete operations.
- Logging is implemented using Serilog.
- API Versioning is implemented using URL versioning (`/api/v1/...`).

---

# Author

Prashant Rai
