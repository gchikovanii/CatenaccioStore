import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Register } from './models/register';
import { Login } from './models/login';
import { Observable,of } from 'rxjs';
import { environment } from '../environments/environment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  registerUrl = 'Account/Registration';
  loginUrl = 'Account/Login';

  constructor(
    private http: HttpClient,
    @Inject(PLATFORM_ID) private platformId: any
  ) {}

  public register(user: Register): Observable<boolean> {
    console.log('Registration Request Payload:', user);
    return this.http.post<boolean>(`${environment.apiUrl}/${this.registerUrl}`, user);
  }

  public login(user: Login): Observable<string> {
    return this.http.post(`${environment.apiUrl}/${this.loginUrl}`, user, { responseType: 'text' });
  }

  public isAuthenticated(): boolean {
    if (isPlatformBrowser(this.platformId)) {
      const jwtToken = localStorage.getItem('jwtToken');
      return !!jwtToken;
    }
    return false;
  }

  public getUserNameFromToken(): string | null {
    if (isPlatformBrowser(this.platformId)) {
      const jwtToken = localStorage.getItem('jwtToken');
      if (jwtToken) {
        // Decode the JWT token to get the payload
        const payload = JSON.parse(atob(jwtToken.split('.')[1]));

        // Assuming the userName is present in the payload
        return payload.userName || null;
      }
    }
    return null;
  }
  getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }
  public getRole(): string | null {
    const token = this.getToken();
    if (token) {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload.role || null;
    }
    return null;
  }
  public IsAdmin(): Observable<boolean> {
    const jwtToken = localStorage.getItem('jwtToken');
    if (jwtToken) {
      const payload = JSON.parse(atob(jwtToken.split('.')[1]));
      return of(payload.role === 'Admin');
    }
    return of(false);
  }
  public logout(): void {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem('jwtToken');
    }
  }
}