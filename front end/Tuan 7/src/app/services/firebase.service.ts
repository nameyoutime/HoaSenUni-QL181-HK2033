import { Injectable } from '@angular/core';
import { AngularFirestore } from '@angular/fire/firestore';
import { Item } from '../models/Item-model';

@Injectable({
  providedIn: 'root'
})
export class FirebaseService {

  constructor(private afs: AngularFirestore) { }



  addItems(value:Item){
    let data:Item = {
      id:this.afs.createId(),
      name:value.name,
      subtitle:value.subtitle
    }
    this.afs.collection("items").doc(data.id).set(data);
  }

  deleteItem(id){
    this.afs.collection("items").doc(id).delete();
  }

  updateItem(value:Item){

    this.afs.collection("items").doc(value.id).update(value);
  }
}
