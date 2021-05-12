import { Component, Input, OnInit } from '@angular/core';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/firestore';
import { Observable } from 'rxjs';
import { Item } from '../models/Item-model';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.scss']
})
export class ItemsListComponent implements OnInit {
  // showModal:boolean;


  ngOnInit(): void {
  }
  data:any;
  items: Observable<Item[]>;
  private itemsCollection: AngularFirestoreCollection<Item>;
  
  //  items: Item[]=[];
  constructor(private afs: AngularFirestore,private modalService: NgbModal) {
    this.itemsCollection = this.afs.collection<Item>('items');
    this.items = this.itemsCollection.valueChanges();

    
  }

  open(item:Item) {
    // console.log(item);
    const modalRef = this.modalService.open(NgbdModalContent);
    modalRef.componentInstance.data = {
      name:"Update form",
      item:item
    }
  }

}


@Component({
  selector: 'ngbd-modal-content',
  template: `
    <div class="modal-header">
      <h4 class="modal-title">{{data.name}}</h4>
      <button type="button" class="btn-close" aria-label="Close" (click)="activeModal.dismiss('Cross click')">
        <span aria-hidden="true"></span>
      </button>
    </div>
    <div class="modal-body">
      <p>Hello, {{data.item.name}}!</p>
      <!-- <p>{{data.data.name}}</p> -->



    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-primary" (click)="activeModal.close('Close click')">Close</button>
    </div>
  `
})
export class NgbdModalContent {
  @Input() data;

  constructor(public activeModal: NgbActiveModal) {

  }
}