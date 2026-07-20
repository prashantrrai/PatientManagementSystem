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

```
PatientManagement
│
├── backend
│   ├── PatientManagement.API
│   ├── PatientManagement.Application
│   ├── PatientManagement.Domain
│   └── PatientManagement.Infrastructure
│
├── frontend
│
├── database
│
└── postman
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

1. Open SQL Server Management Studio.
2. Execute scripts in the following order:

```
001_Create_Database.sql
002_Create_Patients_Table.sql
003_Seed_Data.sql
```

---

# Backend Setup

Navigate to

```
backend/PatientManagement
```

Restore packages

```bash
dotnet restore
```

Run the project

```bash
dotnet run
```

Swagger

```
https://localhost:xxxx/swagger
```

---

# Frontend Setup

Navigate to

```
frontend
```

Install packages

```bash
npm install
```

Run

```bash
ng serve
```

Open

```
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

# Assumptions

- Soft Delete is implemented using the IsActive column.
- Inactive patients are displayed in the grid with disabled Edit/Delete actions.
- Server-side pagination is implemented.
- Patient list is cached using In-Memory Cache.
- Cache is refreshed after Create, Update and Delete.
- Logging is implemented using Serilog.

---

# Author

Prashant Rai
