import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-adminpanel',
  templateUrl: './adminpanel.component.html',
  styleUrl: './adminpanel.component.css'
})
export class AdminpanelComponent implements OnInit {

  constructor(private authService: AuthenticationService) {}
  ngOnInit(): void {
   
  }

  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  
}
