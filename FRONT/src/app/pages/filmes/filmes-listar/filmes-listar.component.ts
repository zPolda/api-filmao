import { Component } from '@angular/core';
import { Filme } from '../../../models/filme.models';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-filmes-listar',
  templateUrl: './filmes-listar.component.html',
  styleUrl: './filmes-listar.component.css'
})
export class FilmesListarComponent {
  filmes :  Filme[] = []
  mostrarMaisInformacoes: boolean[] = [];
  mostrarMaisAvaliacoes: boolean[] = [];


  constructor(
    private client: HttpClient,
    private snackBar: MatSnackBar,
    private router: Router){}

    ngOnInit() : void{
      console.log("O componente foi carregado!");
  
      this.client.get<Filme[]>("https://localhost:7204/filme")
        .subscribe({
          //Requisição com sucesso
          next: (filmes) => {
            this.filmes = filmes;
            console.table(filmes);
          }, 
          //Requisição com erro
          error: (erro) => {
            console.log(erro);
          }
        })
    }
    calcularMediaAvaliacoes(filme: Filme): number {
      if (!filme.avaliacoes || filme.avaliacoes.length === 0) {
        return 0; // Retorna 0 se não houver avaliações
      }
  
      const somaNotas = filme.avaliacoes.reduce((total, avaliacao) => total + avaliacao.nota, 0);
      const media = somaNotas / filme.avaliacoes.length;
  
      return media;
    }


    toggleMaisInformacoes(index: number): void {
      console.log('Toggle informações para o índice:', index);
      this.mostrarMaisInformacoes[index] = !this.mostrarMaisInformacoes[index];
      console.log('Estado atual de mostrarMaisInformacoes:', this.mostrarMaisInformacoes);
    }
    toggleMaisAvaliacoes(index: number): void {
      this.mostrarMaisAvaliacoes[index] = !this.mostrarMaisAvaliacoes[index];
    }

    deletar(id?: number) {
      this.client
        .delete<Filme[]>(
          `https://localhost:7204/filme/${id}`
        )
        .subscribe({
          //Requisição com sucesso
          next: (filmes) => {
            this.filmes = filmes;
            this.snackBar.open(
              "Filme deletado com sucesso!!",
              "Filmao",
              {
                duration: 1500,
                horizontalPosition: "right",
                verticalPosition: "top",
              }
            );
            this.router.navigate([""]);
          },
          //Requisição com erro
          error: (erro) => {
            console.log(erro);
          },
        });
    }
    
}
