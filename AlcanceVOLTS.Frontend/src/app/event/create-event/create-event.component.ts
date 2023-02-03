import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { Router } from '@angular/router';
import { Event } from 'src/models/event/event';
import { Period } from 'src/models/event/period';
import { RegisterEvent } from 'src/models/event/register-event';
import { EventService } from 'src/services/event.service';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.scss']
})
export class CreateEventComponent implements OnInit {

  @Input() isNew: boolean;
  @Input() id: string;

  form: FormGroup;
  nameFormControl = new FormControl('', [Validators.required]);
  observationFormControl = new FormControl('');
  initialDateFormControl = new FormControl({ value: new Date, disabled: true }, [Validators.required]);
  finalDateFormControl = new FormControl({ value: new Date, disabled: true }, [Validators.required]);
  snackFormControl = new FormControl(false, [Validators.required]);
  buttonFormControl = new FormControl(false, [Validators.required]);
  tshirtFormControl = new FormControl(false, [Validators.required]);
  recurrentFormControl = new FormControl(false, [Validators.required]);
  frequencyFormControl = new FormControl(undefined);
  statusFormControl = new FormControl(undefined);
  periodsQuantityFormControl = new FormControl(1, [Validators.required]);

  periods: Period[] = [];
  minDate: Date;
  maxDate: Date;

  constructor(
    private eventService: EventService,
    private router: Router,
    private formBuilder: FormBuilder,
    @Inject(MAT_DATE_LOCALE) private _locale: string,
  ) {
    this.createForm();
  }

  ngOnInit(): void {
    if(!this.isNew) {
      this.eventService.getById(this.id).subscribe(r => {
        this.form.patchValue(r);
        this.periods = r.periods;

        this.minDate = r.initialDate;
        this.maxDate = r.finalDate;
      });

      this.form.addControl('id',new FormControl(this.id));
    }
  }

  createForm() {
    this.form = this.formBuilder.group({
      name: this.nameFormControl,
      observation: this.observationFormControl,
      initialDate: this.initialDateFormControl,
      finalDate: this.finalDateFormControl,
      button: this.buttonFormControl,
      tshirt: this.tshirtFormControl,
      recurrent: this.recurrentFormControl,
      frequency: this.frequencyFormControl,
      status: this.statusFormControl,
      periodsQuantity: this.periodsQuantityFormControl
    });

    if(!this.isNew) {
      this.form.addControl('id',new FormControl(this.id));
    }
  }

  save() {
    const event: RegisterEvent = this.form.getRawValue();
    
    if(!this.isNew)
      event.periods = this.periods;
    
    this.eventService.save(event).subscribe(r => {
      this.router.navigate(['/event/list']);
    });
  }
}
