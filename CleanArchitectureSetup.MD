# 🧼 Clean Architecture Setup – .NET 9

### **Beginner-Friendly Cheat Sheet (Commands + Explanation)**

---

## 📁 1. Create a New Solution

```bash
dotnet new sln -n CleanArchitecture
```

**What it does:**
Creates a new empty `.sln` file called **CleanArchitecture.sln**.
A solution groups multiple projects together.

---

## 📂 2. Create a `src` Folder

```bash
mkdir -p src
```

**What it does:**
Creates a folder named **src** (where all projects will live).

---

## ▶️ 3. Create the Four Projects (Domain, Application, Infrastructure, Web.Api)

Move into the src folder:

```bash
cd ./src
```

### Create Domain Layer (pure business rules)

```bash
dotnet new classlib -n Domain -f net9.0
```

### Create Application Layer (CQRS, interfaces, use-cases)

```bash
dotnet new classlib -n Application -f net9.0
```

### Create Infrastructure Layer (DB, external services)

```bash
dotnet new classlib -n Infrastructure -f net9.0
```

### Create Web API (Minimal API)

```bash
dotnet new webapi -n Web.Api -f net9.0 --use-minimal-apis
```

**What they do:**
Each command generates a .NET 9 project:

* **Domain** → Contains entities, value objects, domain logic
* **Application** → Contains commands/queries, interfaces, DTOs
* **Infrastructure** → Contains EF Core, DB logic, external adapters
* **Web.Api** → The API layer that exposes endpoints

---

## 🔗 4. Add Each Project to the Solution

Move back up:

```bash
cd ..
```

Add projects:

```bash
dotnet sln add src/Domain/Domain.csproj
dotnet sln add src/Application/Application.csproj 
dotnet sln add src/Infrastructure/Infrastructure.csproj
dotnet sln add src/Web.Api/Web.Api.csproj
```

**What it does:**
Registers each project inside the solution so they appear in Visual Studio/Rider/VS Code.

---

## 🔗 5. Add Project References (Clean Architecture Dependencies)

### Application → Domain

```bash
cd ./src/Application
dotnet add reference ../Domain/Domain.csproj
```

**Meaning:**
Application layer can use Domain layer entities & rules.

---

### Infrastructure → Domain + Application

```bash
cd ./src/Infrastructure
dotnet add reference ../Domain/Domain.csproj
dotnet add reference ../Application/Application.csproj
```

**Meaning:**
Infrastructure implements interfaces from Application and uses Domain entities.

---

### Web.Api → Application + Infrastructure

```bash
cd ./src/Web.Api
dotnet add reference ../Application/Application.csproj
dotnet add reference ../Infrastructure/Infrastructure.csproj
```

**Meaning:**
Web API can access Application commands/queries and Infrastructure services.

---

## 📦 6. Install NuGet Packages (Application layer)

Back to Application:

```bash
cd ./src/Application
```

Install MediatR:

```bash
dotnet add package MediatR
```

→ Enables CQRS (Commands/Queries) with request/handler pattern.

Install FluentValidation:

```bash
dotnet add package FluentValidation
dotnet add package FluentValidation.DependencyInjectionExtensions
```

→ Adds input validation rules.

---

# ✅ Final Dependency Graph (Correct Clean Architecture)

```
        ┌──────────────┐
        │   Domain     │
        └──────┬───────┘
               │
        ┌──────▼────────┐
        │  Application  │
        └──────┬────────┘
               │
      ┌────────▼──────────┐
      │   Infrastructure  │
      └───────┬───────────┘
              │
      ┌───────▼─────────┐
      │    Web.Api      │
      └─────────────────┘
```

---

# 📄 Summary Table (Quick Reference)

| Step | Command                          | Purpose                                |
| ---- | -------------------------------- | -------------------------------------- |
| 1    | `dotnet new sln`                 | Create solution                        |
| 2    | `mkdir src`                      | Create source folder                   |
| 3    | `dotnet new classlib` / `webapi` | Create project layers                  |
| 4    | `dotnet sln add`                 | Add projects to solution               |
| 5    | `dotnet add reference`           | Set up Clean Architecture dependencies |
| 6    | Install packages                 | Add MediatR & FluentValidation         |