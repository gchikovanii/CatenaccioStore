import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Register } from './models/register';
import { Login } from './models/login';
import { Observable } from 'rxjs';
import { Jwt } from './models/jwt';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  registerUrl = 'Account/Register';
  loginUrl = 'Account/Login';

  constructor(private http: HttpClient) { }

  public register(user: Register) : Observable<Jwt>{
    return this.http.post<Jwt>(`${environment.apiUrl}/${this.registerUrl}`,user);
  }
  public login(user: Login) : Observable<Jwt>{
    return this.http.post<Jwt>(`${environment.apiUrl}/${this.loginUrl}`,user);
  }
}
