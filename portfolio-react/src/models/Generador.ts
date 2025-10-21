// Generador/Random Numbers models

export interface GeneradorRequest {
  metodo: string;
  semilla?: number;
  digitosDeseados?: number;
  totalDeNumerosGenerar: number;
  constanteMultiplicativa?: number;
  constanteAditiva?: number;
  modulo?: number;
  digitos?: number;
  listaSemilla?: number[];
}

export interface GeneradorResult {
  numeros: number[];
}

export interface PruebaEstadisticaResult {
  nombre: string;
  pasaPrueba: boolean;
  detalles: string;
}
