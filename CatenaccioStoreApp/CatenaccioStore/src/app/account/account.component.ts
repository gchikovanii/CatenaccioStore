import { Component } from '@angular/core';
import { Register } from '../models/register';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar'; 


@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.css'
})
export class AccountComponent {
  registerDto = new Register();

  constructor(private _autheticationService: AuthenticationService, private router: Router,private snackBar: MatSnackBar){}

  register(registerDto: Register) {
    this._autheticationService.register(registerDto).subscribe(
      () => {
        // Registration successful
        this.openSnackBar('Registration successful!', 'Success');
        this.router.navigate(['/login']);
      },
      (error) => {
        // Handle registration error
        if ((error.status === 500  && error.error === 'already_exists') || error.status == 400) {
          this.openSnackBar('User with the same credentials already exists.', 'Error');
        } else {
          this.openSnackBar('Registration failed. Please try again later.', 'Error');
        }
      }
    );
  }

  // Helper method to open a snackbar
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 3000,  // Set the duration for the snackbar
    });
  }
 
}
