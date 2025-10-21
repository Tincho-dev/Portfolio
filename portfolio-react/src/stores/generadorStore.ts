import { create } from 'zustand';
import { GeneradorResult } from '../models/Generador';
import { generadorService } from '../services/generadorService';

interface GeneradorState {
  numeros: number[];
  loading: boolean;
  error: string | null;
  generarNumeros: (params: any) => Promise<void>;
}

export const useGeneradorStore = create<GeneradorState>((set) => ({
  numeros: [],
  loading: false,
  error: null,
  generarNumeros: async (params: any) => {
    set({ loading: true, error: null });
    try {
      const result = await generadorService.generarNumeros(params);
      set({ numeros: result.numeros, loading: false });
    } catch (error) {
      set({ error: 'Error generating numbers', loading: false });
    }
  },
}));
