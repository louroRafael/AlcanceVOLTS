import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { TokenInterceptor } from 'src/infra/token-interceptor';

// Material
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatTabsModule } from '@angular/material/tabs';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSelectModule } from '@angular/material/select';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatBadgeModule } from '@angular/material/badge';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './home-page/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HomeComponent } from './home-page/home/home.component';
import { HeaderComponent } from './shared/header/header.component';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { ListEventComponent } from './event/list-event/list-event.component';
import { ListUserComponent } from './user/list-user/list-user.component';
import { EventComponent } from './event/event/event.component';
import { CreateEventComponent } from './event/create-event/create-event.component';
import { ListAreaComponent } from './area/list-area/list-area.component';
import { EventVolunteersComponent } from './event/event/event-volunteers/event-volunteers.component';
import { EventTeamsComponent } from './event/event/event-teams/event-teams.component';
import { CreateTeamComponent } from './event/event/event-teams/create-team/create-team.component';
import { CheckInEventComponent } from './event/check-in-event/check-in-event.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    HeaderComponent,
    SidebarComponent,
    ListEventComponent,
    ListUserComponent,
    EventComponent,
    CreateEventComponent,
    ListAreaComponent,
    EventVolunteersComponent,
    EventTeamsComponent,
    CreateTeamComponent,
    CheckInEventComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    MatCardModule,
    MatInputModule,
    NgbModule,
    HttpClientModule,
    MatSnackBarModule,
    MatMenuModule,
    MatSidenavModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatSlideToggleModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCheckboxModule,
    MatTabsModule,
    MatProgressBarModule,
    MatSelectModule,
    MatDividerModule,
    MatButtonModule,
    MatTooltipModule,
    MatBadgeModule,
    MatAutocompleteModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' },
    MatDatepickerModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
