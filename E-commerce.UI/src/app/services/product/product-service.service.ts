import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {
  productBaseUrl:string ='https://localhost:7052/api/Product/';
  constructor(private http:HttpClient) {

   }

   getAllProducts(){
    return this.http.get(this.productBaseUrl+'GetAllProduct');
   }

   GetProductFiltered(filter:any[]){
    return this.http.post(this.productBaseUrl+'GetByName',filter);
   }

   GetProductPagination(page:number,pageSize:number){
    return this.http.get(this.productBaseUrl+'GetPaginationProduct?page='+page+'&pageSize='+pageSize);
   }
}
