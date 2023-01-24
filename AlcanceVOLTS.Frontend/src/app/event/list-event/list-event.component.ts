import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EventStatus, EventStatusLabelMapping } from 'src/enums/event-status';
import { Filter } from 'src/models/common/filter';
import { Event } from 'src/models/event/event';
import { EventService } from 'src/services/event.service';

@Component({
  selector: 'app-list-event',
  templateUrl: './list-event.component.html',
  styleUrls: ['./list-event.component.scss']
})
export class ListEventComponent implements OnInit {

  dataSource = new MatTableDataSource<Event>();
  filter: Filter = new Filter();

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  displayedColumns: string[] = [
    'name',
    'observation',
    'initialDate',
    'finalDate',
    'snack',
    'button',
    'status',
    'id'
  ];

  constructor(
    private eventService: EventService
  ) { }

  ngOnInit(): void {
    this.loadElements();
  }

  loadElements() {
    this.eventService.list(this.filter).subscribe(r => {
      this.dataSource = new MatTableDataSource(r);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  getEventStatusLabel(eventStatus: EventStatus) {
    return EventStatusLabelMapping.find(x => x.value == eventStatus)?.label;
  }
}
