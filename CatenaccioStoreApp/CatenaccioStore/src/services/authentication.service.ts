import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Register } from '../app/models/register';
import { Observable,catchError,of, throwError } from 'rxjs';
import { environment } from '../environments/environment';

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

  public login(user: any): Observable<string> {
    return this.http.post(`${environment.apiUrl}/${this.loginUrl}`, user, { responseType: 'text' })
      .pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 500) {
            return throwError('Incorrect Email or Password');
          } 
          else {
            return throwError('An unexpected error occurred. Please try again later.');
          }
        })
      );
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
        const payload = JSON.parse(atob(jwtToken.split('.')[1]));
        return payload.userName || null;
      }
    }
    return null;
  }

  public getUserEmail(): string | null {
    if (isPlatformBrowser(this.platformId)) {
      const jwtToken = localStorage.getItem('jwtToken');
      if (jwtToken) {
        const payload = JSON.parse(atob(jwtToken.split('.')[1]));
        return payload.email || null;
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