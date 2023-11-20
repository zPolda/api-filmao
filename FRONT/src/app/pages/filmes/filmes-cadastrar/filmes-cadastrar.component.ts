import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Filme } from '../../../models/filme.models';
import { Comentario } from '../../../models/comentario.models';
import { Avaliacao } from '../../../models/avaliacao.models';

@Component({
  selector: 'app-filmes-cadastrar',
  templateUrl: './filmes-cadastrar.component.html',
  styleUrl: './filmes-cadastrar.component.css'
})
export class FilmesCadastrarComponent {
    filmeId? : number;
    titulo : string = "";
    genero : string = "";
    duracao : number = 0;
    horaDaConsulta? : string = "";
    comentarios?: Comentario[] = [];
    avaliacoes? : Avaliacao[] = [];
    constructor(private client: HttpClient, private router: Router){}

    cadastrar(): void {
      let filme: Filme = {
        id: this.filmeId,
        titulo: this.titulo,
        genero: this.genero,
        duracao: this.duracao,
        horaDaConsulta: this.horaDaConsulta,
        comentarios: this.comentarios,
        avaliacoes: this.avaliacoes

      };

      this.client.post<Filme>("https://localhost:7204/filme/cadastrar", filme).subscribe({
      //A requição funcionou
      next: (filme) => {
        this.router.navigate(["pages/filmes/filmes-listar"]);
      },
      //A requição não funcionou
      error: (erro) => {
        console.log(erro);
      },
    });
    }
}
