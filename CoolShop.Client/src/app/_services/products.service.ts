import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) { }

  getProducts() {

  }

  getProduct(id: number) {

  }

  deleteProduct(id: number){

  }

  updateProduct(model: any) {}

  createProduct(model: any) {}


}
