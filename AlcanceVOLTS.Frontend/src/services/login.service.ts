import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthRequest } from 'src/models/login/auth-request';
import { AuthResult } from 'src/models/login/auth-result';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService extends HttpService {

  private ENDPOINT = '/Login/';

  constructor(httpClient: HttpClient) { 
    super(httpClient);
  }

  login(email: string, password: string) {
    return this.post<AuthResult>(this.ENDPOINT, new AuthRequest(email, password));
  }
}
