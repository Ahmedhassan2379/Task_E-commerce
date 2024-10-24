import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoryServiceService {

  CategoryBaseUrl:string ='https://localhost:7052/api/Category/';
  constructor(private http:HttpClient) { }
  getAllCategories(){
    return this.http.get(this.CategoryBaseUrl+'GetAllCategories');
   }
}

