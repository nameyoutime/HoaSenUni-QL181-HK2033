import { Component } from '@angular/core';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/firestore';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  template: `
  <ul>
    <li *ngFor="let item of items | async">
    {{ item.name }}
    </li>
  </ul>
  `
})
export class AppComponent {
  title = 'firebase';

  private itemsCollection: AngularFirestoreCollection<any>;
  items: Observable<any[]>;
  //  items: Item[]=[];
  constructor(private readonly afs: AngularFirestore) {
    this.itemsCollection = afs.collection<any>('items');
    //this.items = this.itemsCollection.valueChanges();

    // .valueChanges() is simple. It just returns the 
    // JSON data without metadata. If you need the 
    // doc.id() in the value you must persist it your self
    // or use .snapshotChanges() instead. Only using for versions 7 and earlier



    this.items = this.itemsCollection.valueChanges();
    //chỉ sử dụng cho Angular 8,9
    //id1: ten field đại diện cho documnent id, lưu ý không 
    //được đặt trùng với tên field khai báo trong dữ liệu

  }
}
