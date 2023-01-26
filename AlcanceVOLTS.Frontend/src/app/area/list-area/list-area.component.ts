import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Area } from 'src/models/area/area';
import { Filter } from 'src/models/common/filter';
import { AlertService } from 'src/services/alert.service';
import { AreaService } from 'src/services/area.service';

@Component({
  selector: 'app-list-area',
  templateUrl: './list-area.component.html',
  styleUrls: ['./list-area.component.scss']
})
export class ListAreaComponent implements OnInit {

  addArea: boolean = false;
  area: Area = new Area();
  nameFormControl = new FormControl('', [Validators.required]);

  dataSource = new MatTableDataSource<Area>();
  filter: Filter = new Filter();

  displayedColumns: string[] = [
    'name',
    'id'
  ];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private areaService: AreaService,
    private alertService: AlertService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.loadElements();
  }

  loadElements() {
    this.alertService.showLoading();

    this.areaService.list(this.filter).subscribe(r => {
      this.dataSource = new MatTableDataSource(r);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

      this.alertService.hideLoading();
    });
  }

  createArea() {
    this.area.name = this.nameFormControl.getRawValue() ?? "";
    
    this.areaService.save(this.area).subscribe(r => {
      this.nameFormControl.setValue("");
      this.nameFormControl.clearValidators();
      this.addArea = false;

      this.loadElements();

      this.snackBar.open("Prontinho! Área adicionada com sucesso!", "OK", {
				duration: 3000,
				panelClass: ['success-snackbar']
			});
    });
  }

  deleteArea(id: string) {
    this.areaService.deleteArea(id).subscribe(r => {
      this.loadElements();

      this.snackBar.open("Prontinho! Área deletada com sucesso!", "OK", {
				duration: 3000,
				panelClass: ['success-snackbar']
			});
    });
  }
}
