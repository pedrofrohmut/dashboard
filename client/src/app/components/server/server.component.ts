import { Component, OnInit, Input } from "@angular/core"
import Server from "src/app/shared/models/Server"

const setOnlineStyle = (server: Server): Server => {
  const newServer: Server = JSON.parse(JSON.stringify(server))
  return { ...newServer, color: "#66bb6a", buttonText: "Shut Down" }
}

const setOfflineStyle = (server: Server): Server => {
  const newServer: Server = JSON.parse(JSON.stringify(server))
  return { ...newServer, color: "#ff6b6b", buttonText: "Start" }
}

const updateServerStyleForStatus = (server: Server): Server =>
  server.isOnline ? setOnlineStyle(server) : setOfflineStyle(server)

const toggleServerStatus = (server: Server): Server => {
  return { ...server, isOnline: !server.isOnline }
}

@Component({
  selector: "app-server",
  template: `
    <div class="card mb-3 shadow block-status">
      <div class="card-header">{{ serverInput.name }}</div>

      <div class="card-body status" [ngStyle]="{ color: color }">
        <span
          class="card-body status"
          *ngIf="serverInput.isOnline; else elseBlock"
        >
          Online
        </span>
        <ng-template #elseBlock>Offline</ng-template>
      </div>

      <button
        role="button"
        (click)="toggleStatusClick(serverInput)"
        class="btn btn-info"
      >
        {{ buttonText }}
      </button>
    </div>
  `,
  styles: [
    `
      .card-header {
        background-color: #fff;
      }

      .block-status {
        width: 200px;
        font-size: 1.3rem;
        color: #333;
        text-align: center;
        padding: 25px;
      }

      status {
        display: block;
        transition: 0.3;
      }

      .name {
        padding: 5px;
        font-size: 0.85rem;
        display: block;
        font-fammily: monospace;
        transition: 0.3;
      }

      .action {
        display: block;
        font-size: 0.7rem;
        margin-top: 12px;
      }
    `,
  ],
})
export class ServerComponent implements OnInit {
  @Input() serverInput: Server
  buttonText: string
  color: string

  constructor() {
    this.toggleStatusClick = this.toggleStatusClick.bind(this)
  }

  ngOnInit() {
    const updatedServer = updateServerStyleForStatus(this.serverInput)
    this.buttonText = updatedServer.buttonText
    this.color = updatedServer.color
  }

  toggleStatusClick(server: Server) {
    const toggled = toggleServerStatus(server)
    this.serverInput.isOnline = toggled.isOnline

    const updated = updateServerStyleForStatus(toggled)
    this.buttonText = updated.buttonText
    this.color = updated.color
  }
}
