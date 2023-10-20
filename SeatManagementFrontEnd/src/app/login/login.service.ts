import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private _http : HttpClient) 
  {  }

  login(user : any)
  {
    return this._http.post('https://localhost:7225/api/login', user, {responseType : 'json'});
  }
  signup(user : any)
  {
    return this._http.post(`https://localhost:7225/api/signup`, user, { responseType: 'json' });
  }
}
