import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Area } from 'src/models/area/area';
import { Filter } from 'src/models/common/filter';
import { AreaService } from 'src/services/area.service';

@Component({
  selector: 'app-create-team',
  templateUrl: './create-team.component.html',
  styleUrls: ['./create-team.component.scss']
})
export class CreateTeamComponent implements OnInit {

  form: FormGroup;
  nameFormControl = new FormControl('', [Validators.required]);
  dynamicFormControl = new FormControl(false, [Validators.required]);
  areasFormControl = new FormControl('');
  
  areasList: Area[] = [];

  constructor(
    private areaService: AreaService,
    private formBuilder: FormBuilder
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
  }
}
