import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService } from 'src/services/event.service';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.scss']
})
export class EventComponent implements OnInit {

  id: any;
  isNew: boolean;

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
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private _adapter: DateAdapter<any>,
    @Inject(MAT_DATE_LOCALE) private _locale: string,
  ) {
    this.id = this.activatedRoute.snapshot.paramMap.get('id') ?? null;
    this.isNew = this.id == null;
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
      snack: this.snackFormControl,
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
