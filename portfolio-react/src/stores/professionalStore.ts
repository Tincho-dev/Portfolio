import { create } from 'zustand';
import { Professional } from '../models/Professional';
import { professionalService } from '../services/professionalService';

interface ProfessionalState {
  professional: Professional | null;
  loading: boolean;
  error: string | null;
  fetchProfessional: (id: number) => Promise<void>;
}

export const useProfessionalStore = create<ProfessionalState>((set) => ({
  professional: null,
  loading: false,
  error: null,
  fetchProfessional: async (id: number) => {
    set({ loading: true, error: null });
    try {
      const professional = await professionalService.getProfessional(id);
      set({ professional, loading: false });
    } catch (error) {
      set({ error: 'Error fetching professional data', loading: false });
    }
  },
}));
