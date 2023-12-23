import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private userUrl = 'Account';
  private deleteUserUrl = 'Account/Delete';
  constructor(private http: HttpClient, private authService: AuthenticationService ) {}

  getUsers(): Observable<any[]> {
    return this.http.get<any[]>(`${environment.apiUrl}/${this.userUrl}`);
  }
  deleteUser(email: string): Observable<any> {
    const options = { params: { email: email } };
    return this.http.delete(`${environment.apiUrl}/${this.deleteUserUrl}`, options);
  }
}
