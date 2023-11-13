import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SimpleComponent } from './simple/simple.component';
import { DemoComponent } from './demo/demo.component';
import { FormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { EmpComponent } from './emp/emp.component';

@NgModule({
  declarations: [
    AppComponent,
    SimpleComponent,
    DemoComponent,
    RegisterComponent,
    EmpComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
