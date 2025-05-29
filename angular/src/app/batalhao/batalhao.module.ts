import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BatalhaoFormComponent } from './batalhao-form/batalhao-form.component';
import { BatalhaoListComponent } from './batalhao-list/batalhao-list.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    BatalhaoFormComponent,
    BatalhaoListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ]
})
export class BatalhaoModule { }
