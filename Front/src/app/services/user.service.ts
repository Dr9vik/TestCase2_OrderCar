import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserBLCL } from '../models/user';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = `${environment.apiHostUrl}/api/user`;
  // tslint:disable-next-line: variable-name
  constructor(private _http: HttpClient) { }

  public getAll(): Observable<UserBLCL[]> {
    return this._http.get<UserBLCL[]>(`${this.apiUrl}/`);
  }
  public getById(id: string): Observable<UserBLCL> {
    return this._http.get<UserBLCL>(`${this.apiUrl}/${id}`);
  }
}
