import { RedeSocial } from './RedeSocial';
import { EventoPalestrante } from './EventoPalestrante';

export interface Palestrante {
  id: number;
  nome: string;
  curriculo: string;
  imageURL: string;
  telefone: string;
  email: string;
  redeSociais: RedeSocial[];
  eventoPalestrante: EventoPalestrante[];
}
