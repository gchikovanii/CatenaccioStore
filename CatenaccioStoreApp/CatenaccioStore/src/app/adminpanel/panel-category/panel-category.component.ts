import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
@Component({
  selector: 'app-panel-category',
  standalone: true,
  imports: [RouterModule,MatIconModule,MatButtonModule],
  templateUrl: './panel-category.component.html',
  styleUrl: './panel-category.component.css'
})
export class PanelCategoryComponent {

}
