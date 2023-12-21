import { Component } from '@angular/core';
import { Register } from '../models/register';
import { Login } from '../models/login';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Jwt } from '../models/jwt';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.css'
})
export class AccountComponent {
  loginDto = new Login();
  registerDto = new Register();
  jwtDto = new Jwt();

  constructor(private _autheticationService: AuthenticationService){}

  register(registerDto: Register){
    this._autheticationService.register(registerDto).subscribe();
  }
  login(loginDto: Login){
    this._autheticationService.login(loginDto).subscribe(jwtDto => {
        localStorage.setItem('jwtToken',jwtDto.token);
    });
  }
}
