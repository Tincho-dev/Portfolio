// API Configuration
export const API_BASE_URL = import.meta.env.VITE_API_URL || 'http://localhost:5000';

export const API_ENDPOINTS = {
  // Professional/About endpoints
  professional: {
    get: (id: number) => `/api/Professional/${id}`,
    getAll: '/api/Professional',
  },
  // Entropia/Fuente endpoints
  fuente: {
    calcular: '/api/Entropia/calcular',
    codificar: '/api/Entropia/codificar',
    decodificar: '/api/Entropia/decodificar',
  },
  // Simulador endpoints
  simulador: {
    simular: '/api/Simulador/simular',
    tiemposEspera: '/api/Simulador/tiempos-espera',
  },
  // GitHub endpoints
  github: {
    user: (username: string) => `/api/GitHub/user/${username}`,
    repositories: (username: string) => `/api/GitHub/repositories/${username}`,
  },
  // Generador endpoints
  generador: {
    generar: '/api/Generador/generar',
  },
};
