import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <app-navbar></app-navbar>
    <main class="row" id="main-content">
      <app-sidebar class="col-sm-3"></app-sidebar>
      <div class="col-sm-9" id="dashboard">
        <p>Content goes here.</p>
      </div>
    </main>
  `,
  styles: []
})
export class AppComponent {
  title = 'client';
}
