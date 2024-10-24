import { Component, Input, input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CartService } from '../../../services/cart/cart.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  cartItemCount: number = 0;

  constructor(private cartService: CartService) {

  }
  ngOnInit() {
    this.updateCartCount();
  }

  // Update the cart count dynamically
  updateCartCount() {
    this.cartService.cartItemCount$.subscribe(count => {
      this.cartItemCount = count;
    });
  }
}
