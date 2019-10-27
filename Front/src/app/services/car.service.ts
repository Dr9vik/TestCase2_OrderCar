import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { CarBLCL } from '../models/car';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  private apiUrl = `${environment.apiHostUrl}/api/car`;
  // tslint:disable-next-line: variable-name
  constructor(private _http: HttpClient) { }

  public getAll(): Observable<CarBLCL[]> {
    return this._http.get<CarBLCL[]>(`${this.apiUrl}/`);
  }
  public getById(id: string): Observable<CarBLCL> {
    return this._http.get<CarBLCL>(`${this.apiUrl}/${id}`);
  }
}
