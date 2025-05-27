import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatenteListComponent } from './patente-list/patente-list.component';
import { PatenteFormComponent } from './patente-form/patente-form.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    PatenteListComponent,
    PatenteFormComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ]
})
export class PatenteModule { }
