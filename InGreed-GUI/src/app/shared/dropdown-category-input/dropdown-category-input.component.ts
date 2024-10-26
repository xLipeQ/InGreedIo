import { Component, Input } from '@angular/core';
import { CategoryService } from '../../core/services/category/category.service';
import { CategoryResponse } from '../../core/models/models/category.response';
import { DropdownInputComponent } from '../dropdown-input/dropdown-input.component';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'ingreedio-dropdown-category-input',
  standalone: true,
  imports: [DropdownInputComponent],
  templateUrl: './dropdown-category-input.component.html',
  styleUrl: './dropdown-category-input.component.scss'
})
export class DropdownCategoryInputComponent {
  @Input() getCategoryValue: () => string = () => ''
  @Input() setCategoryValue: (category: CategoryResponse | null) => void = () => {};
  @Input() showVertical: boolean = false;
  @Input() categoryHeader: string = "Category";
  @Input() searchProductForm: FormGroup = new FormGroup({})
  @Input() moveUp = true;

  showCategory: boolean = false;
  allCategories: CategoryResponse[] = [];
  filteredCategories: CategoryResponse[] = [];
  chosenCategory: CategoryResponse | undefined = { id: 0, name: "" };

  constructor (private categoryService: CategoryService) {
    this.categoryService.getCategories().subscribe((categories) => {
      this.allCategories = categories;
      this.filteredCategories = categories;
    })
  }

  filterCategories() {
    const formCategory = this.getCategoryValue();

    if (formCategory == "")
    {
      this.filteredCategories = this.allCategories
      return;
    }

    this.categoryService.getCategoriesWithPatern(formCategory).subscribe((categories) => {
      this.filteredCategories = categories;
    })
  }

  chooseCategory(category: CategoryResponse) {
    this.setCategoryValue(category)
  }

  resetCategory(category: CategoryResponse) {
    this.setCategoryValue(null)
  }

  onCategoryFocus() {
    this.showCategory = true;
  }

  onCategoryFocusLost() {
    setTimeout(() => { this.showCategory = false; }, 300);
  }
}
