import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { FilmesListarComponent } from "./pages/filmes/filmes-listar/filmes-listar.component";
import { FilmesCadastrarComponent } from "./pages/filmes/filmes-cadastrar/filmes-cadastrar.component";

const routes: Routes = [
  {
    path: "",
    component: FilmesListarComponent,
  },
  {
    path: "pages/filmes/filmes-listar",
    component: FilmesListarComponent,
  },
  {
    path: "pages/filmes/filmes-cadastrar",
    component: FilmesCadastrarComponent,
  }
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
  })
  export class AppRoutingModule {}