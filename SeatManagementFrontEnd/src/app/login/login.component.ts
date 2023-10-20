import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators} from '@angular/forms';
import { Route, Router } from '@angular/router';
import { AuthServiceService } from '../Services/auth-service.service';
import { LoginService } from './login.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm : FormGroup;
  
  constructor(
    private fb : FormBuilder,
    private router:Router,
    private authService:AuthServiceService,
    private loginService:LoginService,
    private jwtHelper:JwtHelperService){
    this.loginForm = this.fb.group({
      username : ['', Validators.required],
      password : ['', Validators.required]
    });
  }
  
  ngOnInit(): void {
  }

  public Login()
  {
    if(this.loginForm.valid)
    {
      const user = {
        username : this.loginForm.value.username,
        password : this.loginForm.value.password
      }

      this.loginService.login(user).subscribe({
        next:(res:any) => {
          localStorage.setItem("jwt",res);
          console.log(res);
          this.router.navigate(['Home']);
          this.authService.isLoggedIn = true;
        },
        error:(err: HttpErrorResponse)=>{
          console.error("Error:", err);
        }
      })
    }
  }
}
