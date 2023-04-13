import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable, map, startWith } from 'rxjs';
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

  volunteerControl = new FormControl<string | Volunteer>("");
  public volunteers: Volunteer[] = [];
  public filteredVolunteers: Observable<Volunteer[]>;
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
    this.volunteerDeselect();
  }

  loadEventInfo() {
    if(this.eventSelected)
      this.eventService.listVolunteers(this.eventSelected.id).subscribe(r => {
        this.volunteers = r;

        this.filteredVolunteers = this.volunteerControl.valueChanges
        .pipe(
          startWith(""),
          map(volunteer => {
            const name = typeof volunteer === 'string' ? volunteer : volunteer?.name;
            return name ? this._filterVolunteer(name as string) : this.volunteers.slice();
          })) ;
      });
  }

  displayName(volunteer: Volunteer): string {
    return volunteer && volunteer.name ? volunteer.name : '';
  }

  private _filterVolunteer(value: string): Volunteer[] {
    const filterValue = value.toLowerCase();
    return this.volunteers.filter(x => x.name.toLowerCase().includes(filterValue));
  }

  volunteerSelect(volunteer: Volunteer) {
    this.volunteerSelected = volunteer;
  }

  volunteerDeselect() {
    this.volunteerSelected = undefined;
    this.volunteerControl.setValue("");
  }

  getTshirtSizeLabel(tshirtSize: TshirtSize) {
    return TshirtSizeLabelMapping.find(x => x.value == tshirtSize)?.label;
  }

  checkSnack(periodId: string): boolean {
    return this.volunteerSelected?.snacks.find(x => x == periodId) != null;
  }

  hadSnack(periodId: string) {
    if(this.volunteerSelected)
    {
      if(!this.volunteerSelected.snacks.some(x => x == periodId))
        this.volunteerSelected.snacks.push(periodId);
      else
        this.volunteerSelected.snacks = this.volunteerSelected?.snacks.filter(x => x != periodId);
    }
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
