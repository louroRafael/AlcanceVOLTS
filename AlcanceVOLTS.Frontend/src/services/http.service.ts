import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { environment } from 'src/environments/environment';
import { GLOBAL } from "src/infra/global";

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  protected API_URL = environment.apiUrl;

  constructor(protected httpClient: HttpClient) {
    if(window.location.hostname.includes('localhost'))
      this.API_URL = GLOBAL.DevBackendUrl;
  }

  get<T>(url: string, args = {}): Observable<T> {
    return this.httpClient.get<T>(this.API_URL + url, args);
  }

  put<T>(url: string, body: any, args = {}): Observable<T> {
      return this.httpClient.put<T>(this.API_URL + url, body, args);
  }

  post<T>(url: string, body: any, args = {}): Observable<T> {
      return this.httpClient.post<T>(this.API_URL + url, body, args);
  }

  delete<T>(url: string, args = {}): Observable<T> {
      return this.httpClient.delete<T>(this.API_URL + url, args);
  }
}
