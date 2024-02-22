import { Component } from '@angular/core';
import { ProductsService } from '../_services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {

  products: any[] = [];

  constructor(private productsService: ProductsService) {
  }

  showDetails(id: number) {
  }

  deleteProduct(id: number) {
    
  }
}
