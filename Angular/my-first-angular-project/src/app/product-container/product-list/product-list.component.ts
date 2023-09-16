import { Component,EventEmitter,Input, Output } from '@angular/core';
import { IProductList } from '../product-container.interface';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent 
{

  @Input() public products : Array<IProductList> = [];
  @Output() public Cart : EventEmitter<any> = new EventEmitter();

  public addToCart(product : IProductList)
  {
    
    this.Cart.emit(product);
  }
}
