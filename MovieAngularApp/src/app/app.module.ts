import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { ListmovieComponent } from './listmovie/listmovie.component';
import { FindmovieComponent } from './findmovie/findmovie.component';
import { MenuComponent } from './menu/menu.component';
import { AddmovieComponent } from './addmovie/addmovie.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditmovieComponent } from './editmovie/editmovie.component';
@NgModule({
  declarations: [
    AppComponent,
    ListmovieComponent,
    FindmovieComponent,
    MenuComponent,
    AddmovieComponent,
    EditmovieComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
