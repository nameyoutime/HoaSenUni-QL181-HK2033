import { Injectable } from '@angular/core';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/firestore';
import { Observable } from 'rxjs';
import { Item } from '../models/Item-model';
import { ItemsService } from './items.service';

@Injectable({
  providedIn: 'root'
})
export class FirebaseService {
  items: Observable<Item[]>;
  public itemsData: Item[];
  private itemsCollection: AngularFirestoreCollection<Item>;
  isEmpty: boolean = false;
  constructor(private afs: AngularFirestore,private itemSer:ItemsService) {
    this.itemsCollection = this.afs.collection<Item>('items', ref => ref.orderBy('dateCreated', 'asc'));
    this.items = this.itemsCollection.valueChanges();
    this.items.subscribe(data => {
      this.isEmpty = this.itemSer.checkEmpty(data);
      this.itemsData = data;
      
    })
  }



  addItems(value: Item) {
    let data: Item = {
      id: this.afs.createId(),
      ...value
    }
    this.afs.collection("items").doc(data.id).set(data);
  }

  deleteItem(id) {
    this.afs.collection("items").doc(id).delete();
  }

  updateItem(value: Item) {
    this.afs.collection("items").doc(value.id).update(value);
  }
}
