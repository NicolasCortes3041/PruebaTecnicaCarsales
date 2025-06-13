# 🎯 Proyecto Fullstack: Angular 17 + .NET 8

Este repositorio contiene un **monorepo** con una aplicación compuesta por dos partes:

- 🖥️ **Frontend:** Aplicación Angular 17 para la interfaz de usuario
- 🔧 **Backend (BFF):** API REST desarrollada con .NET 8 que actúa como Back-End For Front-End (BFF)

---

## 📂 Estructura del proyecto

```
mi-app/
├── BFF/                      # API REST .NET 8 (BFF)
├── RickMortyFront/
│   └── frontend/             # Aplicación Angular 17
│       └── src/
└── README.md
```

## ⚙️ Requisitos previos

Asegúrate de tener instaladas las siguientes herramientas:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Angular CLI 17](https://angular.io/cli) → `npm install -g @angular/cli`

---

## 🔧 Compilación y ejecución del backend (.NET 8)

Desde la raíz del proyecto:

```bash
cd BFF

dotnet clean
dotnet restore
dotnet build
dotnet run
```

Esto iniciará la API en:

```
http://localhost:5078
```


---
## 🌐 Ejecución del frontend (Angular 17)

Desde la raíz del proyecto:

```bash
cd RickMortyFront/frontend

npm install
npm run start
```

Esto iniciará la aplicación en:

```
http://localhost:4200
```

---

## 📦 Características

- Backend BFF con .NET 8 y `HttpClient` configurado para consumir servicios externos
- API segura con CORS habilitado para permitir solicitudes desde Angular (`localhost:4200`)
- Frontend moderno con Angular 17 (standalone) y comunicación vía `HttpClient`
- Tabla dinámica con paginación, búsqueda y componentes reutilizables
