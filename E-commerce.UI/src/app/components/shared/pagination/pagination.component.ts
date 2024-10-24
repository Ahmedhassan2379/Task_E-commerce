import { NgFor } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [NgFor],
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.css'
})
export class PaginationComponent {

  @Input() totalPages: number = 0;
  @Input() currentPage: number = 1;
  @Output() pageChanged = new EventEmitter<number>();

  totalPagesArray: number[] = [];
  constructor() {}
  ngOnInit(): void {
    this.fillTotalPages();
  }

  ngOnChanges(): void{
    this.fillTotalPages();
  }
  fillTotalPages(): void {
    this.totalPagesArray = Array(this.totalPages).fill(0).map((x, i) => i + 1);
  }

  goToPage(page: number): void {
    this.pageChanged.emit(page);
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.pageChanged.emit(this.currentPage + 1);
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.pageChanged.emit(this.currentPage - 1);
    }
  }
}
