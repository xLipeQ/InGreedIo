import { NgFor } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'ingreedio-file-list',
  standalone: true,
  imports: [NgFor],
  templateUrl: './file-list.component.html',
  styleUrl: './file-list.component.scss'
})
export class FileListComponent {
  @Input() items : string[] = [];

  deleteItem(index: number) {
    this.items.splice(index, 1);
  }
}
