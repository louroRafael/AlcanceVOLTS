import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TshirtSize, TshirtSizeLabelMapping } from 'src/enums/tshirt-size';
import { Filter } from 'src/models/common/filter';
import { Event } from 'src/models/event/event';
import { Volunteer } from 'src/models/user/volunteer';
import { AlertService } from 'src/services/alert.service';
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
  public volunteerSelected?: Volunteer;

  constructor(
    private eventService: EventService,
    private alertService: AlertService,
    private snackBar: MatSnackBar
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

  volunteerDeselect() {
    this.volunteerSelected = undefined;
  }

  getTshirtSizeLabel(tshirtSize: TshirtSize) {
    return TshirtSizeLabelMapping.find(x => x.value == tshirtSize)?.label;
  }

  finish() {
    this.alertService.showLoading();

    this.eventService.checkIn(this.volunteerSelected).subscribe(r => {
      this.snackBar.open("Prontinho! Check-in realizado!", "OK", {
        duration: 3000,
        panelClass: ['success-snackbar']
      });

      this.alertService.hideLoading();
      this.volunteerSelected = undefined;
    });
  }
}
