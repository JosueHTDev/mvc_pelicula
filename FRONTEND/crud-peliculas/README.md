# CRUD Películas - Angular 19

Proyecto Angular para mantenimiento de películas, consumiendo una Web API en .NET.

## Requisitos previos

- Node.js 18+ (recomendado 20+)
- npm 9+
- Angular CLI 19

```bash
npm install -g @angular/cli
```

## Instalación y ejecución

```bash
# 1. Instalar dependencias
npm install

# 2. Correr el servidor de desarrollo
ng serve

# 3. Abrir en el navegador
# http://localhost:4200
```

## Endpoints del backend consumidos

| Método | URL                                  | Descripción         |
|--------|--------------------------------------|---------------------|
| GET    | https://localhost:7000/api/pelicula  | Listar películas    |
| GET    | https://localhost:7000/api/pelicula/{id} | Obtener por ID  |
| POST   | https://localhost:7000/api/pelicula  | Crear película      |
| PUT    | https://localhost:7000/api/pelicula  | Editar (id en body) |
| DELETE | https://localhost:7000/api/pelicula/{id} | Eliminar        |
| GET    | https://localhost:7000/api/generoPelicula | Listar géneros |

> ⚠️ Si el endpoint de géneros tiene una URL diferente, ajústala en:
> `src/app/services/pelicula/genero-pelicula.service.ts`

## Estructura del proyecto

```
src/app/
├── models/
│   └── pelicula/
│       ├── PeliculaDto.model.ts
│       └── GeneroPeliculaDto.model.ts
├── services/
│   └── pelicula/
│       ├── pelicula.service.ts
│       └── genero-pelicula.service.ts
├── pages/
│   └── mantenimiento/
│       ├── mantenimiento-pelicula-list/
│       └── mantenimiento-pelicula-editar/
├── app.config.ts
├── app.routes.ts
└── app.ts
```

## Solución de CORS

Si el backend rechaza las peticiones por CORS, agrega en tu API .NET:

```csharp
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

app.UseCors("AllowAll");
```
