import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarteiraComponent } from './carteira/carteira.component';
import { HttpClientModule } from "@angular/common/http";
import { RouterModule, Routes } from "@angular/router";
import { CarteiraService } from './carteira/carteira.service';

@NgModule({
  declarations: [
    AppComponent,
    CarteiraComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
   
  ],
  providers: [CarteiraService],
  bootstrap: [AppComponent]
})
export class AppModule { }
