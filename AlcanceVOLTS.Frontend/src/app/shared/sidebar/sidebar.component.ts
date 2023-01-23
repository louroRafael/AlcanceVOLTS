import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {

  @ViewChild('drawer') sidebar: MatSidenav;

  constructor() { }

  toggleSideBar() {
    this.sidebar.toggle();
    document.getElementById('page')?.classList.toggle('page-sidebar');
    document.getElementById('sidebar')?.classList.toggle('show-sidebar');
  }

}
