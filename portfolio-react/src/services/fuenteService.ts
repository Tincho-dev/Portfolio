import { apiClient } from './apiClient';
import { API_ENDPOINTS } from '../config/api.config';
import { FuenteResult, DecodificarRequest } from '../models/Fuente';

export class FuenteService {
  async calcularFuente(cadena: string): Promise<FuenteResult> {
    return apiClient.post<FuenteResult>(API_ENDPOINTS.fuente.calcular, { cadena });
  }

  async codificarCadena(cadena: string): Promise<string> {
    return apiClient.post<string>(API_ENDPOINTS.fuente.codificar, { cadena });
  }

  async decodificarCadena(request: DecodificarRequest): Promise<string> {
    return apiClient.post<string>(API_ENDPOINTS.fuente.decodificar, request);
  }
}

export const fuenteService = new FuenteService();
