import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Volunteer } from 'src/models/user/volunteer';
import { AlertService } from 'src/services/alert.service';
import { EventService } from 'src/services/event.service';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-event-general',
  templateUrl: './event-general.component.html',
  styleUrls: ['./event-general.component.scss']
})
export class EventGeneralComponent implements OnInit {

  public volunteers: Volunteer[] = [];

  constructor(
    private eventService: EventService,
    private alertService: AlertService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
  }

  importXlsx(event) {
    this.alertService.showLoading();
    const files = event.target.files as FileList;

    if (files && files.length == 1) {
      const reader: FileReader = new FileReader();
      reader.readAsBinaryString(files[0]);
      reader.onload = (e: any) => {
        const binarystr: string = e.target.result;
        const wb: XLSX.WorkBook = XLSX.read(binarystr, { type: 'binary' });
        const wsname: string = wb.SheetNames[0];
        const ws: XLSX.WorkSheet = wb.Sheets[wsname];
        const file: any = XLSX.utils.sheet_to_json(ws, { raw: false });

        if (!file || file.length <= 0)
        {
          this.snackBar.open("Ops! A planilha selecionada está vazia!", "OK", {
            duration: 3000,
            panelClass: ['warning-snackbar']
          });
          this.alertService.hideLoading();
        }
        else {
          this.volunteers = file.map(x => {
            var volunteer = new Volunteer(x["Nome Completo"], x["E-mail"]);
            return volunteer;
          });

          this.eventService.importVolunteers(this.volunteers).subscribe(r => {
            this.snackBar.open("Prontinho! Voluntários importados com sucesso!", "OK", {
              duration: 3000,
              panelClass: ['success-snackbar']
            });
            this.alertService.hideLoading();
          });
        }
      };
    }
    else
      this.alertService.hideLoading();
  }
}
