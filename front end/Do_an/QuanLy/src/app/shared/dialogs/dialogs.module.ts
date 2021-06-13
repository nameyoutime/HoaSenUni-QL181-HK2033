import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateDialogComponent } from './create-dialog/create-dialog.component'
import { UpdateDialogComponent } from './update-dialog/update-dialog.component';


@NgModule({
  declarations: [CreateDialogComponent, UpdateDialogComponent],
  imports: [
    CommonModule
  ],
  exports:[CreateDialogComponent,UpdateDialogComponent]
})
export class DialogsModule { }
