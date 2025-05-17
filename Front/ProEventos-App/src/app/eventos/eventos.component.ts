import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-eventos',
  imports: [CommonModule],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss',
})
export class EventosComponent {
  public eventos: any = [
    {
      Tema: 'Angular Js',
      Local: 'Ubatuba',
    },
    {
      Tema: 'Flutter',
      Local: 'Ilhabela',
    },
    {
      Tema: '.Net',
      Local: 'São Sebastião',
    },
    {
      Tema: 'React',
      Local: 'Tabubaté',
    },
    {
      Tema: 'Angular 18',
      Local: 'Caragua',
    },
  ];
}
