import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Area } from 'src/models/area/area';
import { Filter } from 'src/models/common/filter';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class AreaService extends HttpService {

  private ENDPOINT = '/Area/';

  constructor(httpClient: HttpClient) { 
    super(httpClient);
  }

  save(event: Area) {
    return this.post<any>(this.ENDPOINT, event);
  }

  deleteArea(id: string) {
    return this.delete<any>(this.ENDPOINT + id);
  }

  list(filter: Filter) {
		return this.post<Area[]>(this.ENDPOINT + 'list', filter); 
	}
}
