import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventComponent } from './event/event/event.component';
import { ListEventComponent } from './event/list-event/list-event.component';
import { HomeComponent } from './home-page/home/home.component';
import { LoginComponent } from './home-page/login/login.component';
import { ListUserComponent } from './user/list-user/list-user.component';

const routes: Routes = [
  // Home Page
  { path: '', redirectTo:'/login', pathMatch:'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },

  // User
  { path: 'user/list', component: ListUserComponent },

  // Event
  { path: 'event/list', component: ListEventComponent },
  { path: 'event/new', component: EventComponent },
  { path: 'event/details/:id', component: EventComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
