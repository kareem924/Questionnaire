import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

const API_FORMS_URL = `${environment.backEndUrl}/forms`;
const API_SUBMIT_URL = `${environment.backEndUrl}/submit`;
@Injectable({
  providedIn: 'root'
})
export class FormsService {

  constructor(private http: HttpClient) { }

  getAllForms(): Observable<any> {
    return this.http.get<any>(API_FORMS_URL);
  }

  Create(model: any): Observable<any> {
    return this.http.post(API_FORMS_URL, model);
  }

  GetById(id: any): Observable<any> {
    return this.http.get(`${API_FORMS_URL}/${id}`);
  }

  SubmitForm(model: any): Observable<any> {
    return this.http.post(API_SUBMIT_URL, model);
  }

}
