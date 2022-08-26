import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Characteristic } from '../../Models/characteristic';
import { Image } from '../../Models/image';
import { Product } from '../../Models/product';
import { CategoryService } from '../../Services/category.service';
import { CharacteristicService } from '../../Services/characteristic.service';
import { ImagenService } from '../../Services/imagen.service';
import { ProductService } from '../../Services/product.service';

@Component({
  selector: 'app-crud-product',
  templateUrl: './crud-product.component.html',
  styleUrls: ['./crud-product.component.css']
})
export class CrudProductComponent implements OnInit {
  formularioCreateProduct: FormGroup;
  formularioCharacteristic: FormGroup;
  categories: any[] = [];
  ErrorCategories: string = "";
  Characteristic: Characteristic[] = [];
  CharacteristicBool: boolean = false;
  productCreate: Product = null;
  images: Image[] = [];
  @Output() public onUploadFinished = new EventEmitter();
  CharacteristicStr: string = "Crear Caracteristicas";
  constructor(private fb: FormBuilder, private serviceCategories: CategoryService, private route: Router, private serviceProduct: ProductService,
    private serviceCharacteristic: CharacteristicService, private serviceImage: ImagenService) { }

  ngOnInit(): void {
    this.IntiFormProducts();
    this.LoadCategories();
  }
  LoadCategories() {
    this.serviceCategories.Get().subscribe(x => this.ConfirmGetCategories(x), err => console.log(err))
  }
    ConfirmGetCategories(x): void {
      this.categories = x;
    }
  IntiFormProducts() {
    this.formularioCreateProduct = this.fb.group(
      {
        id:[0],
        name: ["",Validators.compose([
          Validators.minLength(4), Validators.maxLength(50)])],
        categoryId: ["0"],
        price: ["", Validators.compose([
          Validators.required, Validators.min(1),
          Validators.max(90000000)])],
        stock: ["",Validators.compose([
          Validators.required,
          Validators.min(1), Validators.max(9999)])],
        description: ["",Validators.compose([
           Validators.maxLength(200)])]
      });
 
  }
  InitFormCharacteristic()
  {
    this.CharacteristicStr = "Crear Caracteristicas";
    this.formularioCharacteristic = this.fb.group(
      { id :[0],
        item: ["",Validators.compose([
          Validators.minLength(4), Validators.maxLength(15)])]
      });
  }
  UpdateFormCharacteristic(li) {
    this.CharacteristicStr = "Actualizar  Caracteristicas";
    this.formularioCharacteristic = this.fb.group(
      {
        id: [li.id],
        item: [li.item, Validators.compose([
          Validators.minLength(1), Validators.maxLength(15)])]
      });
  }

