import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { Item } from './models/Item-model';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr'
import { FirebaseService } from './services/firebase.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'firebase';
  inputValue: string;
  constructor(private modalService: NgbModal) { }
  open() {

    const modalRef = this.modalService.open(NgbdModalContent);
    modalRef.componentInstance.data = {
      name: "Create form",
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
    Name<input #Name type="text" class="form-control" placeholder=''/>
    Subtitle<input #Subtitle type="text" class="form-control" placeholder=''/>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-primary" (click)="onSubmit()">Create</button>
    </div>
  `
})

export class NgbdModalContent {
  @Input() data;
  public name: string;
  @ViewChild('Name') nameInput: ElementRef;
  @ViewChild('Subtitle') subtitleInput: ElementRef;
  constructor(public activeModal: NgbActiveModal, public toastService: ToastrService, private fire: FirebaseService) {

  }

  onSubmit() {
    let name = this.nameInput.nativeElement.value;
    let sub = this.subtitleInput.nativeElement.value;
    let data: Item = {
      name: name,
      subtitle: sub,
      dateCreated: Date.now()
    }
    if (name == "" || sub == "") {
      this.toastService.error("Name or subtitile is empty!", "error");
    } else {
      this.toastService.success(`Success create ${name}`);
      this.fire.addItems(data);
      this.activeModal.close('Close click');
    }
    // console.log('player name: ', this.nameInput.nativeElement.value);
  }
}
