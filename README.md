<<<<<<< HEAD
# SleepTracker — Vue 3 + ASP.NET Core + MySQL

## Estrutura do projeto

```
SleepTracker-Full/
├── frontend/   → Vue 3 + Tailwind + Pinia + Vue Router + Axios
└── backend/
    └── SleepTracker/  → ASP.NET Core 9 + EF Core + MySQL + JWT
```

---

## ⚡ Setup rápido

### 1. Banco de dados (MySQL)

Crie o banco de dados:
```sql
CREATE DATABASE sleeptracker CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
```

### 2. Backend (ASP.NET)

Edite `backend/SleepTracker/appsettings.json`:
- Troque `SUA_SENHA_AQUI` pela senha do MySQL
- Troque `TROQUE_ESTA_CHAVE_SECRETA...` por uma string aleatória de 32+ caracteres

```bash
cd backend/SleepTracker
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

API disponível em: `https://localhost:7000`
Swagger em: `https://localhost:7000/swagger`

### 3. Frontend (Vue)

```bash
cd frontend
npm install
npm run dev
```

App disponível em: `http://localhost:5173`

---

## Endpoints da API

| Método | Rota                  | Auth | Descrição              |
|--------|-----------------------|------|------------------------|
| POST   | /api/auth/register    | ❌   | Criar conta            |
| POST   | /api/auth/login       | ❌   | Login                  |
| GET    | /api/user/profile     | ✅   | Ver perfil             |
| PUT    | /api/user/profile     | ✅   | Atualizar perfil       |
| GET    | /api/sleep            | ✅   | Listar registros       |
| POST   | /api/sleep            | ✅   | Criar registro         |
| PUT    | /api/sleep/{id}       | ✅   | Atualizar registro     |
| DELETE | /api/sleep/{id}       | ✅   | Excluir registro       |
| GET    | /api/sleep/stats      | ✅   | Estatísticas de sono   |

---

## Stack completa

**Frontend:** Vue 3, Vue Router, Pinia, Axios, Tailwind CSS, ApexCharts  
**Backend:** ASP.NET Core 9, Entity Framework Core, Pomelo MySQL, JWT, BCrypt, Swagger  
**Banco:** MySQL 8+
=======
# SleepTracker
>>>>>>> cdde104e1c73c4fb9621673c47d950c17c817817
