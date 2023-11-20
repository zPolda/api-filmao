import { Component } from '@angular/core';
import { Comentario } from '../../../models/comentario.models';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-comentario-listar',
  templateUrl: './comentario-listar.component.html',
  styleUrl: './comentario-listar.component.css'
})
export class ComentarioListarComponent {
  comentarios :  Comentario[] = []
  constructor(
    private client: HttpClient){}

    ngOnInit() : void{
      console.log("O componente foi carregado!");
  
      this.client.get<Comentario[]>("https://localhost:7204/comentario")
        .subscribe({
          //Requisição com sucesso
          next: (comentarios) => {
            this.comentarios = comentarios;
            console.table(comentarios);
          }, 
          //Requisição com erro
          error: (erro) => {
            console.log(erro);
          }
        })
    }
}
