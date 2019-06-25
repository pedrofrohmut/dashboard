import { BrowserModule } from "@angular/platform-browser"
import { NgModule } from "@angular/core"

import { AppRoutingModule } from "./app-routing.module"
import { AppComponent } from "./app.component"
import { NavbarComponent } from "./components/navbar/navbar.component"
import { SidebarComponent } from "./components/sidebar/sidebar.component"
import { SectionSalesComponent } from "./components/sections/section-sales/section-sales.component"
import { SectionOrdersComponent } from "./components/sections/section-orders/section-orders.component"
import { SectionHealthComponent } from "./components/sections/section-health/section-health.component"

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    SectionSalesComponent,
    SectionOrdersComponent,
    SectionHealthComponent
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
