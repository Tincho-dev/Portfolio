import { apiClient } from './apiClient';
import { API_ENDPOINTS } from '../config/api.config';
import { GeneradorRequest, GeneradorResult } from '../models/Generador';

export class GeneradorService {
  async generarNumeros(request: GeneradorRequest): Promise<GeneradorResult> {
    return apiClient.post<GeneradorResult>(API_ENDPOINTS.generador.generar, request);
  }
}

export const generadorService = new GeneradorService();
