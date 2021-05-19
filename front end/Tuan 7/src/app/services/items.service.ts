import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  constructor() { 
    
  }

  checkEmpty(value: Array<any>) {
    // console.log(value);
    if (value.length == 0) {
      return true;
    } else {
      return false;
    }
  }

  
}
