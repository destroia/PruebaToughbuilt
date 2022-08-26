import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PruductComponent } from '../app/ViewsHome/pruduct/pruduct.component';
import { CategoryComponent } from './ViewsHome/category/category.component';
import { CrudProductComponent } from './ViewsHome/crud-product/crud-product.component';
import { DetailsComponent } from './ViewsHome/details/details.component';
const routes: Routes = [
  { path: "", component: PruductComponent },
  { path: "NewProduct", component: CrudProductComponent },
  { path: "Categories", component: CategoryComponent },
  { path: "Detalles", component: DetailsComponent },
    ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
