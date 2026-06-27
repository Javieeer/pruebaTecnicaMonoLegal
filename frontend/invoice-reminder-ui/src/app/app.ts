import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { DashboardComponent } from './pages/dashboard/dashboard.component';

@Component({
  selector: 'app-root',
  imports: [DashboardComponent],
  templateUrl: './app.html'
})
export class App {
}