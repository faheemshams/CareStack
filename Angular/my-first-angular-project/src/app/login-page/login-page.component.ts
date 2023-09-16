import { Component, OnInit, inject } from '@angular/core';
import { IGetUserDetails } from '../Interfaces/app.interface';
import { Router } from '@angular/router';
import { UserAuthService } from '../Services/userAuth.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  public form!: Partial<IGetUserDetails>;
  public error : boolean =  false;

  constructor(private router: Router, private readonly userAuth : UserAuthService)
  {

  }

  public ngOnInit(): void {
    this.form = 
    {
      email: '',
      password : ''
    }
  }

  public onSubmit():void
  {
    const isUserValid = this.userAuth.validateUser(this.form);
    if(isUserValid)
    {
      this.error = false;
      void this.router.navigate(['book']);
    }
    else
    this.error = true;
  }

  public onSignUp() : void
  {
    void this.router.navigate(['signup']);
  }
}
