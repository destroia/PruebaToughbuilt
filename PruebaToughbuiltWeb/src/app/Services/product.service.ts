import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Product } from '../Models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }
  GetByProductId(id:number): Observable<Product> {
    return this.http.get<Product>(environment.urlServices + "Products/GetByProductId/" + id );
  }
  Get(page: number, name: string, categoryId :number): Observable<Product[]> {
    return this.http.get<Product[]>(environment.urlServices + "Products/GetAll/" + page +"/"+ name + "/" + categoryId);
  }
  Create(pro: Product): Observable<Product> {
    return this.http.post<Product>(environment.urlServices + "Products/Create/", pro)
  }
  Update(pro: Product): Observable<boolean> {
    return this.http.put<boolean>(environment.urlServices + "Products/Update", pro)
  }
  Delete(proId: number): Observable<boolean> {
    return this.http.delete<boolean>(environment.urlServices + "Products/Delete/" + proId);
  }
}
