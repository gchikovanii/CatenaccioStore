import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
@Component({
  selector: 'app-panel-products',
  standalone: true,
  imports: [RouterModule,MatIconModule,MatButtonModule],
  templateUrl: './panel-products.component.html',
  styleUrl: './panel-products.component.css'
})
export class PanelProductsComponent {

}
