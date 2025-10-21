// Fuente/Entropia models

export interface Letra {
  id: string;
  name: string;
  probability: number;
  frequency: number;
  code?: string;
}

export interface Fuente {
  idFuente: string;
  letras: Letra[];
  cadenaFuente: string;
}

export interface FuenteResult {
  fuente: Fuente;
  entropia: number;
  entropiaMaxima: number;
  informacion: number;
  cadenaCodificada: string;
}

export interface DecodificarRequest {
  cadenaFuente: string;
  cadenaCodificada: string;
}
