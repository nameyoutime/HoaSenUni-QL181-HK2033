import { Component, Input, OnInit } from '@angular/core';
import { Item } from 'src/app/models/item-models';
import { Tag } from 'src/app/models/tag-models';
import { TableService } from 'src/app/services/table.service';
import { MatDialog } from '@angular/material/dialog';
import { CreateDialogComponent } from '../../dialogs/create-dialog/create-dialog.component'
import {UpdateDialogComponent} from '../../dialogs/update-dialog/update-dialog.component'
@Component({
  selector: 'app-table-data',
  templateUrl: './table-data.component.html',
  styleUrls: ['./table-data.component.scss']
})
export class TableDataComponent implements OnInit {
  @Input() data;
  @Input() tagsData;
  collection: Item[];
  tags: Tag[]
  p: number = 1;
  numberOfItem: number = 10;
  selectedTag: number;
  val: string;

  constructor(private tableSer: TableService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.collection = this.data;
    this.tags = this.tagsData;
  }
  check(val) {
    if (val == null) {
      this.collection = this.data;
    } else {
      let data = this.tableSer.getDataByTag(val);
      if (data.length == 0) {
        console.log("empty");
        this.collection = data;
      } else {
        this.collection = data;
      }
    }
  }

  openCreateDialog() {
    this.dialog.open(CreateDialogComponent, {
      data: {
        animal: 'panda'
      }
    });
  }
  openUpdateDialog(){
    this.dialog.open(UpdateDialogComponent, {
      data: {
        animal: 'panda'
      }
    });
  }
  deleteItem(){
    console.log("delete")
  }
}
