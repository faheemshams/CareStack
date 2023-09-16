import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupPageComponent } from './signup-page/signup-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { ProductContainerComponent } from './product-container/product-container.component';
import { BookComponent } from './book/book.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/login', 
    pathMatch: 'full' 
  },
  {
    path:'signup',
    component : SignupPageComponent
  },
  {
  path:'login',
  component : LoginPageComponent
},
{
  path:'product',
  component : ProductContainerComponent
},
{
  path:'book',
  component : BookComponent
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }