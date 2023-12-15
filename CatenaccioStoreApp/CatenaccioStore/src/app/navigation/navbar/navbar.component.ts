import {Component,HostListener } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import { RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import {MatMenuModule} from '@angular/material/menu';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BreakpointObserver } from '@angular/cdk/layout';


@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [FlexLayoutModule,MatIconModule,MatButtonModule,MatToolbarModule,MatSidenavModule,RouterOutlet,CommonModule,RouterLink,MatMenuModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})

export class NavbarComponent {
  isSmallScreen: boolean = false;

  constructor(private breakpointObserver: BreakpointObserver) {
    this.checkScreenSize();
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.checkScreenSize();
  }

  private checkScreenSize() {
    this.isSmallScreen = this.breakpointObserver.isMatched('(max-width: 900px)');
  }
  openRegistration() {
    
  }

  openLogin() {
    // Implement logic to open the login form
  }

  openBasket() {
    // Implement logic to open the basket
  }
}
