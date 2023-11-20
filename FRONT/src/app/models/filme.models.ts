import { Avaliacao } from "./avaliacao.models";
import { Comentario } from "./comentario.models";

export interface Filme {
    id? : number;
    titulo : string;
    genero : string;
    duracao: number;
    horaDaConsulta?: string;
    comentarios?: Comentario[];
    avaliacoes? : Avaliacao[];
  }