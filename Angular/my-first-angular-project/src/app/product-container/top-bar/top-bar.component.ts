import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ICategoryList, IOffer } from '../product-container.interface';
import { BookServiceService } from 'src/app/Services/book-service.service';
import { IBookDetails } from 'src/app/Interfaces/app.interface';
import { LocalStorageServiceService } from 'src/app/Services/local-storage-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.scss']
})
export class TopBarComponent
{
     @Input() public categories : Array<ICategoryList> = [];
     @Input() public offers : Array<IOffer> = [];
     @Input() public books : Array<IBookDetails> = [];
     
     @Output() public selectedCategories : EventEmitter<Array<ICategoryList>> = new EventEmitter();
     @Output() public selectedOffers : EventEmitter<Array<IOffer>> = new EventEmitter();

     constructor(private readonly localStorageService : LocalStorageServiceService, private readonly router : Router)
     {

     }
     
     public tempCategoryList : Array<ICategoryList>=[];
     public tempOfferList : Array<IOffer>=[];

     public addToTempCategoryList(category : ICategoryList)
     {
      this.tempCategoryList.push(category);
     }

    public addToCategories()
    {
        this.selectedCategories.emit(this.tempCategoryList);
    }

    public addToTempOfferList(offer : IOffer)
    {
      this.tempOfferList.push(offer);
    }

    public addToOffers()
    {
       this.selectedOffers.emit(this.tempOfferList);
    }

    public editBook(book : IBookDetails)
    {
        void this.router.navigate(['book'],{queryParams:{id:book.id}});
    }
}


