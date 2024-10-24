import { Component, NgModule } from '@angular/core';
import { CartService } from '../../services/cart/cart.service';
import { CommonModule, CurrencyPipe, NgFor, NgIf } from '@angular/common';
import { Product } from '../../intefaces/Product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CurrencyPipe, NgFor, NgIf],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {

  cartItems: Product[] = [];
  cartTotal = 0;

  constructor(private cartService: CartService, private router: Router) { }
  ngOnInit(): void {
    this.loadCart();
    //  this.cartItems = localStorage.getItem('cart') ? JSON.parse(localStorage.getItem('cart') || '{}') : [];
  }

  loadCart(): void {
    this.cartItems = this.cartService.getCartItems();
    console.log(this.cartItems);
    this.calculateTotal();
    // localStorage.setItem('cart', JSON.stringify(this.cartItems));
  }

  removeItem(product: Product): void {
    this.cartService.removeFromCart(product);
    this.loadCart();
  }

  goToProducts() {
    this.router.navigate(['/product']);
  }

  increaseQuantity(item: Product) {
    item.quantity++;
    this.loadCart();
  }


  decreaseQuantity(item: Product) {
    if (item.quantity > 1) {
      item.quantity--;
      this.loadCart();
    }
  }

  clearCart(): void {
    this.cartService.clearCart();
    this.loadCart();
  }

  calculateTotal(): void {
    this.cartTotal = this.cartItems.reduce((sum, item) => sum + (item.price * item.quantity), 0);
  }

}
