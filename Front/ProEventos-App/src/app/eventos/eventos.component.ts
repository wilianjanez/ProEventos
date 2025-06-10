import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { EventoService } from '../../services/evento.service';
import { Evento } from '../models/Evento';
@Component({
  selector: 'app-eventos',
  imports: [CommonModule, FormsModule, CollapseModule],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss',
})
export class EventosComponent {
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  larguraImagem: number = 200;
  margemImagem: number = 2;
  mostrarImagem: boolean = false;

  private _filtroLista: string = '';

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

  public deleteEvento(id: string): void {
    this.eventoService.deleteEvento(id).subscribe({
      next: (value) => (this.eventos = value as Evento[]),
      error: (err) => console.log(err),
    });
  }

  alterarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }
}
