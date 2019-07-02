import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core"

@Component({
  selector: "app-pagination",
  template: `
    <nav aria-label="pagination">
      <ul class="pagination text-dark">
        <li class="page-item">
          <a class="page-link" (click)="onPrevius()">Previous</a>
        </li>
        <li class="page-item current-page">
          <a class="page-link">{{ currentPage }} of {{ pagesCount }}</a>
        </li>
        <li class="page-item">
          <a class="page-link" (click)="onNext()">Next</a>
        </li>
      </ul>
    </nav>
  `,
  styles: [
    `
      ul {
        cursor: pointer;
      }
    `,
  ],
})
export class PaginationComponent implements OnInit {
  @Input() currentPage: number
  @Input() pageSize: number
  @Input() pagesCount: number
  @Input() isLoading: boolean

  @Output() onEmitPrevius = new EventEmitter()
  @Output() onEmitNext = new EventEmitter()
  @Output() onEmitToPage = new EventEmitter<number>()

  constructor() {}

  ngOnInit() {}

  onPrevius() {
    this.onEmitPrevius.emit()
  }

  onNext() {
    this.onEmitNext.emit()
  }

  onToPage(pageNumber: number) {
    this.onEmitToPage.emit(pageNumber)
  }
}
