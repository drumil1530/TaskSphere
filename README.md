# 🧠 TaskSphere

**TaskSphere** is a full-stack task management application built with **React (TypeScript)** and **.NET 9 Web API**, designed to help users efficiently organize and manage their daily tasks.

---

## 📂 Project Structure

```
TaskSphere
├── TaskSphere.API
│   ├── Data
│   │   └── AppDbContext.cs
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   ├── TaskSphere.API.csproj
│   ├── appsettings.Development.json
│   ├── appsettings.json
├── TaskSphere.sln
└── task-sphere-frontend
    ├── public
    │   └── task-sphere-favicon.png
    ├── src
    │   ├── App.tsx
    │   ├── assets
    │   ├── index.css
    │   └── main.tsx
    ├── package.json
    ├── tsconfig.json
    ├── vite.config.ts
```

---

## 🚀 Tech Stack

### 🖥️ Frontend

* **React 19 + TypeScript**
* **Vite 7**
* **Tailwind CSS v4**
* **Axios**
* **React Router DOM v7**
* **Remixicon**

### ⚙️ Backend

* **.NET 9 Web API**
* **Entity Framework Core 9 (SQL Server)**
* **JWT Authentication**
* **Swagger (Swashbuckle)**
* **CORS Enabled**

---

## 🤉 Frontend Setup

```bash
cd task-sphere-frontend
npm install
npm run dev
```

Frontend runs at:
👉 [http://localhost:5280](http://localhost:5280)

---

## ⚙️ Backend Setup

```bash
cd TaskSphere.API
dotnet restore
dotnet ef database update
dotnet run
```

Backend runs at:

* HTTP → [http://localhost:5080](http://localhost:5080)
* HTTPS → [https://localhost:5180](https://localhost:5180)
* Swagger → [https://localhost:5180/swagger](https://localhost:5180/swagger)

---

## 🌐 Environment Variables

### Frontend

Create a `.env` file in the root of the frontend folder:

```bash
VITE_API_BASE_URL=https://localhost:5180/api
```

### Backend

Add your environment-specific values inside `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TaskSphereDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "YOUR_SECRET_KEY",
    "Issuer": "TaskSphere",
    "Audience": "TaskSphereUsers"
  }
}
```

---

## 🔄 Common Commands

### Entity Framework

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Linting (Frontend)

```bash
npm run lint
```

---

## 🧠 Commit Convention

This project follows **Conventional Commits**:

```
<type>(scope?): <description>

types: feat | fix | docs | style | refactor | test | chore
```

Example:

```
feat(api): add user authentication with JWT
```

---

## 🗞 License

This project is licensed under the **MIT License** — you are free to use, modify, and distribute it.

---

## ✨ Author

**Drumil Thummar (潛心)**

> A focused learner building his path through code — one project at a time.

---
