import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CidadeModule } from './cidade/cidade.module';
import { HttpClientModule } from '@angular/common/http';
import { PessoaModule } from './pessoa/pessoa.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CidadeModule,
    PessoaModule,
    HttpClientModule,


  ],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
