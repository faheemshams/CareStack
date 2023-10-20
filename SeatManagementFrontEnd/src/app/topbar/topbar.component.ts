import { Component } from '@angular/core';
import { AuthServiceService } from '../Services/auth-service.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.scss']
})
export class TopbarComponent {
  constructor(public authService : AuthServiceService, private router : Router){
  }

  public Logout()
  {
    this.authService.isLoggedIn = false;
    console.log("logouy");
    this.router.navigate(['Login']);
  }
}
