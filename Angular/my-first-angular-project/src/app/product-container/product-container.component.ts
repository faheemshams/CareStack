import { Component } from '@angular/core';
import { ICategoryList, IOffer, IProductList } from './product-container.interface';
import { BookServiceService } from '../Services/book-service.service';
import { IBookDetails } from '../Interfaces/app.interface';

@Component({
  selector: 'app-product-container',
  templateUrl: './product-container.component.html',
  styleUrls: ['./product-container.component.scss'],
})
export class ProductContainerComponent 
{
  public products : Array<IProductList> = [];
  public Cart : Array<IProductList>= [];

  public categories : Array<ICategoryList>=[];
  public selectedCategories : Array<ICategoryList>=[];

  public offers : Array<IOffer>=[];
  public selectedOffers : Array<IOffer>=[];

  public bookList : Array<IBookDetails>=[];

  constructor(private readonly bookService: BookServiceService)
  {

  }

  public ngOnInit(): void 
  {
    this.products = [
     {id:1, label: 'Item 1', price:20},
     {id:2, label: 'Item 2', price:50},
     {id:3, label: 'Item 3', price:30},
     {id:4, label: 'Item 4', price:70}
    ];

    this.categories = [
      {CategoryId: 1, name:'Electronics'},
      {CategoryId: 2, name:'Home Appliances'},
      {CategoryId: 3, name:'Clothing'},
      {CategoryId: 4, name:'Cosmetics'},
      {CategoryId: 5, name:'Health'},
      {CategoryId: 6, name:'Fitness'}
    ]

    this.offers = [
      {OfferId: 1, OfferName:"A", OfferPercentage:10},
      {OfferId: 2, OfferName:"B", OfferPercentage:10},
      {OfferId: 3, OfferName:"C", OfferPercentage:10},
      {OfferId: 4, OfferName:"D", OfferPercentage:10},
      {OfferId: 5, OfferName:"E", OfferPercentage:10},
      {OfferId: 6, OfferName:"F", OfferPercentage:10},
    ]

    this.bookList =  this.bookService.getBook();
  }

  public addToCart(product : IProductList)
  {
    this.Cart.push(product);
  }

  public addToCategories(selectedCategories: Array<ICategoryList>)
  {
    this.selectedCategories = selectedCategories;
  }

  public addToOffers(selectedOffers : Array<IOffer>)
  {
    this.selectedOffers = this.selectedOffers;
  }
}
