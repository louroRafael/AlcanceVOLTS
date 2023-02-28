import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Team } from 'src/models/team/team';
import { Volunteer } from 'src/models/user/volunteer';
import { AlertService } from 'src/services/alert.service';
import { EventService } from 'src/services/event.service';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-event-volunteers',
  templateUrl: './event-volunteers.component.html',
  styleUrls: ['./event-volunteers.component.scss']
})
export class EventVolunteersComponent implements OnInit {

  @Input() eventId: string;
  public volunteers: Volunteer[] = [];
  public importVolunteers: Volunteer[] = [];
  public teams: Team[] = [];

  dataSource = new MatTableDataSource<Volunteer>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  displayedColumns: string[] = [
    'name',
    'email',
    'team',
    'action'
  ];

  constructor(
    private eventService: EventService,
    private alertService: AlertService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.loadElements();
    this.loadTeams();
  }

  loadElements() {
    this.alertService.showLoading();

    this.eventService.listVolunteers(this.eventId).subscribe(r => {
      this.dataSource = new MatTableDataSource(r);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      
      this.volunteers = r;

      this.alertService.hideLoading();
    });
  }

  loadTeams() {
    this.eventService.getTeams(this.eventId).subscribe(r => {
      this.teams = r;
    });
  }

  editVolunteer(volunteer: Volunteer) {
    var index = this.volunteers.indexOf(volunteer);
    
    this.volunteers[index].teamEdit = true;
  }

  saveVolunteer(volunteer: Volunteer) {
    var index = this.volunteers.indexOf(volunteer);

    this.eventService.saveVolunteer(volunteer).subscribe(() => {
      this.volunteers[index].teamEdit = false;
      this.loadElements();
    });
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
          this.importVolunteers = file.map(x => {
            var volunteer = new Volunteer(x["Nome Completo"], x["E-mail"]);
            return volunteer;
          });

          this.eventService.importVolunteers(this.importVolunteers, this.eventId).subscribe(r => {
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
