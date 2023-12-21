import { Component } from '@angular/core';
import { Register } from '../models/register';
import { Login } from '../models/login';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Jwt } from '../models/jwt';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.css'
})
export class AccountComponent {
  loginDto = new Login();
  registerDto = new Register();
  jwtDto = new Jwt();

  // constructor(private http: HttpClient){}

  // register(user : Register): Observable<Jwt>{
  //   return this.http.post<Jwt>(`${environment.apiUrl}/${this.registerUrl}`,user);
  //  }

  // login(user : Login): Observable<Jwt>{
  //   return this.http.post<Jwt>(`${environment.apiUrl}/${this.loginUrl}`,user);
  //  }

}
