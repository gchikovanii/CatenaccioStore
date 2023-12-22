import { Component, HostListener, OnInit } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.css'
})
export class NavigationComponent implements OnInit {
  isSmallScreen: boolean = false;
  userName: string | null = null;
  show: boolean = false;
  constructor(private breakpointObserver: BreakpointObserver,private authService: AuthenticationService,private router: Router) {
    this.checkScreenSize();
  }

  ngOnInit(): void {
    this.userName = this.authService.getUserNameFromToken();
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.checkScreenSize();
  }

  private checkScreenSize() {
    this.isSmallScreen = this.breakpointObserver.isMatched('(max-width: 900px)');
  }
 isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
  IsAdmin(): boolean {
    this.show = this.authService.IsAdmin();
    if(this.show == true)
      return true;
    return false;
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
