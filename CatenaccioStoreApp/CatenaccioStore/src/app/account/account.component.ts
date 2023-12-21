import { Component } from '@angular/core';
import { Register } from '../models/register';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.css'
})
export class AccountComponent {
  registerDto = new Register();

  constructor(private _autheticationService: AuthenticationService){}

  register(registerDto: Register){
    this._autheticationService.register(registerDto).subscribe();
  }
 
}