  onChangeCategoria(e) {
    if (e === "add") {
      this.route.navigate(["Categories"])
    }
  }
  Save() {
    this.formularioCreateProduct.controls['name'].disable();
    this.formularioCreateProduct.controls['categoryId'].disable();
    this.formularioCreateProduct.controls['price'].disable();
    this.formularioCreateProduct.controls['stock'].disable();
    this.formularioCreateProduct.controls['description'].disable();

    let temp: Product = {
      name: this.formularioCreateProduct.controls['name'].value,
      categoryId: Number(this.formularioCreateProduct.controls['categoryId'].value),
      price: this.formularioCreateProduct.controls['price'].value,
      stock: this.formularioCreateProduct.controls['stock'].value,
      description: this.formularioCreateProduct.controls['description'].value,
      id: this.formularioCreateProduct.controls['id'].value,
      images: [],
      characteristics: [],
      numPag:0
      
    }

    if (this.formularioCreateProduct.controls["id"].value === 0) {
      this.serviceProduct.Create(temp)
        .subscribe(x => this.ConfirmCrateProducto(x),err => console.log(err))
    } else {
      this.serviceProduct.Update(temp)
        .subscribe(x => this.ConfirmCrateProducto(this.productCreate), err => console.log(err))
    }
  }
  ConfirmCrateProducto(x: Product): void {
    this.InitFormCharacteristic();
    this.productCreate = x;
      this.CharacteristicBool = true;
  }
  SaveCharacteristic() {
    let temp: Characteristic = {
      id: this.formularioCharacteristic.controls["id"].value,
      productId: this.productCreate.id,
      item: this.formularioCharacteristic.controls["item"].value
    };

    if (temp.id === 0 ) {
      this.serviceCharacteristic.Create(temp)
        .subscribe(x => this.ConfirmCreateCharacteristic(x), err => console.log(err))
    } else {
      this.serviceCharacteristic.Update(temp)
        .subscribe(x => this.ConfirmCreateCharacteristic(x), err => console.log(err))
    }
    this.InitFormCharacteristic();
    
  }
  ConfirmCreateCharacteristic(x: boolean): void {
    this.loadCharacteristic();
    }
    ConfirmGetAll(x: Characteristic[]): void {
      this.Characteristic = x;
    }
  loadCharacteristic() {
    this.serviceCharacteristic.GetByproductId(this.productCreate.id)
      .subscribe(x => this.ConfirmGetAll(x), err => console.log(err))
  }
  UpdateCharacteristic(li)
  {
    this.UpdateFormCharacteristic(li);

  }
  DeleteCharacteristic(li)
  {
    this.serviceCharacteristic.Delete(li.id)
      .subscribe(x => this.ConfirmCreateCharacteristic(x), err => console.log(err))
  }
  progress: number = 0;
  public uploadFile = (files, n: number) => {
    if (files.length === 0) {
      return;
    }
    if (this.categories.length !== 0) {

    } else {
      alert("Primero debe crear una categoria ")
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);


    this.serviceImage.PostImage(formData, this.productCreate.id).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total); console.log(event)
      }
      else if (event.type === HttpEventType.Response) {
        this.onUploadFinished.emit(event.body);
        this.loadImages();
        
      }
    }, err => console.log(err));
  }
  loadImages() {
    this.images = [];
    this.serviceImage.Get(this.productCreate.id)
      .subscribe(x => this.ConfirmGetImages(x),err=> console.log(err))
    
  }
    ConfirmGetImages(x: Image[]): void {
      this.images = x;
    }
  DeleteImage(li)
  {
    this.serviceImage.Delete(li.id)
      .subscribe(x => this.ConfirmDeleteImage(x), err => console.log(err))
  }
  ConfirmDeleteImage(x: Boolean): void {
      this.loadImages();
  }
  showChavar: boolean = false;
  showCha() {
    this.showChavar = true;
    this.showImagevar = false;
  }
  showImagevar: boolean = false;
  showImage() {
    this.showImagevar = true;
    this.showChavar = false;
  }
  CreateProduct() {
    this.IntiFormProducts();
    this.CharacteristicBool = false;
    this.images = [];
    this.Characteristic = [];
    this.productCreate = null;
  }
  showCrateOrUpdate: boolean = true;

  UpdateProduct() {
    this.showCrateOrUpdate = false;
    this.IntiFormProducts();
    this.CharacteristicBool = false;
    this.images = [];
    this.Characteristic = [];
    this.productCreate = null;
    this.loadProducts();
  }
  UP(li: Product) {
    console.log(li)
    this.showCrateOrUpdate = true;
    this.formularioCreateProduct.controls["id"].setValue(li.id);
    this.formularioCreateProduct.controls["name"].setValue(li.name);
    this.formularioCreateProduct.controls["categoryId"].setValue(li.categoryId);
    this.formularioCreateProduct.controls["price"].setValue(li.price);

    this.formularioCreateProduct.controls["stock"].setValue(li.stock);
    this.formularioCreateProduct.controls["description"].setValue(li.description);
    console.log(this.formularioCreateProduct.value)
 
    this.productCreate = li;
    this.loadCharacteristic();
    this.loadImages();
    this.showCrateOrUpdate = true;
  }
  Products: Product[] = [];
  loadProducts() {
    this.Products = [];
    this.serviceProduct.Get(this.page-1, "0", 0).subscribe(x => this.CinfrimGetProducts(x),err => console.log(err))
  }
    CinfrimGetProducts(x: Product[]): void {
      this.Products = x;
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
  Atras() {
    this.route.navigate([""])
}
}


