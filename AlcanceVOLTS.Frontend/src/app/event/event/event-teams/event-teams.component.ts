import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Period } from 'src/models/event/period';
import { Team } from 'src/models/team/team';
import { AlertService } from 'src/services/alert.service';
import { EventService } from 'src/services/event.service';

@Component({
  selector: 'app-event-teams',
  templateUrl: './event-teams.component.html',
  styleUrls: ['./event-teams.component.scss']
})
export class EventTeamsComponent implements OnInit {

  @Input() eventId: string;
  @Input() periods: Period[];
  showCreateForm: boolean = false;

  dataSource = new MatTableDataSource<Team>();

  displayedColumns: string[] = [
    'name',
    'dynamic',
    'id'
  ];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private alertService: AlertService,
    private eventService: EventService
  ) { }

  ngOnInit(): void {
    this.loadElements();
  }
  
  loadElements() {
    this.alertService.showLoading();

    this.eventService.getTeams(this.eventId).subscribe(r => {
      this.dataSource = new MatTableDataSource(r);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      
      this.alertService.hideLoading();
    });
  }

  createTeam() {
    this.showCreateForm = true;
  }

  cancelCreateTeam() {
    this.showCreateForm = false;
  }
}
