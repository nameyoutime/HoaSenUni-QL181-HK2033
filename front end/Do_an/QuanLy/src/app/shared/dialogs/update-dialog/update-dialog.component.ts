import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Item } from 'src/app/models/item-models';
import { Tag } from 'src/app/models/tag-models';
import { TableService } from 'src/app/services/table.service';

@Component({
  selector: 'app-update-dialog',
  templateUrl: './update-dialog.component.html',
  styleUrls: ['./update-dialog.component.scss']
})
export class UpdateDialogComponent implements OnInit {
  // selectedTag: number;
  // tags: Tag[];
  
  constructor(@Inject(MAT_DIALOG_DATA) public data: Item,private tableSer:TableService) {
    // this.tags = this.tags = this.tableSer.getTag();
  }

  ngOnInit(): void {
    // console.log(this.data);
  }

}
