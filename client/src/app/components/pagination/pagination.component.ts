import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core"

@Component({
  selector: "app-pagination",
  template: `
    <div class="flex-container">
      <span class="text-white float-left mr-4 py-2">
        Page {{ currentPage }} of {{ pagesCount }}
      </span>
      <nav aria-label="pagination">
        <ul class="pagination">
          <li class="page-item">
            <button class="page-link text-dark" (click)="onPrevius()">
              Previous
            </button>
          </li>

          <li class="page-item" *ngFor="let pageNumber of pagesChunk">
            <button class="page-link text-dark" (click)="onToPage(pageNumber)">
              {{ pageNumber }}
            </button>
          </li>

          <li class="page-item">
            <button class="page-link text-dark" (click)="onNext()">Next</button>
          </li>
        </ul>
      </nav>
    </div>
  `,
  styles: [
    `
      .flex-container {
        display: flex;
        justify-content: center;
      }
    `,
  ],
})
export class PaginationComponent implements OnInit {
  @Input() currentPage: number
  @Input() pageSize: number
  @Input() pagesCount: number
  @Input() isLoading: boolean
  @Input() pagesChunk: number[]

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
    console.log(this.pagesChunk)
  }

  onToPage(pageNumber: number) {
    this.onEmitToPage.emit(pageNumber)
  }
}
