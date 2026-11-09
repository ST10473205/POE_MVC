# POE_MVC
MVC# POE – Event Management System

## 1. Project Overview

POE is an event management system developed using ASP.NET Core and C#. The system consists of two projects: a Web API and an MVC application.

The purpose of the system is to provide a platform where users can access event information, manage their profiles, enrol in events and view event results.

The system separates the backend functionality from the frontend interface to improve organisation, maintainability and communication between the two applications.

## 2. Technologies Used

- C#
- ASP.NET Core Web API
- ASP.NET Core MVC
- .NET 8
- SQL Server
- Entity Framework Core
- HTML
- CSS
- JavaScript
- Bootstrap
- Git and GitHub

## 3. Project Structure

The solution contains two main projects.

### 3.1 POE – Web API (Backend)

The Web API handles the application's backend operations and provides endpoints for communication with the database.

**Main folders and files:**

- **Controllers:** Contains the API controllers responsible for handling requests and responses.
  - AuthController – handles user authentication.
  - OrganisersController – manages organiser-related operations.
  - ParticipantsController – manages participant-related operations.

- **Models:** Contains the data models and DTOs used to represent and transfer information.
  - EnrolmentDto
  - EventModel
  - loginDTO
  - ParticipantResultDto
  - UserModel
  - UserProfileDto

- **Services:** Contains services used to support application functionality.

- **appsettings.json:** Stores application configuration settings.

- **Program.cs:** Configures the application services, middleware and API startup.

### 3.2 POE MVC – Frontend

The MVC application provides the user interface through which users interact with the system.

**Main folders and files:**

- **Controllers:** Handles user requests and connects the views to the backend services.
  - AccountController
  - EventsController
  - HomeController
  - ProfileController
  - ResultsController

- **Models:** Contains view models and DTOs used to transfer information between the MVC controllers and views.
  - AuthResponseDto
  - CreateEnrolmentViewModel
  - ErrorViewModel
  - EventViewModel
  - LoginViewModel
  - ParticipantResultDto
  - UserProfileDto

- **Views:** Contains the Razor `.cshtml` pages displayed to users.
  - Account – Login page.
  - Events – Create, Details, Enrol and Index pages.
  - Home – Home page.
  - Profile – Profile page.
  - Results – Results page.
  - Shared – Shared layout and common view components.

- **wwwroot:** Contains static resources such as CSS, JavaScript, images and libraries used to design the website.

- **Program.cs:** Configures and starts the MVC application.

## 4. Main System Functionality

The system is designed to support the following functionality:

- User login and authentication.
- Organiser and participant account management.
- Viewing available events.
- Creating and managing events.
- Viewing event details.
- Enrolling in events.
- Managing user profiles.
- Viewing participant results.

## 5. System Architecture

The application follows a separation between the frontend and backend.

1. Users interact with the MVC application through the website.
2. MVC controllers handle user requests.
3. The MVC application communicates with the Web API through HTTP requests.
4. The Web API processes requests and performs the required backend and database operations.
5. Responses are returned to the MVC application and displayed to users.

## 6. How to Run the Project

1. Clone the repository from GitHub.
2. Open the solution file in Visual Studio.
3. Restore the required NuGet packages.
4. Configure the database connection string.
5. Ensure the database is available.
6. Build the solution.
7. Run the Web API project.
8. Run the MVC project and access the website through the browser.

## 7. Repository Structure

```text
POE/
│
├── POE/                 # Web API project
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   ├── Properties/
│   └── Program.cs
│
├── POE MVC/             # MVC frontend project
│   ├── Controllers/
│   ├── Models/
│   ├── Views/
│   ├── Services/
│   ├── wwwroot/
│   └── Program.cs
│
└── README.md
```

## 8. Version Control

GitHub is used to manage the source code and track development progress. Commits are used to document changes, improvements and new features throughout the development process.

---

**Project:** POE – Event Management System  
**Framework:** ASP.NET Core (.NET 8)  
**Language:** C# and API
