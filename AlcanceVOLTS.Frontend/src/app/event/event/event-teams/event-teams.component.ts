import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-event-teams',
  templateUrl: './event-teams.component.html',
  styleUrls: ['./event-teams.component.scss']
})
export class EventTeamsComponent implements OnInit {

  showCreateForm: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  createTeam() {
    this.showCreateForm = true;
  }

  cancelCreateTeam() {
    this.showCreateForm = false;
  }
}
