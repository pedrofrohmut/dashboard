import { Component, OnInit } from "@angular/core"
import Order from "src/app/shared/models/Order"
import { SalesDataService } from "src/app/services/sales-data.service"

const getPagesChunkFor = (midVal: number, size: number): number[] => {
  const result = []
  const slice = Math.floor(size / 2)
  const start = midVal - slice
  const end = midVal + slice
  for (let i = start; i <= end; i++) {
    result.push(i)
  }
  return result
}

const getPagesChunk = (currentPage: number, pagesCount: number) => {
  // always odd number for chunkSize
  const chunkSize = 11
  const chunkSlice = Math.floor(chunkSize / 2)

  if (currentPage - chunkSlice <= 0) {
    return getPagesChunkFor(chunkSlice + 1, chunkSize)
  }

  if (currentPage + 5 > pagesCount) {
    return getPagesChunkFor(pagesCount - chunkSize - 1, chunkSize)
  }

  return getPagesChunkFor(currentPage, chunkSize)
}

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
  pagesChunk: number[] = getPagesChunk(this.currentPage, this.pagesCount)

  constructor(private salesDataService: SalesDataService) {}

  ngOnInit() {
    this.getOrdersPage(this.currentPage, this.pageSize)
  }

  getOrdersPage(pageIndex: number, pageSize: number) {
    this.salesDataService.getOrders(pageIndex, pageSize).subscribe((res) => {
      this.orders = res.data
      this.pagesCount = res.pagesCount
      this.isLoading = false
    })
  }

  handlePrevius() {
    if (this.currentPage > 1) {
      this.currentPage--
      this.getOrdersPage(this.currentPage, this.pageSize)
      this.pagesChunk = getPagesChunk(this.currentPage, this.pagesCount)
    }
  }

  handleNext() {
    if (this.currentPage < this.pagesCount) {
      this.currentPage++
      this.getOrdersPage(this.currentPage, this.pageSize)
      this.pagesChunk = getPagesChunk(this.currentPage, this.pagesCount)
    }
  }

  handleToPage(pageNumber: number) {
    if (pageNumber <= this.pagesCount && pageNumber > 0) {
      this.currentPage = pageNumber
      this.getOrdersPage(this.currentPage, this.pageSize)
    }
  }
}
