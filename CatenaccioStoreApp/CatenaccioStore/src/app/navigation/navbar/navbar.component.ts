import {Component} from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import { RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatIconModule,MatButtonModule,MatToolbarModule,MatSidenavModule,RouterOutlet,CommonModule,RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})

export class NavbarComponent {
  toggleSidenav() {
    
  }

  openRegistration() {
    // Implement logic to open the registration form
  }

  openLogin() {
    // Implement logic to open the login form
  }

  openBasket() {
    // Implement logic to open the basket
  }
}
