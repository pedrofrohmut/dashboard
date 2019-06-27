import { Component, OnInit } from "@angular/core"
import Server from "src/app/shared/models/Server"

const SAMPLE_SERVERS: Server[] = [
  { id: 1, name: "dev-web", isOnline: true },
  { id: 2, name: "dev-mail", isOnline: false },
  { id: 3, name: "prod-web", isOnline: true },
  { id: 4, name: "prod-mail", isOnline: true },
]

@Component({
  selector: "app-section-health",
  template: `
    <div>
      <h2>System Health</h2>
      <div class="card-deck servers">
        <div *ngFor="let server of servers">
          <app-server [serverInput]="server"></app-server>
        </div>
      </div>
    </div>
  `,
  styles: [
    `
      h2 {
        margin-bottom: 50px;
      }
    `,
  ],
})
export class SectionHealthComponent implements OnInit {
  constructor() {}

  servers: Server[] = SAMPLE_SERVERS

  ngOnInit() {}
}
