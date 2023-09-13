import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './product-list/product-list.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { ProductContainerComponent } from './product-container.component';


@NgModule({
  declarations: [
    ProductListComponent,
    ProductContainerComponent,
    TopBarComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    ProductContainerComponent
  ]
  
})
export class ProductContainerModule { 


  
}

