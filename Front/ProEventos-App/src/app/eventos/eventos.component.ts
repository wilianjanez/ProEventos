import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  imports: [CommonModule],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss',
})
export class EventosComponent {
  public eventos: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get('https://localhost:4002/api/eventos').subscribe({
      next: (value) => (this.eventos = value),
      error: (err) => console.log(err),
    });
  }

  public deleteEvento(id: string): void {
    this.http.delete(`https://localhost:4002/api/eventos/${id}`).subscribe({
      next: (value) => (this.eventos = value),
      error: (err) => console.log(err),
    });
  }
}
