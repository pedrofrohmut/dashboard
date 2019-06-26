import { Component, OnInit } from "@angular/core"

@Component({
  selector: "app-pie-chart",
  templateUrl: "./pie-chart.component.html",
  styleUrls: ["./pie-chart.component.css"],
})
export class PieChartComponent implements OnInit {
  constructor() {}

  public pieChartData: number[] = [350, 450, 120]
  public colors: any[] = [
    {
      backgroundColor: ["#26547c", "#ff6b6b", "#ffd166"],
      borderColor: "#333",
    },
  ]
  public pieChartLabels: string[] = [
    "XYZ Logistics",
    "Main St Bakery",
    "ACME Hosting",
  ]
  public pieChartType: string = "pie"

  ngOnInit() {}
}
