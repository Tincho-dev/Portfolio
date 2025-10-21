import { apiClient } from './apiClient';
import { API_ENDPOINTS } from '../config/api.config';
import { SimuladorRequest, SimuladorResult } from '../models/Simulador';

export class SimuladorService {
  async simular(request: SimuladorRequest): Promise<SimuladorResult> {
    return apiClient.post<SimuladorResult>(API_ENDPOINTS.simulador.simular, request);
  }

  async getTiemposEspera(fecha?: string): Promise<any> {
    const url = fecha 
      ? `${API_ENDPOINTS.simulador.tiemposEspera}?fecha=${fecha}`
      : API_ENDPOINTS.simulador.tiemposEspera;
    return apiClient.get<any>(url);
  }
}

export const simuladorService = new SimuladorService();
