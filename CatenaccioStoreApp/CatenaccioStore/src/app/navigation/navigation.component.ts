import { Component, HostListener } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';


@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.css'
})
export class NavigationComponent {
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
