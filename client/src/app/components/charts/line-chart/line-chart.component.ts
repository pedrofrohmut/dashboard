import { Component, OnInit } from "@angular/core"
import { LINE_CHART_COLORS } from "../../../shared/chart.colors"

const LINE_CHART_SAMPLE_DATA: any[] = [
  { data: [32, 14, 46, 23, 38, 56], label: "Sentiment Analysis" },
  { data: [12, 18, 26, 13, 28, 26], label: "Image Recognition" },
  { data: [52, 34, 49, 53, 68, 62], label: "Forecasting" },
]

const LINE_CHART_LABELS: string[] = ["Jan", "Feb", "Mar", "Apr", "May", "Jun"]

const LINE_CHART_OPTIONS: any = {
  responsive: true,
  maintainAspectRation: false,
}

@Component({
  selector: "app-line-chart",
  templateUrl: "./line-chart.component.html",
  styleUrls: ["./line-chart.component.css"],
})
export class LineChartComponent implements OnInit {
  constructor() {}

  public lineChartData: any[] = LINE_CHART_SAMPLE_DATA
  public lineChartLabels: string[] = LINE_CHART_LABELS
  public lineChartOptions: any = LINE_CHART_OPTIONS
  public lineChartLegend: boolean = true
  public lineChartColors: any[] = LINE_CHART_COLORS
  public lineChartType: string = "line"

  ngOnInit() {}
}
