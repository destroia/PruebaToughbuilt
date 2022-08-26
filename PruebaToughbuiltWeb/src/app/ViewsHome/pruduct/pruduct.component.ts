import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from '../../Models/product';
import { CategoryService } from '../../Services/category.service';

import { ProductService } from '../../Services/product.service';

@Component({
  selector: 'app-pruduct',
  templateUrl: './pruduct.component.html',
  styleUrls: ['./pruduct.component.css']
})
export class PruductComponent implements OnInit {
  formularioSearch: FormGroup;
  categories: any[] = [];
  Products: Product[] = [];

  constructor(private fb: FormBuilder,private serviceCategories: CategoryService,
    private route: Router, private serviceProduct: ProductService) { }

  ngOnInit(): void {
    this.IntiFormProducts();
    this.LoadCategories();
    this.loadProducts();
    
  }

  IntiFormProducts() {
    this.formularioSearch = this.fb.group(
      {
        name: ["", Validators.compose([
          Validators.minLength(4), Validators.maxLength(50)])],
        categoryId: ["0"],
      });

  }
  LoadCategories() {
    this.serviceCategories.Get().subscribe(x => this.ConfirmGetCategories(x), err => console.log(err))
  }
    ConfirmGetCategories(x: any[]): void {
      this.categories = x;
  }
  Search() {
    this.loadProducts();
  }
  Detalles(li) {
    localStorage.setItem("p",li.id)
    this.route.navigate(["Detalles"]);
  }
  CreateNewProduct() {
    this.route.navigate(["NewProduct"])
  }
  CreateNewCategoryt() {
    this.route.navigate(["Categories"])
  }
  loadProducts() {
    this.Products = [];
    let cate: number = Number(this.formularioSearch.controls["categoryId"].value);
    let name: string = this.formularioSearch.controls["name"].value == "" ? 0 : this.formularioSearch.controls["name"].value;
    this.serviceProduct.Get(this.page - 1,name , cate).subscribe(x => this.CinfrimGetProducts(x), err => console.log(err))
  }
  CinfrimGetProducts(x: Product[]): void {
    this.Products = x;
    console.log(this.Products)
    if (x.length === 0) {
      this.totalPage = 0;
    } else {
      this.totalPage = x[0].numPag;
    }

  }

  totalPage: number = 0;
  page: number = 1;
  Ant() {
    if (this.page > 1) {
      this.page -= 1;
      this.loadProducts();
    }
  }
  Sig() {
    if (this.totalPage > 1 && this.totalPage > this.page) {
      this.page += 1;
      this.loadProducts();
    }
  }
  Ult() {
    if (this.totalPage != this.page) {
      this.page = this.totalPage;
      this.loadProducts();

    }
  }
  Pri() {
    if (this.page != 1) {
      this.page = 1;
      this.loadProducts();

    }
  }
}
