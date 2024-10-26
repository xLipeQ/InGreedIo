import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { IngredientListComponent } from '../ingredient-list/ingredient-list-component';

@Component({
  selector: 'ingreedio-dropdown-input',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, IngredientListComponent],
  templateUrl: './dropdown-input.component.html',
  styleUrl: './dropdown-input.component.scss'
})
export class DropdownInputComponent {
  @Input()
  keyUpCallback: () => void = () => {};
  @Input()
  focusCallback: () => void = () => {};
  @Input()
  unfocusCallback: () => void = () => {};
  @Input()
  deleteElementCallback: (element: any) => void = (element: any) => {};
  @Input()
  showDropdown: boolean = false;
  @Input()
  elements: any[] = [];
  @Input()
  filteredElements: any[] = []
  @Input()
  chooseElement: (element: any | null) => void = (element: any) => {}
  @Input()
  showVertical: boolean = false;
  @Input()
  header: string = ''
  @Input()
  myControlName: string = ''
  @Input()
  id: string = ''
  @Input()
  showPickedIngredients: boolean = false;
  @Input()
  searchProductForm: FormGroup = new FormGroup({});
  @Input()
  changeColorToPrimary: boolean = false;
  @Input()
  moveUp: boolean = false;
  @Input()
  isCategoryInput: boolean = false;
}
