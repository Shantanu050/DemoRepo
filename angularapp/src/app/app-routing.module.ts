import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DemoComponent } from './demo/demo.component';
import { EmpComponent } from './emp/emp.component';
import { SimpleComponent } from './simple/simple.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {path:'demo',component:DemoComponent},
  {path:'emp',component:EmpComponent},
  {path:'simple',component:SimpleComponent},
  {path:'register',component:RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
