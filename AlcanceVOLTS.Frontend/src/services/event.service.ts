import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Filter } from 'src/models/common/filter';
import { Event } from 'src/models/event/event';
import { RegisterEvent } from 'src/models/event/register-event';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class EventService extends HttpService {

  private ENDPOINT = '/Event/';

  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  save(event: RegisterEvent) {
    return this.post<any>(this.ENDPOINT, event);
  }

  getById(id: string){
		return this.get<Event>(this.ENDPOINT + id);
	}

  list(filter: Filter) {
		return this.post<Event[]>(this.ENDPOINT + 'list', filter); 
	}
}
