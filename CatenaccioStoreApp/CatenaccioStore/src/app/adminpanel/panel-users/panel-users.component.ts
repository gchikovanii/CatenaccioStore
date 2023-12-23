import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { AuthenticationService } from '../../../services/authentication.service';

@Component({
  selector: 'app-panel-users',
  templateUrl: './panel-users.component.html',
  styleUrl: './panel-users.component.css'
})
export class PanelUsersComponent implements OnInit{
  users: any[] = [];

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userService.getUsers().subscribe((data) => {
      this.users = data;
    });
  }

  deleteUser(emailToDelete: string): void {
    this.userService.deleteUser(emailToDelete).subscribe(
      (response) => {
        console.log('User deleted successfully:', response);
      },
      (error) => {
        console.error('Error deleting user:', error);
      }
    );
  }


}
