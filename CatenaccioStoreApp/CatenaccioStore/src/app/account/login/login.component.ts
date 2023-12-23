import { Component } from '@angular/core';
import { Login } from '../../models/login';
import { AuthenticationService } from '../../../services/authentication.service';
import {  Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginDto = new Login();
  errorMessage: string | null = null;

  constructor(private _autheticationService: AuthenticationService, private router : Router){}
  login(loginDto: Login): void {
    this.errorMessage = null;
    this._autheticationService.login(loginDto).subscribe(
      jwtDto => {
        localStorage.setItem('jwtToken', jwtDto);
        this.router.navigate(['/']);
      },
      error => {
        this.errorMessage = error; 
      }
    );
  }
}
