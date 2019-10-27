import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderBLCL, OrderBLCreate, OrderBLUpdate } from '../models/order';
import { OrderBLFilter } from '../models/filters';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private apiUrl = `${environment.apiHostUrl}/api/order`;
  // tslint:disable-next-line: variable-name
  constructor(private _http: HttpClient) { }

  public getAll(): Observable<OrderBLCL[]> {
    return this._http.get<OrderBLCL[]>(`${this.apiUrl}/`);
  }
  public getAllFilter(filter?: OrderBLFilter): Observable<OrderBLCL[]> {
    // tslint:disable-next-line: max-line-length
    if(filter == null) {
      return this._http.get<OrderBLCL[]>(`${this.apiUrl}`);
    }
    return this._http.get<OrderBLCL[]>(`${this.apiUrl}/${filter.nameUser}/${filter.nameCar}/${filter.moderlCar}/${filter.start}/${filter.end}`);
  }
  public getById(id: string): Observable<OrderBLCL> {
    return this._http.get<OrderBLCL>(`${this.apiUrl}/${id}`);
  }
  public create(item: OrderBLCreate): Observable<OrderBLCreate> {
    return this._http.post<OrderBLCreate>(`${this.apiUrl}/create/`, item);
  }
  public update(item: OrderBLUpdate): Observable<OrderBLUpdate> {
    return this._http.post<OrderBLUpdate>(`${this.apiUrl}/update/`, item);
  }
  public delete(id: string): Observable<OrderBLUpdate> {
    return this._http.post<OrderBLUpdate>(`${this.apiUrl}/delete/${id}`, null);
  }
}
