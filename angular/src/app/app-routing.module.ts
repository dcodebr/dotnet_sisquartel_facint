import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatenteListComponent } from './patente/patente-list/patente-list.component';
import { PatenteFormComponent } from './patente/patente-form/patente-form.component';
import { BatalhaoListComponent } from './batalhao/batalhao-list/batalhao-list.component';
import { BatalhaoFormComponent } from './batalhao/batalhao-form/batalhao-form.component';
import { MilitarListComponent } from './militar/militar-list/militar-list.component';
import { MilitarFormComponent } from './militar/militar-form/militar-form.component';

const routes: Routes = [{
  path: 'patentes',
  children: [
    { path: '', component: PatenteListComponent },
    { path: 'incluir', component: PatenteFormComponent },
    { path: ':id', component: PatenteFormComponent }
  ]
}, {
  path: 'batalhoes',
  children: [
    { path: '', component: BatalhaoListComponent },
    { path: 'incluir', component: BatalhaoFormComponent },
    { path: ':id', component: BatalhaoFormComponent }
  ]
}, {
  path: 'militares',
  children: [
    { path: '', component: MilitarListComponent },
    { path: 'incluir', component: MilitarFormComponent },
    { path: ':id', component: MilitarFormComponent }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
