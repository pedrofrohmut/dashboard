import { Component, OnInit, Input } from "@angular/core"
import Server from "src/app/shared/models/Server"

@Component({
  selector: "app-server",
  template: `
    <div class="card mb-3 shadow block-status">
      <div class="card-header">{{ serverInput.name }}</div>

      <div class="card-body status">{{ serverInput.isOnline }}</div>

      <button class="btn btn-default action">Toggle Status</button>
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

  constructor() {}

  ngOnInit() {}
}
