import { Component } from '@angular/core';
import { ProductServiceService } from '../../services/product/product-service.service';
import { NgFor } from '@angular/common';
import { CategoryServiceService } from '../../services/category/category-service.service';
import { PaginationComponent } from '../shared/pagination/pagination.component';
import { CartService } from '../../services/cart/cart.service';
import { Product } from '../../intefaces/Product';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [NgFor,PaginationComponent],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {

  cartItemCount : number = 0;
  products:Product[] = []
  categories:any = []
  filterArry:any[] = []
  currentPage = 1;
  pageSize = 5;
  totalPages = 0;

  constructor(private productService:ProductServiceService,
    private categoryService:CategoryServiceService,
    private cartService:CartService) {}

  ngOnInit(){
    this.getCategories();
    this.getProducts();
  }

  getProducts(){
    debugger;
    this.productService.getAllProducts().subscribe((response: Object) => {
      console.log(response);
      this.products = response as Product[];
      this.totalPages = Math.ceil(this.products.length / this.pageSize);
    })
  }

  getCategories(){
    debugger;
    this.categoryService.getAllCategories().subscribe((response: Object) => {
      this.categories = response
    })
  }

  filterProducts(categoryName:string){
    debugger
    const index = this.filterArry.indexOf(categoryName);
    if(index === -1){
      this.filterArry.push(categoryName)
    }
    else{
      this.filterArry.splice(index,1);
    }
    this.productService.GetProductFiltered(this.filterArry).subscribe((response: Object) => {
      this.products = response as Product[];
    })
  }

  onPageChange(newPage: number): void {
    this.currentPage = newPage;
    this.totalPages = Math.ceil(this.products.length / this.pageSize);
    this.productService.GetProductPagination(this.currentPage,this.pageSize).subscribe((response: Object) => {
      this.products = response as Product[];
    })
  }

  addToCart(product: Product): void {
    this.cartService.addToCart(product);
    alert(`${product.name} has been added to the cart.`);
  }
}
