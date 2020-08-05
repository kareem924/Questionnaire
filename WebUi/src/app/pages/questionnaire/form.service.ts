import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

const API_USERS_URL = `${environment.backEndUrl}/forms`;
@Injectable({
  providedIn: 'root'
})
export class FormsService {

  constructor(private http: HttpClient) { }

  getAllForms(): Observable<any> {
    return this.http.get<any>(API_USERS_URL);
  }

  Create(model: any): Observable<any> {
    return this.http.post(API_USERS_URL, model);
  }

}
