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
  registerUrl = 'Account/Registration';
  loginUrl = 'Account/Login';

  constructor(private http: HttpClient) { }

  public register(user: Register): Observable<boolean> {
    console.log('Registration Request Payload:', user);
    return this.http.post<boolean>(`${environment.apiUrl}/${this.registerUrl}`, user);
  }
  public login(user: Login): Observable<string> {
    return this.http.post(`${environment.apiUrl}/${this.loginUrl}`, user, { responseType: 'text' });
  }
}
