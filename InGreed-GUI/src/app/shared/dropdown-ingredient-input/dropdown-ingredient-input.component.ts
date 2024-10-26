import { Component, Input, OnInit, Output } from '@angular/core';
import { IngredientResponse } from '../../core/models/models/ingredient.response';
import { IngredientsDataService } from '../../core/services/ingredients-data/ingredients-data.service';
import { checkIfObjectIsInArrayOfObjects } from '../../core/utils/utils';
import { FormGroup } from '@angular/forms';
import { DropdownInputComponent } from '../dropdown-input/dropdown-input.component';
import { EventEmitter } from 'stream';

@Component({
  selector: 'ingreedio-dropdown-ingredient-input',
  standalone: true,
  imports: [DropdownInputComponent],
  templateUrl: './dropdown-ingredient-input.component.html',
  styleUrl: './dropdown-ingredient-input.component.scss'
})
export class DropdownIngredientInputComponent implements OnInit{
  @Input() getIngredientValue: () => string = () => ''
  @Input() setIngredientValue: (ingredientValue: "") => void = () => {};
  @Input() getChosenIngredients: () => IngredientResponse[] = () => []
  @Input() addIngredient = (ingredient: IngredientResponse) => {}
  @Input() deleteIngredientParent = (ingredient: IngredientResponse) => {}
  @Input() searchProductForm: FormGroup = new FormGroup({});
  @Input() showVertical: boolean = false;
  @Input() ingredientHeader: string = "Ingredients"
  @Input() changeColorToPrimary: boolean = false;
  // @Output() passIngriedientToParent = new EventEmitter<number>();

  allIngredients: IngredientResponse[] = [];
  filteredIngredients: IngredientResponse[] = [];
  showIngredients: boolean = false;

  constructor(
    private ingredientDataService: IngredientsDataService
  ) { }

  ngOnInit(): void {
    this.ingredientDataService.getIngredients().subscribe((ingredients) => {
      this.allIngredients = ingredients;
      this.filteredIngredients = ingredients;
    })
  }

  filterIngredients() {
    const formIngredient = this.getIngredientValue();

    if (formIngredient == "")
    {
      this.filteredIngredients = this.allIngredients
      return;
    }

    this.ingredientDataService.getIngredientsWithPatern(formIngredient).subscribe((ingredients) => {
      this.filteredIngredients = ingredients;
    })
  }

  chooseIngredient(ingredient: IngredientResponse) {
    if (checkIfObjectIsInArrayOfObjects(ingredient, this.getChosenIngredients()))
    {
      return
    }

    this.pushToIngredients(ingredient)
    this.setIngredientValue('')
    this.filteredIngredients = this.allIngredients;
  }

  deleteIngredient(ingredient: IngredientResponse) {
    this.deleteIngredientParent(ingredient)
  }

  pushToIngredients(ingredient: IngredientResponse) {
    this.addIngredient(ingredient)
  }

  onIngredientFocus() {
    this.showIngredients = true;
  }

  onIngredientFocusLost() {
    setTimeout(() => { this.showIngredients = false; }, 300);
  }
}
