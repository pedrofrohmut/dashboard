import { BrowserModule } from "@angular/platform-browser"
import { NgModule } from "@angular/core"

import { ChartsModule } from "ng2-charts"
import { AppRoutingModule } from "./app-routing.module"
import { AppComponent } from "./app.component"
import { NavbarComponent } from "./components/navbar/navbar.component"
import { SidebarComponent } from "./components/sidebar/sidebar.component"
import { SectionSalesComponent } from "./components/sections/section-sales/section-sales.component"
import { SectionOrdersComponent } from "./components/sections/section-orders/section-orders.component"
import { SectionHealthComponent } from "./components/sections/section-health/section-health.component"
import { BarChartComponent } from "./components/charts/bar-chart/bar-chart.component"
import { LineChartComponent } from "./components/charts/line-chart/line-chart.component"
import { PieChartComponent } from "./components/charts/pie-chart/pie-chart.component"

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    SectionSalesComponent,
    SectionOrdersComponent,
    SectionHealthComponent,
    BarChartComponent,
    LineChartComponent,
    PieChartComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, ChartsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
