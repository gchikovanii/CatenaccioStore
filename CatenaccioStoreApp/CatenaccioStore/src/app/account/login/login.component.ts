import { Component } from '@angular/core';
import { Login } from '../../models/login';
import { AuthenticationService } from '../../authentication.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginDto = new Login();

  constructor(private _autheticationService: AuthenticationService, private router : Router){}
  login(loginDto: Login){
    this._autheticationService.login(loginDto).subscribe(jwtDto => {
        localStorage.setItem('jwtToken', jwtDto);
        this.router.navigate(['/']);
    });
  }
}
