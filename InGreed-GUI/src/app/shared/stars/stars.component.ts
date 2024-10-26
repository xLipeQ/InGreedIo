import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'ingreedio-stars',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './stars.component.html',
  styleUrl: './stars.component.scss',
})
export class StarsComponent {
  @Input() rating: number = 5;
}
