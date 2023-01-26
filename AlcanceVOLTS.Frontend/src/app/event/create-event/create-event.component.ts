import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { Router } from '@angular/router';
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
  recurrentFormControl = new FormControl(false, [Validators.required]);
  frequencyFormControl = new FormControl(undefined);
  statusFormControl = new FormControl(undefined);

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
      recurrent: this.recurrentFormControl,
      frequency: this.frequencyFormControl,
      status: this.statusFormControl,
    });

    if(!this.isNew) {
      this.form.addControl('id',new FormControl(this.id));
    }
  }

  save() {
    const event = this.form.getRawValue();
    
    this.eventService.save(event).subscribe(r => {
      this.router.navigate(['/event/list']);
    });
  }
}
