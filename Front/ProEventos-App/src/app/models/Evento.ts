import { Lote } from './Lote';
import { RedeSocial } from './RedeSocial';
import { EventoPalestrante } from './EventoPalestrante';

export interface Evento {
  id: number;
  local: string;
  data?: Date;
  tema: string;
  qtdPessoas: number;
  lote: string;
  imageURL: string;
  telefone: string;
  email: string;
  lotes: Lote[];
  redeSociais: RedeSocial[];
  eventoPalestrante: EventoPalestrante[];
}
