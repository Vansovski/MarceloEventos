import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {


  public eventos: any = [];
  public eventosFiltrados: any = [];

  exibirImagem = true;
  larguraImagem = 150;
  margemImagem = 2;

  private _filtroLista: string= '';

  public get filtroLista(): string
  {
    return this._filtroLista;
  }

  public set filtroLista(value: string)
  {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor:string):any
  {
    filtrarPor = filtrarPor.toLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; }) => evento.tema.toLowerCase().indexOf(filtrarPor) !== -1
    );
  }


  public getEventos(): void {
    this.http.get('http://localhost:5008/api/Eventos').subscribe(
      response =>
      {
        this.eventos = response
        this.eventosFiltrados = response
      }
    );
  }

  public alterarExibicao()
  {
    this.exibirImagem = !this.exibirImagem;
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }
}
