import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Filter } from 'src/models/common/filter';
import { User } from 'src/models/user/user';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class UserService extends HttpService {

  private ENDPOINT = '/User/';

  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  list(filter: Filter) {
		return this.post<User[]>(this.ENDPOINT + 'list', filter); 
	}
}
