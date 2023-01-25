import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { UserType, UserTypeLabelMapping } from 'src/enums/user-type';
import { Filter } from 'src/models/common/filter';
import { User } from 'src/models/user/user';
import { AlertService } from 'src/services/alert.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.scss']
})
export class ListUserComponent implements OnInit {

  dataSource = new MatTableDataSource<User>();
  filter: Filter = new Filter();

  displayedColumns: string[] = [
    'name',
    'login',
    'userType',
    'active',
  ];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private userService: UserService,
    private alertService: AlertService
  ) { }

  ngOnInit(): void {
    this.loadElements();
  }

  loadElements() {
    this.alertService.showLoading();

    this.userService.list(this.filter).subscribe(r => {
      this.dataSource = new MatTableDataSource(r);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

      this.alertService.hideLoading();
    });
  }

  getUserTypeLabel(userType: UserType) {
    return UserTypeLabelMapping.find(x => x.value == userType)?.label;
  }

}
