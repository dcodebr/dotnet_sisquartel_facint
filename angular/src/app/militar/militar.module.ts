import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MilitarFormComponent } from './militar-form/militar-form.component';
import { MilitarListComponent } from './militar-list/militar-list.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    MilitarFormComponent,
    MilitarListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ]
})
export class MilitarModule { }
