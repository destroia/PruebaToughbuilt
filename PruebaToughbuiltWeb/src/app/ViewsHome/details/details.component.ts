import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from '../../Models/product';
import { CategoryService } from '../../Services/category.service';
import { ProductService } from '../../Services/product.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  categories: any[] = [];
  product: Product;
  constructor(private serviceCategories: CategoryService,
    private route: Router, private serviceProduct: ProductService) { }

  ngOnInit(): void {
    this.loadData();
  }
  loadData()
  {
    let temp: number = Number(localStorage.getItem("p"));
    this.serviceProduct.GetByProductId(temp).subscribe(x => this.CinfrimGetProducts(x), err => console.log(err))
  }
    CinfrimGetProducts(x: Product): void {
      this.product = x;
      console.log(x)
    }
  LoadCategories() {
    this.serviceCategories.Get().subscribe(x => this.ConfirmGetCategories(x), err => console.log(err))
  }
  ConfirmGetCategories(x: any[]): void {
    this.categories = x;
  }
  Atras()
  {
    this.route.navigate([""]);
  }
}
