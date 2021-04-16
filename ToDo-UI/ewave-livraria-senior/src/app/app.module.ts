import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app.routing.module';
import { HomeModule } from './home/home.module';
import { CoreModule } from './core/core.module';
import { LivrariaModule } from './livraria/livraria.module';
import { ErrorsModule } from './erros/erros.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HomeModule,
    AppRoutingModule,
    CoreModule,
    HttpClientModule,
    LivrariaModule,
    ErrorsModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
