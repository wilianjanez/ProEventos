import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CollapseModule } from 'ngx-bootstrap/collapse';
@Component({
  selector: 'app-eventos',
  imports: [CommonModule, FormsModule, CollapseModule],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss',
})
export class EventosComponent {
  public eventos: any = [];
  public eventosFiltrados: any = [];
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

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) =>
        evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get('https://localhost:4002/api/eventos').subscribe({
      next: (value) => (
        (this.eventos = value), (this.eventosFiltrados = value)
      ),
      error: (err) => console.log(err),
    });
  }

  public deleteEvento(id: string): void {
    this.http.delete(`https://localhost:4002/api/eventos/${id}`).subscribe({
      next: (value) => (this.eventos = value),
      error: (err) => console.log(err),
    });
  }

  alterarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }
}
