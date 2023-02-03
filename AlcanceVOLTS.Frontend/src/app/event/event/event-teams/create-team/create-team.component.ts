import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Area } from 'src/models/area/area';
import { Filter } from 'src/models/common/filter';
import { AreaService } from 'src/services/area.service';
import { EventService } from 'src/services/event.service';

@Component({
  selector: 'app-create-team',
  templateUrl: './create-team.component.html',
  styleUrls: ['./create-team.component.scss']
})
export class CreateTeamComponent implements OnInit {

  @Output() hideCreateForm = new EventEmitter();

  form: FormGroup;
  nameFormControl = new FormControl('', [Validators.required]);
  dynamicFormControl = new FormControl(false, [Validators.required]);
  areasFormControl = new FormControl('');
  
  areasList: Area[] = [];

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
  }

  loadAreas() {
    this.areaService.list(new Filter()).subscribe(r => {
      this.areasList = r;
    });
  }

  createForm() {
    this.form = this.formBuilder.group({
      name: this.nameFormControl,
      dynamic: this.dynamicFormControl,
      areas: this.areasFormControl
    });
  }

  save() {
    const team = this.form.getRawValue();

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
