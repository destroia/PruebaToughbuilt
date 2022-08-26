import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Image } from '../Models/image';

@Injectable({
  providedIn: 'root'
})
export class ImagenService {
  
  constructor(private http: HttpClient) { }

  PostImage(formData: FormData, productId: number) {
    return this.http.post(environment.urlServices + "Images/Post/" + productId , formData, { reportProgress: true, observe: 'events' })
  }
  Get(id: number): Observable<Image[]> {
    return this.http.get<Image[]>(environment.urlServices + "Images/Get/" + id);
  }
  Delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(environment.urlServices + "Images/Delete/" + id);
  }
}
