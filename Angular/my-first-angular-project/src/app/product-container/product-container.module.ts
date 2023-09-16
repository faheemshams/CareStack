import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './product-list/product-list.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { ProductContainerComponent } from './product-container.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    ProductListComponent,
    ProductContainerComponent,
    TopBarComponent,
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports:[
    ProductContainerComponent
  ]
  
})
export class ProductContainerModule 
{ 


  
}

