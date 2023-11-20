
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatDividerModule} from '@angular/material/divider';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { FilmesListarComponent } from './pages/filmes/filmes-listar/filmes-listar.component';
import { ComentarioListarComponent } from './pages/comentario/comentario-listar/comentario-listar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FilmesCadastrarComponent } from './pages/filmes/filmes-cadastrar/filmes-cadastrar.component';
import { FormsModule } from '@angular/forms';
import { MatSnackBarModule } from "@angular/material/snack-bar";

@NgModule({
    declarations: [
      AppComponent,
      FilmesListarComponent,
      ComentarioListarComponent,
      FilmesCadastrarComponent
    ],
    imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      BrowserAnimationsModule,
      MatCardModule,
      MatDividerModule,
      MatButtonModule,
      MatProgressBarModule,
      MatToolbarModule,
      MatIconModule,
      MatSidenavModule,
      MatListModule,
      FormsModule,
      MatSnackBarModule,

    ],
    providers: [],
    bootstrap: [AppComponent]
  })
  export class AppModule {}