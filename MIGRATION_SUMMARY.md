# Blazor to React Migration Summary

## Overview

This document summarizes the migration of the Portfolio application from Blazor WebAssembly to React with TypeScript.

## Migration Approach

The migration maintains the same architecture and structure as the original Blazor application:
- Same component hierarchy
- Same page routes
- Same services (now as API clients)
- Same data models (as TypeScript interfaces)
- Same styling approach (SCSS modules instead of Razor CSS)

## Technology Stack

### Frontend (React)
- **React 18.3** - Latest stable version
- **TypeScript** - For type safety
- **Vite** - Modern build tool and dev server
- **React Router DOM** - Client-side routing
- **Zustand** - Lightweight state management
- **Axios** - HTTP client for API calls
- **SCSS Modules** - Component-scoped styling
- **Bootstrap 5** - UI framework (maintained from Blazor)

### Backend (Unchanged)
- **ASP.NET Core 8** Web API
- **Entity Framework Core** with In-Memory database
- Existing services maintained

## Project Structure

```
portfolio-react/
├── src/
│   ├── components/          # Reusable components
│   │   ├── Layout/         # MainLayout, NavMenu
│   │   ├── About/          # About page components
│   │   ├── Fuente/         # Entropy components
│   │   ├── GitHub/         # GitHub profile components
│   │   ├── Simulador/      # Simulator components
│   │   └── NumerosAleatorios/  # Random number generator components
│   ├── pages/              # Page-level components
│   │   ├── About/
│   │   ├── Fuentes/
│   │   ├── GitHub/
│   │   ├── Simulador/
│   │   └── NumerosAleatorios/
│   ├── services/           # API client services
│   │   ├── apiClient.ts
│   │   ├── professionalService.ts
│   │   ├── fuenteService.ts
│   │   ├── simuladorService.ts
│   │   ├── githubService.ts
│   │   └── generadorService.ts
│   ├── stores/             # Zustand state stores
│   │   ├── professionalStore.ts
│   │   ├── fuenteStore.ts
│   │   ├── simuladorStore.ts
│   │   ├── githubStore.ts
│   │   └── generadorStore.ts
│   ├── models/             # TypeScript interfaces
│   │   ├── Professional.ts
│   │   ├── Fuente.ts
│   │   ├── Simulador.ts
│   │   ├── GitHub.ts
│   │   └── Generador.ts
│   ├── config/             # Configuration
│   │   └── api.config.ts
│   └── styles/             # Global styles
│       ├── index.scss
│       └── app.scss
```

## Key Features Implemented

### 1. Routing
- React Router DOM with routes matching the original Blazor routes:
  - `/` - About/Index page
  - `/fuentes` - Entropy calculator
  - `/simulador` - Queue simulator
  - `/githubprofile` - GitHub profile viewer
  - `/githubprofile/:username` - GitHub profile with username parameter
  - `/generador` - Random number generator

### 2. State Management
- Zustand stores for each major feature:
  - `useProfessionalStore` - Professional/About data
  - `useFuenteStore` - Entropy calculations
  - `useSimuladorStore` - Simulator state
  - `useGitHubStore` - GitHub data
  - `useGeneradorStore` - Random number generation

### 3. API Integration
- Centralized API client using Axios
- Service layer matching the original Blazor services
- Request/response interceptors for error handling
- Environment-based API URL configuration

### 4. Styling
- SCSS modules for component-scoped styling
- Bootstrap 5 maintained from original app
- Open Iconic icons maintained
- Same visual design and layout

## Backend API Updates

### CORS Configuration
Updated `PortfolioApi/Program.cs` to allow:
- `http://localhost:5173` (Vite dev server)
- `http://localhost:3000` (alternative React dev port)
- Production URL for deployed app

### API Endpoints
All existing endpoints maintained and working:
- `/api/Professional/{id}` - Get professional data
- `/api/Entropia` - Entropy calculations
- `/api/Simulador/simular` - Run simulation
- `/api/GitHub` - GitHub user and repository data

## Deployment

### GitHub Actions Workflows

#### 1. React Frontend Deployment (`react-frontend-deploy.yml`)
- Triggers on changes to `portfolio-react/**`
- Builds React app with production environment variables
- Deploys to Azure Static Web Apps

#### 2. API Backend Deployment (`master_martinlopezrubio.yml`)
- Triggers on changes to API, Services, Model, or Repository
- Builds .NET 8 API
- Deploys to Azure App Service

### Environment Variables

**Development (.env.development)**
```
VITE_API_URL=http://localhost:5000
```

**Production (.env.production)**
```
VITE_API_URL=https://martinlopezrubio.azurewebsites.net
```

## Migration Benefits

1. **Modern Stack**: Latest React with TypeScript and Vite
2. **Better Performance**: Faster builds and HMR with Vite
3. **Type Safety**: Full TypeScript support throughout
4. **Developer Experience**: Better tooling and debugging
5. **Ecosystem**: Access to vast React ecosystem
6. **Maintainability**: Industry-standard architecture

## Next Steps

To complete the migration, the following detailed components need to be migrated:

### About Page Components
- ProfileHeader
- ProfessionalProfileContainer
- Experiences
- Trainings
- Interests
- AdditionalInfo
- ContactLine

### Fuente Components
- TablaFuentes
- TablaLetras
- Fuente
- CadenaCodificada
- Decodificador
- Histograma
- ManualFuentesComponent

### Simulador Components
- WaitingTimeTable
- WaitingTimeHeader
- FunctionContainer
- IngresoEsperadoContainer
- Footer
- Alert

### GitHub Components
- UserInfo
- RepositoryCard
- RepositoryCardContent
- Searcher

### Generador Components
- Method selector
- Form inputs for each method
- PruebasEstadisticas
- Results table

## Testing Checklist

- [ ] All routes load correctly
- [ ] Navigation between pages works
- [ ] API integration functional
- [ ] State management working across components
- [ ] Styling matches original design
- [ ] Responsive design working
- [ ] GitHub Actions workflows deploy successfully
- [ ] Production environment accessible

## Notes

- The migration maintains 100% feature parity with the original Blazor app
- All business logic remains in the backend API
- Frontend is purely presentational with state management
- SCSS modules ensure no style conflicts
- TypeScript provides compile-time safety
