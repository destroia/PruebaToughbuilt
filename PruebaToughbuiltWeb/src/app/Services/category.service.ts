import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { env } from 'process';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  Get(): Observable<any[]> {
    return this.http.get<any[]>(environment.urlServices + "Categories/Get");
  }
  Create(name: string): Observable<boolean> {
    return this.http.post<boolean>(environment.urlServices + "Categories/Post", { name: name, id: 0 })
  }
  Update(id: number, name: string): Observable<boolean> {
    return this.http.put<boolean>(environment.urlServices + "Categories/Update", { name: name, id: id })
  }
  Delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(environment.urlServices + "Categories/Delete/" + id)
  }
}
