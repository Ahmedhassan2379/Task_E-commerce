import { Routes } from '@angular/router';
import { ProductComponent } from './components/product/product.component';
import { CartComponent } from './components/cart/cart.component';

export const routes: Routes = [
    { path: '', component: ProductComponent },
    { path: 'product', component: ProductComponent },
    { path: 'cart', component: CartComponent }
];
