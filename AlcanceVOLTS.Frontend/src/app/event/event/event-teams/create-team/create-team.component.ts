import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Area } from 'src/models/area/area';
import { Filter } from 'src/models/common/filter';
import { Period } from 'src/models/event/period';
import { TeamArea } from 'src/models/team/team-area';
import { AreaService } from 'src/services/area.service';
import { EventService } from 'src/services/event.service';

@Component({
  selector: 'app-create-team',
  templateUrl: './create-team.component.html',
  styleUrls: ['./create-team.component.scss']
})
export class CreateTeamComponent implements OnInit {

  @Input() eventId: string;
  @Input() periods: Period[] = [];
  @Output() hideCreateForm = new EventEmitter();

  form: FormGroup;
  nameFormControl = new FormControl('', [Validators.required]);
  dynamicFormControl = new FormControl(false, [Validators.required]);
  
  areas: Area[] = [];
  teamAreas: TeamArea[] = [];

  constructor(
    private areaService: AreaService,
    private eventService: EventService,
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar
  ) { 
    this.createForm();
  }

  ngOnInit(): void {
    this.loadAreas();
    this.defineAreasQuantity();
  }

  loadAreas() {
    this.areaService.list(new Filter()).subscribe(r => {
      this.areas = r;
    });
  }

  defineAreasQuantity() {
    this.teamAreas = [];

    if(this.form.value.dynamic)
      this.periods.forEach(period => {
        var teamArea = new TeamArea();
        teamArea.periodId = period.id;
        teamArea.period = period;

        this.teamAreas.push(teamArea);
      })
    else
      this.teamAreas.push(new TeamArea());
  }

  createForm() {
    this.form = this.formBuilder.group({
      name: this.nameFormControl,
      dynamic: this.dynamicFormControl
    });
  }

  save() {
    const team = this.form.getRawValue();
    team.eventId = this.eventId;
    team.teamAreas = this.teamAreas;

    this.eventService.saveTeam(team).subscribe(r => {
      this.snackBar.open("Prontinho! Equipe criada com sucesso!", "OK", {
        duration: 3000,
        panelClass: ['success-snackbar']
      });
      this.hideCreateForm.emit();
    });
  }

  cancel() {
    this.form.reset();
    this.hideCreateForm.emit();
  }
}
