import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatenteFormComponent } from './patente-form/patente-form.component';
import { PatenteListComponent } from './patente-list/patente-list.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    PatenteFormComponent,
    PatenteListComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PatenteModule { }
