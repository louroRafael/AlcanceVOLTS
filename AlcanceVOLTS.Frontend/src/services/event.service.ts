import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Filter } from 'src/models/common/filter';
import { Event } from 'src/models/event/event';
import { RegisterEvent } from 'src/models/event/register-event';
import { RegisterTeam } from 'src/models/event/register-team';
import { Volunteer } from 'src/models/user/volunteer';
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
    return this.post<string>(this.ENDPOINT, event);
  }

  deleteEvent(id: string) {
    return this.delete<any>(this.ENDPOINT + id);
  }

  getById(id: string) {
		return this.get<RegisterEvent>(this.ENDPOINT + id);
	}

  list(filter: Filter) {
		return this.post<Event[]>(this.ENDPOINT + 'list', filter); 
	}

  listVolunteers(id: string) {
    return this.get<Volunteer[]>(this.ENDPOINT + 'list-volunteers/' + id);
  }

  importVolunteers(volunteers: Volunteer[], id: string) {
    return this.put<any>(this.ENDPOINT + 'import-volunteers/' + id, volunteers);
  }

  saveTeam(team: RegisterTeam) {
    return this.post<any>(this.ENDPOINT + 'save-team', team);
  }
}
