import { CommonModule, NgFor } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IngredientResponse } from '../../core/models/models/ingredient.response';

@Component({
  selector: 'ingreedio-ingredient-list-component',
  standalone: true,
  imports: [NgFor, FormsModule, CommonModule],
  templateUrl: './ingredient-list-component.html',
  styleUrl: './ingredient-list-component.scss'
})
export class IngredientListComponent {
  @Input() items : IngredientResponse[] = [];
  @Input() showVertical: boolean = false;
  @Input() showBigger: boolean = false;
  @Input() changeToSecondary: boolean = false;
  @Input() deleteElementCallback: (ingredient : IngredientResponse) => void = (ingredient) => {};

  onAddedIngredient(){

  }

  deleteElement(ingredient: IngredientResponse) {
    let index = this.items.indexOf(ingredient);
    if (index !== -1) {
      this.items.splice(index, 1);
    }
    this.deleteElementCallback(ingredient)
  }
}
 