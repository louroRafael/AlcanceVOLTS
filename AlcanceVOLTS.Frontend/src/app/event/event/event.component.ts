import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Period } from 'src/models/event/period';
import { EventService } from 'src/services/event.service';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.scss']
})
export class EventComponent implements OnInit {

  id: any;
  isNew: boolean;
  periods: Period[] = [];

  constructor(
    private eventService: EventService,
    private activatedRoute: ActivatedRoute
  ) {
    this.id = this.activatedRoute.snapshot.paramMap.get('id') ?? null;
    this.isNew = this.id == null;
  }

  ngOnInit(): void {
    this.eventService.getById(this.id).subscribe(r => {
      this.periods = r.periods;
    })
  }
}
