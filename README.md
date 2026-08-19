# Student Management System

A web-based **Student Management System** developed using **ASP.NET Core MVC**, **C#**, **Entity Framework Core**, and **SQL Server**. The project provides a structured platform for managing student information, departments, authentication, and role-based access.

The application is also **Dockerized** to make deployment and execution easier across different environments.

## 🚀 Features

* Admin and Student login
* Role-based access
* Admin dashboard
* Student profile management
* Add, edit, view, and delete student records
* Department management
* Student–Department relationship
* SQL Server database integration
* Entity Framework Core ORM
* Entity Framework Core migrations
* Form validation
* Docker containerization

## 🛠️ Technologies Used

* **C#**
* **ASP.NET Core MVC**
* **Entity Framework Core**
* **SQL Server**
* **Docker**
* **HTML**
* **CSS**
* **Razor Views**
* **Visual Studio Code**

## 🏗️ Architecture

The project follows the **Model-View-Controller (MVC)** architecture.

* **Model** – Represents application data and database entities.
* **View** – Provides the user interface using Razor Views.
* **Controller** – Handles HTTP requests, application logic, and communication between Models and Views.


## 🗄️ Database

The project uses **Microsoft SQL Server** as the database and **Entity Framework Core** for database operations.

### Student Entity

The Student entity contains information such as:

* Student ID
* Name
* Username
* Password
* Role
* Course
* Mobile Number
* Semester
* CGPA
* Date of Birth
* Hometown
* Department ID

### Department Entity

The Department entity contains:

* Department ID
* Department Name

A relationship is maintained between **Student** and **Department** using `DepartmentId` as a foreign key.

## 🔐 Authentication & Role-Based Access

The system provides different access based on the user's role.

### Admin

Admin users can:

* Login to the system
* Access the Admin Dashboard
* Manage student records
* Manage departments
* View student information

### Student

Student users can:

* Login using their credentials
* Access their profile
* View their personal information

## 🔄 CRUD Operations

The system supports standard CRUD operations for managing student data:

* **Create** – Add a new student
* **Read** – View student information
* **Update** – Edit student information
* **Delete** – Remove student records

## 🧩 Entity Framework Core

Entity Framework Core is used as the ORM to communicate with SQL Server.

The project uses:

* `Microsoft.EntityFrameworkCore`
* `Microsoft.EntityFrameworkCore.SqlServer`
* `Microsoft.EntityFrameworkCore.Tools`

EF Core migrations are used to create and update the database schema.

### Apply Database Migrations

```bash
dotnet ef database update
```

## 🐳 Docker

The application is containerized using **Docker**.

A `Dockerfile` is included in the project to define the environment and steps required to build and run the ASP.NET Core MVC application inside a Docker container.

### Build Docker Image

```bash
docker build -t student-management-system .
```

### Run Docker Container

```bash
docker run -d -p 8080:8080 --name student-management-system student-management-system
```

The application can then be accessed at:

```text
http://localhost:8080
```

> Make sure the port matches the port configured in your Dockerfile/ASP.NET Core application.

## ⚙️ How to Run Locally

### Prerequisites

Make sure the following are installed:

* .NET SDK
* Visual Studio
* SQL Server
* SQL Server Management Studio (SSMS)
* Docker Desktop (optional, for containerized execution)

### 1. Clone the Repository

```bash
git clone <repository-url>
cd StudentManagementSystem
```

### 2. Configure the Database

Update the SQL Server connection string in `appsettings.json` according to your local SQL Server configuration.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=StudentManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Apply EF Core Migrations

```bash
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

Alternatively, open the project in **Visual Studio** and run it using the configured launch profile.

## 📸 Application Modules

The application includes the following major modules:

* Login / Authentication
* Admin Dashboard
* Student Management
* Student Profile
* Department Management
* Database Management

## 📚 Learning Outcomes

Through this project, I gained practical experience in:

* C# programming
* ASP.NET Core MVC
* MVC architecture
* Razor Views
* Entity Framework Core
* SQL Server
* CRUD operations
* Database relationships
* Foreign keys
* EF Core migrations
* Authentication and authorization
* Role-based access
* Docker and containerization
* Building and running an ASP.NET Core application in a container



## 👩‍💻 Author

**Namita Sharma**

B.Tech Computer Science & Engineering
ITS Engineering College

## 📄 License

This project was developed for **educational and internship purposes**.
