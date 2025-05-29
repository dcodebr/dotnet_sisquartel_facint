import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatenteListComponent } from './patente/patente-list/patente-list.component';
import { PatenteFormComponent } from './patente/patente-form/patente-form.component';


//https://localhost:4200/patentes -> listar
//https://localhost:4200/patentes/incluir -> add
//https://localhost:4200/patentes/10 -> editar

const routes: Routes = [{
  path: 'patentes',
  children: [
    { path: '', component: PatenteListComponent, },
    { path: 'incluir', component: PatenteFormComponent },
    { path: ':id', component: PatenteFormComponent },
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
