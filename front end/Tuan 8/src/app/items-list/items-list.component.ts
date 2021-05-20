import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/firestore';
import { Observable } from 'rxjs';
import { Item } from '../models/Item-model';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FirebaseService } from '../services/firebase.service';
import { ToastrService } from 'ngx-toastr';
import { ItemsService } from '../services/items.service';
@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.scss']
})
export class ItemsListComponent implements OnInit {
  // showModal:boolean;
  currentPage: number = 1;
  itemsPerPage: number = 5;
  data: any;
  items = this.fire.items;
  ngOnInit(): void {
    
  }


  constructor(private toast: ToastrService, private modalService: NgbModal, private fire: FirebaseService) {
    

  }


  test() {
    // console.log(this.isEmpty);
  }
  open(item: Item) {
    // console.log(item);
    const modalRef = this.modalService.open(NgbdModalContent);
    modalRef.componentInstance.data = {
      name: "Update form",
      item: item
    }
    modalRef.result.then(() => {
      // console.log('When user closes');
      // this.checkEmpty(this.itemsData);
    }, () => {
      // console.log('Backdrop click');
    })

  }
  del(id) {
    try {
      this.fire.deleteItem(id);
      // this.checkEmpty(this.itemsData);
      this.toast.success("Susscess delete item!");
    } catch (error) {
      this.toast.error("Can't delete item!");
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
      Name<input #Name type="text" class="form-control" placeholder='' [value]='this.data.item.name'/>
      Subtitle<input #Subtitle type="text" class="form-control" placeholder='' [value]='this.data.item.subtitle'/>


    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-primary" (click)="update()">Save</button>
    </div>
  `
})
export class NgbdModalContent {
  @Input() data;
  @ViewChild('Name') nameInput: ElementRef;
  @ViewChild('Subtitle') subtitleInput: ElementRef;
  constructor(
    public activeModal: NgbActiveModal,
    private fire: FirebaseService,
    private toast: ToastrService) { }

  update() {
    let name = this.nameInput.nativeElement.value;
    let sub = this.subtitleInput.nativeElement.value;
    let data: Item = {
      id: this.data.item.id,
      name: name,
      subtitle: sub
    }
    try {
      this.fire.updateItem(data);
      this.activeModal.close('Close click');
      this.toast.success("Success update item!");
    } catch (error) {
      this.activeModal.close('Close click');
      this.toast.error("Can't update item!");
    }

  }

}