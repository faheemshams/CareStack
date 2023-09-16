import { Injectable } from '@angular/core';
import { IBookDetails } from '../Interfaces/app.interface';
import { LocalStorageServiceService } from './local-storage-service.service';

const Key = 'Book';

@Injectable({
  providedIn: 'root'
})
export class BookServiceService 
{

  constructor(private localStorageService : LocalStorageServiceService) { }

  public bookList! : Array<IBookDetails>;

  public storeBook(book : IBookDetails)
  {  
      this.bookList = this.localStorageService.getData(Key) || [];
      this.bookList.push(book);
      this.localStorageService.storeData(this.bookList, Key);
  }

  public getBook()
  {
     return this.localStorageService.getData(Key);
  } 

  public getBookById(id : string) : any|null
  {
    this.bookList = this.getBook();
    if(this.bookList && Array.isArray(this.bookList)) 
    return this.bookList.find((item: any) => item.id === id) || null;

    return null;
  }
}