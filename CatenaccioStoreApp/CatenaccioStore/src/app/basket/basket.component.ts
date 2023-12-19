import { Component } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import { RouterOutlet, RouterLink } from '@angular/router';
@Component({
  selector: 'app-basket',
  standalone: true,
  imports: [MatIconModule,RouterOutlet , RouterLink],
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css'
})
export class BasketComponent {
  quantity: number = 0;

  increment() {
    this.quantity++;
  }

  decrement() {
    if (this.quantity > 0) {
      this.quantity--;
    }
  }
}
