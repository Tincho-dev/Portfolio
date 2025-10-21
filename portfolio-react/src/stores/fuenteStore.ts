import { create } from 'zustand';
import { FuenteResult } from '../models/Fuente';
import { fuenteService } from '../services/fuenteService';

interface FuenteState {
  fuenteResult: FuenteResult | null;
  loading: boolean;
  error: string | null;
  cadenaCodificada: string;
  cadenaDecodificada: string;
  calcularFuente: (cadena: string) => Promise<void>;
  codificarCadena: (cadena: string) => Promise<void>;
  decodificarCadena: (cadenaFuente: string, cadenaCodificada: string) => Promise<void>;
  reset: () => void;
}

export const useFuenteStore = create<FuenteState>((set) => ({
  fuenteResult: null,
  loading: false,
  error: null,
  cadenaCodificada: '',
  cadenaDecodificada: '',
  calcularFuente: async (cadena: string) => {
    set({ loading: true, error: null });
    try {
      const result = await fuenteService.calcularFuente(cadena);
      set({ fuenteResult: result, loading: false });
    } catch (error) {
      set({ error: 'Error calculating fuente', loading: false });
    }
  },
  codificarCadena: async (cadena: string) => {
    set({ loading: true, error: null });
    try {
      const cadenaCodificada = await fuenteService.codificarCadena(cadena);
      set({ cadenaCodificada, loading: false });
    } catch (error) {
      set({ error: 'Error encoding string', loading: false });
    }
  },
  decodificarCadena: async (cadenaFuente: string, cadenaCodificada: string) => {
    set({ loading: true, error: null });
    try {
      const cadenaDecodificada = await fuenteService.decodificarCadena({
        cadenaFuente,
        cadenaCodificada,
      });
      set({ cadenaDecodificada, loading: false });
    } catch (error) {
      set({ error: 'Error decoding string', loading: false });
    }
  },
  reset: () => set({ fuenteResult: null, cadenaCodificada: '', cadenaDecodificada: '', error: null }),
}));
