import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoryService } from '../../Services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  categories: any[] = [];
  formCategory: FormGroup;
  actionStr: string = "Crear Categoria";
  constructor(private fb: FormBuilder, private serviceCategory: CategoryService, private route: Router) { }

  ngOnInit(): void {
    this.InitForm();
    this.loadCategory();
  }
  InitForm() {
    this.actionStr = "Crear Categoria";
    this.formCategory = this.fb.group(
      {
        id: [0],
        name: [, Validators.compose(
          [Validators.required,
            Validators.minLength(4),
            Validators.maxLength(15)])]
         });
  }
  Update(li) {
    this.actionStr = "Actualizar Categoria";
    this.formCategory = this.fb.group(
      {
        id: [li.id],
        name: [li.name, Validators.compose(
          [Validators.required,
          Validators.minLength(4),
          Validators.maxLength(15)])]
      });
  }
  Delete(li) {
    this.serviceCategory.Delete(li.id).subscribe(x => this.ConfirmDelete(x),err => console.log(err))
  }
    ConfirmDelete(x: boolean): void {
      this.loadCategory();
    }
  loadCategory() {
    this.categories = [];
    this.serviceCategory.Get().subscribe(x => this.ConfirmGetCategory(x),err => console.log(err))
  }
    ConfirmGetCategory(x: any[]): void {
      this.categories = x;
    }
  Save() {
    let name: string = this.formCategory.controls["name"].value;
    if (this.formCategory.controls["id"].value == 0) {
      this.serviceCategory.Create(name)
        .subscribe(x => this.ConfirmCreateCategory(x), err => console.log(err))
      
    } else {
      this.serviceCategory.Update(this.formCategory.controls["id"].value,this.formCategory.controls["name"].value)
        .subscribe(x => this.ConfirmCreateCategory(x), err => console.log(err))
    }
    this.actionStr = "Crear Categoria";
    this.InitForm();
  }
    ConfirmCreateCategory(x: boolean): void {
      this.loadCategory();
  }
  Atra() {
    this.route.navigate([""]);
  }
}
