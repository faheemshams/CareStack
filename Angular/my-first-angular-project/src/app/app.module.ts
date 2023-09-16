import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductContainerModule } from './product-container/product-container.module';
import { LoginPageComponent } from './login-page/login-page.component';
import { SignupPageComponent } from './signup-page/signup-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserAuthService } from './Services/userAuth.service';
import { RouterModule } from '@angular/router';
import { BookComponent } from './book/book.component';
import { AddRatingPipe } from './Pipes/Add-Rating.pipe';
import { HighlightTextDirective } from './Directives/HighlightText.directive';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    SignupPageComponent,
    BookComponent,
    AddRatingPipe,
    HighlightTextDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    AppRoutingModule,
    ProductContainerModule
  ],
  providers: [UserAuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
