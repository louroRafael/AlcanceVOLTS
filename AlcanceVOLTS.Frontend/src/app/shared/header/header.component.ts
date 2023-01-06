import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  
  @Input() showSidebar: boolean = false;
  @Output() sidebarToggle = new EventEmitter();
  userName: string;

  constructor(private authService: AuthService) { 
    
  }

  ngOnInit(): void {
    this.userName = this.authService.userName;
  }

  toggleSidebar() {
    this.showSidebar = !this.showSidebar;
    this.sidebarToggle.emit({ situation: this.showSidebar })
  }

  logout() {
    this.authService.logout();
  }
}
