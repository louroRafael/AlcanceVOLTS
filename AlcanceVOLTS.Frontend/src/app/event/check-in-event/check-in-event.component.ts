import { Component, OnInit } from '@angular/core';
import { Filter } from 'src/models/common/filter';
import { Event } from 'src/models/event/event';
import { Volunteer } from 'src/models/user/volunteer';
import { EventService } from 'src/services/event.service';

@Component({
  selector: 'app-check-in-event',
  templateUrl: './check-in-event.component.html',
  styleUrls: ['./check-in-event.component.scss']
})
export class CheckInEventComponent implements OnInit {

  public events: Event[] = [];
  public eventSelected: Event | null;

  public volunteers: Volunteer[] = [];
  public volunteerSelected: Volunteer;

  constructor(
    private eventService: EventService
  ) { }

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents() {
    this.eventService.list(new Filter).subscribe(r => {
      this.events = r;
    });
  }

  eventDeselect() {
    this.eventSelected = null;
  }

  loadEventInfo() {
    if(this.eventSelected)
      this.eventService.listVolunteers(this.eventSelected.id).subscribe(r => {
        this.volunteers = r;
      });
  }

  finish() {
    console.log(this.volunteerSelected);
  }
}
