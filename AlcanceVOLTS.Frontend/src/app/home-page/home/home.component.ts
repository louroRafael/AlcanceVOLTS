import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  userType: string = 'Usúario';

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.userType = this.authService.userType;
  }

}
