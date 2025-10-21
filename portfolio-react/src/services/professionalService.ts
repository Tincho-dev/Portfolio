import { apiClient } from './apiClient';
import { API_ENDPOINTS } from '../config/api.config';
import { Professional } from '../models/Professional';

export class ProfessionalService {
  async getProfessional(id: number): Promise<Professional> {
    return apiClient.get<Professional>(API_ENDPOINTS.professional.get(id));
  }

  async getAllProfessionals(): Promise<Professional[]> {
    return apiClient.get<Professional[]>(API_ENDPOINTS.professional.getAll);
  }
}

export const professionalService = new ProfessionalService();
