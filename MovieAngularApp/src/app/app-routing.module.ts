import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListmovieComponent } from './listmovie/listmovie.component';
import { FindmovieComponent } from './findmovie/findmovie.component';


const routes: Routes = [
  {path:'listmovies',component:ListmovieComponent},
  {path:'find/:id',component:FindmovieComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
