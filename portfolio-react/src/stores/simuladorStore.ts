import { create } from 'zustand';
import { SimuladorResult } from '../models/Simulador';
import { simuladorService } from '../services/simuladorService';

interface SimuladorState {
  simuladorResult: SimuladorResult | null;
  loading: boolean;
  error: string | null;
  selectedDate: Date | null;
  simular: (ingresosEsperados: number) => Promise<void>;
  setSelectedDate: (date: Date | null) => void;
}

export const useSimuladorStore = create<SimuladorState>((set) => ({
  simuladorResult: null,
  loading: false,
  error: null,
  selectedDate: null,
  simular: async (ingresosEsperados: number) => {
    set({ loading: true, error: null });
    try {
      const result = await simuladorService.simular({ ingresosEsperados });
      set({ simuladorResult: result, loading: false });
    } catch (error) {
      set({ error: 'Error running simulation', loading: false });
    }
  },
  setSelectedDate: (date: Date | null) => set({ selectedDate: date }),
}));
