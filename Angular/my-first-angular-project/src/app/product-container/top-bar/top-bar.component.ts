import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ICategoryList, IOffer } from '../product-container.interface';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.scss']
})
export class TopBarComponent
{
     @Input() public categories : Array<ICategoryList> = [];
     @Input() public offers : Array<IOffer> = [];
     
     @Output() public selectedCategories : EventEmitter<Array<ICategoryList>> = new EventEmitter();
     @Output() public selectedOffers : EventEmitter<Array<IOffer>> = new EventEmitter();
     
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
}




