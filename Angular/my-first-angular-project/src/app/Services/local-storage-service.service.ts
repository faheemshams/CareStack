import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageServiceService 
{

  constructor() { }

  public storeData(data : any, key:string) : void
  {
      localStorage.setItem(key, JSON.stringify(data));
  }

  public getData(key:string) : any|null
  {
      return JSON.parse(localStorage.getItem(key) as string);
  }
}