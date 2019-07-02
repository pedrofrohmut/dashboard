import { Component, OnInit } from "@angular/core"
import Order from "src/app/shared/models/Order"
import { MOCK_ORDERS } from "src/app/shared/orders.mockdata"
import { SalesDataService } from "src/app/services/sales-data.service"

@Component({
  selector: "app-section-orders",
  templateUrl: "./section-orders.component.html",
  styleUrls: ["./section-orders.component.css"],
})
export class SectionOrdersComponent implements OnInit {
  orders: Order[]
  pagesCount: number = 0
  currentPage: number = 1
  pageSize: number = 10
  isLoading: boolean = true

  constructor(private salesDataService: SalesDataService) {}

  ngOnInit() {
    this.getOrdersPage(this.currentPage, this.pageSize)
  }

  getOrdersPage(pageIndex: number, pageSize: number) {
    this.salesDataService.getOrders(pageIndex, pageSize).subscribe((res) => {
      console.log(res)
      this.orders = res.data
      this.pagesCount = res.pagesCount
      this.isLoading = false
    })
  }

  handlePrevius() {
    if (this.currentPage > 1) {
      this.currentPage--
      this.getOrdersPage(this.currentPage, this.pageSize)
    }
  }

  handleNext() {
    if (this.currentPage < this.pagesCount) {
      this.currentPage++
      this.getOrdersPage(this.currentPage, this.pageSize)
    }
  }

  handleToPage(pageNumber: number) {
    if (pageNumber <= this.pagesCount && pageNumber > 0) {
      this.currentPage = pageNumber
      this.getOrdersPage(this.currentPage, this.pageSize)
    }
  }
}
