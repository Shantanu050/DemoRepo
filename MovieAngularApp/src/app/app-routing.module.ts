import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListmovieComponent } from './listmovie/listmovie.component';
import { FindmovieComponent } from './findmovie/findmovie.component';
import { AddmovieComponent } from './addmovie/addmovie.component';
import { EditmovieComponent } from './editmovie/editmovie.component';
import { DeletemovieComponent } from './deletemovie/deletemovie.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ReactiveformComponent } from './reactiveform/reactiveform.component';
import { CreatedetailsComponent } from './createdetails/createdetails.component';
import { AuthGuard } from './guard/auth.guard';
import { AuthService } from './services/auth.service';

const routes: Routes = [
  {path:'listmovies',component:ListmovieComponent,canActivate:[AuthGuard]},
  {path:'find/:id',component:FindmovieComponent},
  {path:'add',component:AddmovieComponent},
  {path:'edit/:id',component:EditmovieComponent},
  {path:'delete/:id',component:DeletemovieComponent},
  {path:'reactForm',component:ReactiveformComponent},
  {path:'details',component:CreatedetailsComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
