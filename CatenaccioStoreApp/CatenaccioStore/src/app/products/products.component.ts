import { Component } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatPaginatorModule} from '@angular/material/paginator';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [MatIconModule,MatFormFieldModule,MatPaginatorModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
 
}
