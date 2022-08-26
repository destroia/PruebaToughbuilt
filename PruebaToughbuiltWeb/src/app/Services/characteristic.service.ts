import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Characteristic } from '../Models/characteristic';

@Injectable({
  providedIn: 'root'
})
export class CharacteristicService {

  constructor(private http: HttpClient) { }

  GetByproductId(id: number): Observable<Characteristic[]> {
    return this.http.get<Characteristic[]>(environment.urlServices + "Characteristicies/GetByProductId/" + id)
  }
  Create(pro: Characteristic): Observable<boolean> {
    return this.http.post<boolean>(environment.urlServices + "Characteristicies/Post", pro)
  }
  Update(pro: Characteristic): Observable<boolean> {
    return this.http.put<boolean>(environment.urlServices + "Characteristicies/Update", pro)
  }
  Delete(proId: number): Observable<boolean> {
    return this.http.delete<boolean>(environment.urlServices + "Characteristicies/Delete/" + proId);
  }
}
