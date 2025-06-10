import { Evento } from './Evento';
import { Palestrante } from './Palestrante';

export interface EventoPalestrante {
  eventoId: number;
  evento: Evento;
  palestranteId: number;
  palestrante: Palestrante;
}
