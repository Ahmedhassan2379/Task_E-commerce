import { Injectable } from '@angular/core';
import { Product } from '../../intefaces/Product';
import { BehaviorSubject, Subject, throwIfEmpty } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private cartItemCount = new BehaviorSubject<number>(0); // Initialize count
  cartItemCount$ = this.cartItemCount.asObservable();

  private cartItems: any[] = [];

  addToCart(item: any) {
    this.cartItems.push(item);
    // localStorage.setItem('cart', JSON.stringify(this.cartItems));
    this.updateCartCount();
  }

  removeFromCart(item: any) {
    let index = this.cartItems.indexOf(item);
    console.log(index);
    this.cartItems.splice(index, 1)
    this.updateCartCount();   

  }

  updateCartCount() {
    this.cartItemCount.next(this.cartItems.length);
  }
  cartKey: string = 'cart';

  constructor() {
    // this.updateCartCount();
  }

  private isLocalStorageAvailable(): boolean {
    return typeof window !== 'undefined' && typeof window.localStorage !== 'undefined';
  }
  getCartItems(): any {
    return this.cartItems;
  }

  clearCart(): void {
    this.cartItems = [];
    // localStorage.removeItem(this.cartKey);
    this.updateCartCount();
  }
}
