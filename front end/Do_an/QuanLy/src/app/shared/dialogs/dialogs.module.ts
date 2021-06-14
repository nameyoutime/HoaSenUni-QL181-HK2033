import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UpdateDialogComponent } from './update-dialog/update-dialog.component';
import { MaterialModule } from '../material/material.module';
import { TagDialogComponent } from './tag-dialog/tag-dialog.component'

@NgModule({
  declarations: [UpdateDialogComponent, TagDialogComponent],
  imports: [
    CommonModule,
    MaterialModule,
  ],
  exports: [UpdateDialogComponent,TagDialogComponent]
})
export class DialogsModule { }
