import { Component } from '@angular/core';
import { Login } from '../../models/login';
import { AuthenticationService } from '../../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginDto = new Login();

  constructor(private _autheticationService: AuthenticationService){}
  login(loginDto: Login){
    this._autheticationService.login(loginDto).subscribe(jwtDto => {
        localStorage.setItem('jwtToken', jwtDto);
    });
  }
}
