import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { EventoService } from '../../services/evento.service';
import { Evento } from '../models/Evento';
import { DateTimeFormatPipe } from '../helpers/DateTimeFormat.pipe'; //
@Component({
  selector: 'app-eventos',
  imports: [CommonModule, FormsModule, CollapseModule, DateTimeFormatPipe],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss',
})
export class EventosComponent {
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public larguraImagem = 200;
  public margemImagem = 2;
  public mostrarImagem = false;

  private _filtroLista = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista
      ? this.filtrarEventos(this.filtroLista)
      : this.eventos;
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) =>
        evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private eventoService: EventoService) {}

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (value) => (
        (this.eventos = value), (this.eventosFiltrados = value)
      ),
      error: (err) => console.log(err),
    });
  }

  public deleteEvento(id: number): void {
    this.eventoService.deleteEvento(id).subscribe({
      next: (value) => (this.eventos = value as Evento[]),
      error: (err) => console.log(err),
    });
  }

  alterarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }
}
