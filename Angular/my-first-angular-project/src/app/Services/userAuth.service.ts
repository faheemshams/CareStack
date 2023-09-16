import { Injectable } from '@angular/core';
import { IGetUserDetails } from '../Interfaces/app.interface';

const USER_KEY = 'userData';

@Injectable()
export class UserAuthService {

  public userDetails! : IGetUserDetails;
  
  constructor() { }

  public getUserDetails():IGetUserDetails
  {
    const userData = localStorage.getItem(USER_KEY);
    this.userDetails = JSON.parse(userData as string);
    return this.userDetails;
  }

  public setUserDetails(userData : IGetUserDetails) : void
  {
    localStorage.setItem(USER_KEY, JSON.stringify(userData));
    this.userDetails = userData;
  }

  public validateUser(PassedUserData : Partial<IGetUserDetails>):boolean
  {
    this.getUserDetails();  
    return this.userDetails?.email === PassedUserData.email && this.userDetails?.password === PassedUserData.password;
  }
}
