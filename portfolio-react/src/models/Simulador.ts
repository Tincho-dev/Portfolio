// Simulador models

export enum Atracciones {
  RiseOfTheResistance = 'RiseOfTheResistance',
  MilleniumFalcon = 'MilleniumFalcon',
}

export interface DatoEspera {
  nombre: Atracciones;
  tiempoEspera?: Record<string, number>;
}

export interface SimuladorRequest {
  ingresosEsperados: number;
}

export interface SimuladorResult {
  estado: string;
  respuesta: string;
  tiemposDeEspera: DatoEspera[];
  tiempoEsperaPromedioMF: number;
  tiempoEsperaPromedioRR: number;
}
