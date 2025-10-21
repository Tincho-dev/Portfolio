# Portfolio React Frontend

This is the React frontend for the Portfolio application, migrated from Blazor WebAssembly.

## Technology Stack

- **React 18** with TypeScript
- **Vite** for build tooling
- **React Router** for routing
- **Zustand** for state management
- **Axios** for HTTP requests
- **SCSS Modules** for styling
- **Bootstrap 5** for UI components

## Project Structure

```
src/
├── components/          # Reusable components
│   ├── Layout/         # Layout components (MainLayout, NavMenu)
│   ├── About/          # About page components
│   ├── Fuente/         # Fuente/Entropy components
│   ├── GitHub/         # GitHub components
│   ├── Simulador/      # Simulator components
│   └── NumerosAleatorios/  # Random numbers components
├── pages/              # Page components
├── services/           # API service layer
├── stores/             # Zustand state stores
├── models/             # TypeScript interfaces
├── config/             # Configuration files
├── styles/             # Global styles
└── utils/              # Utility functions
```

## Development

### Prerequisites

- Node.js 20.x LTS
- npm or yarn

### Installation

```bash
npm install
```

### Running the Development Server

```bash
npm run dev
```

The app will be available at `http://localhost:5173`

### Building for Production

```bash
npm run build
```

The build output will be in the `dist` directory.

### Preview Production Build

```bash
npm run preview
```

## Environment Variables

Create `.env.development` and `.env.production` files:

```
VITE_API_URL=http://localhost:5000  # Development
VITE_API_URL=https://martinlopezrubio.azurewebsites.net  # Production
```

## API Integration

The app connects to the backend API through the service layer defined in `src/services/`. All API calls are managed through Zustand stores for state management.

## Deployment

The app is automatically deployed to Azure Static Web Apps when changes are pushed to the master branch via GitHub Actions.
