import { Component } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-panel-users',
  standalone: true,
  imports: [MatIconModule,MatButtonModule,RouterModule],
  templateUrl: './panel-users.component.html',
  styleUrl: './panel-users.component.css'
})
export class PanelUsersComponent {

}
