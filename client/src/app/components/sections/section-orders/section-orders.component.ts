import { Component, OnInit } from "@angular/core"
import Order from "src/app/shared/models/Order"
import { MOCK_ORDERS } from "src/app/shared/orders.mockdata"

@Component({
  selector: "app-section-orders",
  templateUrl: "./section-orders.component.html",
  styleUrls: ["./section-orders.component.css"],
})
export class SectionOrdersComponent implements OnInit {
  constructor() {}

  public orders: Order[] = MOCK_ORDERS

  ngOnInit() {}
}
