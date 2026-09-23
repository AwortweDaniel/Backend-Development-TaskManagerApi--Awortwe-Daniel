# Task Manager API (C# .NET)

A simple REST API for managing tasks, built with **ASP.NET Core Web API** and **Entity Framework Core**, for the NSS Developer Technical Assignment (Backend Development track).

## Features

- Full CRUD for tasks: `GET`, `POST`, `PUT`, `DELETE`
- Each task has an Id, Title, Description, Status (`Pending`, `InProgress`, `Completed`) and CreatedDate
- Entity Framework Core with **SQLite** (a local `tasks.db` file — no separate database server to install)
- The database is created automatically and seeded with three sample tasks on first run
- Input validation via data annotations (title required, 3–100 characters; description up to 500 characters)
- Proper HTTP status codes (200, 201, 204, 400, 404)
- Swagger UI for interactive testing, served at the app's root URL
- CORS enabled for all origins, so a separately hosted frontend (e.g. the React app) can call it

## Project structure

```
TaskManagerApi.sln
TaskManagerApi/
├── Program.cs                    # App startup: services, DB creation/seeding, middleware
├── appsettings.json               # Configuration, including the SQLite connection string
├── Models/
│   ├── TaskItem.cs                # EF Core entity
│   └── TaskItemStatus.cs          # Pending / InProgress / Completed
├── Dtos/
│   ├── TaskCreateDto.cs           # POST request body + validation rules
│   ├── TaskUpdateDto.cs           # PUT request body + validation rules
│   └── TaskResponseDto.cs         # Shape returned to clients
├── Data/
│   ├── AppDbContext.cs            # EF Core DbContext
│   └── DbSeeder.cs                # Seeds sample tasks on first run
└── Controllers/
    └── TasksController.cs         # /api/tasks endpoints
```

## Endpoints

| Method | Route             | Description               |
|--------|-------------------|----------------------------|
| GET    | `/api/tasks`      | List all tasks             |
| GET    | `/api/tasks/{id}` | Get a single task          |
| POST   | `/api/tasks`      | Create a task               |
| PUT    | `/api/tasks/{id}` | Replace a task's fields    |
| DELETE | `/api/tasks/{id}` | Delete a task               |

Example request body for `POST`/`PUT`:

```json
{
  "title": "Write documentation",
  "description": "Add setup instructions to the README",
  "status": "Pending"
}
```

`status` accepts `"Pending"`, `"InProgress"`, or `"Completed"`. Invalid status strings or numeric values return HTTP 400.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

Check your setup with:

```bash
dotnet --version
```

## Installation and running

1. Clone the repository and open the project folder:

   ```bash
   git clone <your-repository-url>
   cd <repository-folder>
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Run the API:

   ```bash
   dotnet run --project TaskManagerApi
   ```

4. Open **http://localhost:5080** in a browser — Swagger UI loads at the root and lets you try every endpoint directly. You can also import the routes into Postman using that same base URL.

On first run, EF Core creates `tasks.db` in the project folder and seeds it with three sample tasks, so `GET /api/tasks` returns data immediately.

## Notes

- No separate React or Flutter apps are included here, per the assignment ("the backend developer does not need to build the React or Flutter applications").
- To reset the sample data, stop the app and delete `TaskManagerApi/tasks.db`, then run again.
- Swagger UI is only enabled in the Development environment (the default when running `dotnet run` locally).

## Run in Visual Studio 2026 (Windows)

1. In **Visual Studio Installer**, choose **Modify** and install **ASP.NET and web development**. Ensure the **.NET 8 SDK/targeting pack** is installed; this project targets `net8.0`. Visual Studio 2026 alone does not install every optional SDK.
2. Extract the ZIP, then open `TaskManagerApi.sln` using **File > Open > Project/Solution**. Trust the solution if prompted.
3. Wait for NuGet package restore. If needed, right-click the solution in **Solution Explorer** and select **Restore NuGet Packages**. Internet access is needed the first time.
4. Right-click **TaskManagerApi** and choose **Set as Startup Project**. Select the `http` launch profile in the toolbar, then press **F5** (or **Ctrl+F5**).
5. Open `http://localhost:5080/` for Swagger. If you choose `https`, accept the local development certificate prompt and use the HTTPS URL shown by Visual Studio.

If Visual Studio reports a missing .NET 8 SDK, install it through Visual Studio Installer or the official .NET 8 SDK download, then reopen Visual Studio. No external SQLite server is required.

## Quick API checks in Swagger

1. `GET /api/tasks` → **200**, initially three sample tasks.
2. `GET /api/tasks/999999` → **404**.
3. `POST /api/tasks` with the example JSON above → **201**. Copy the returned `id`.
4. `GET /api/tasks/{id}` with the copied ID → **200**.
5. `PUT /api/tasks/{id}` with a changed title and `"status": "Completed"` → **200**; the updated title and status appear.
6. `POST /api/tasks` with `"title": "   "` → **400**. An invalid status such as `"Unknown"` also returns **400**.
7. `DELETE /api/tasks/{id}` → **204**, and a subsequent GET for that ID → **404**.

Replace `{id}` with the actual number, without braces. These are manual acceptance checks; this repository currently has no automated test project.

## Submission

Create a **public GitHub repository**, commit the extracted project with meaningful commit messages, and send the repository URL (not the ZIP) to `info@innorik.com` by **23 September 2026**. Include your full name and the Backend Development position/track in the email. Never commit generated `tasks.db`, `bin/`, or `obj/` files.
