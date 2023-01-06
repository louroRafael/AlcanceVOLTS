import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { SidebarComponent } from './shared/sidebar/sidebar.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'AlcanceVOLTS.Frontend';

  @ViewChild(SidebarComponent) sidebar: SidebarComponent;

  constructor(
    private router: Router
  ) {  }

  get loginPage() {
    return this.router.url.includes("login");
  }

  toggleSidebar() {
    this.sidebar.toggleSideBar();
  }
}
