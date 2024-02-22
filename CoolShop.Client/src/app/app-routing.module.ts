import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { EditUserComponent } from './edit-user/edit-user.component';
import { ProductsComponent } from './products/products.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { CreateProductComponent } from './create-product/create-product.component';

const routes: Routes = [
  { path:'', component: HomeComponent },
  { path:'users', component: UsersComponent },
  { path:'user/:id', component: EditUserComponent },
  { path:'products', component: ProductsComponent },
  { path:'product/:id', component: EditProductComponent },
  { path:'product/create', component: CreateProductComponent },
  { path:'**', component: HomeComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
