import { Component, Input, OnInit } from '@angular/core';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { IngredientsDataService } from '../../core/services/ingredients-data/ingredients-data.service';
import { NavigationExtras, Router, RouterLink } from '@angular/router';
import { paths } from '../../app-paths';
import { IngredientModel } from '../../core/models/models/ingredient.model';
import { SearchProductsPropsModel } from '../../core/models/models/search-products-props.model';
import { CategoryService } from '../../core/services/category/category.service';
import { CategoryResponse } from '../../core/models/models/category.response';
import { IngredientResponse } from '../../core/models/models/ingredient.response';
import { Store } from '@ngrx/store';
import { selectIsJwtTokenSet } from '../../core/store/jwt-token/jwt-token.selectors';
import { checkIfObjectIsInArrayOfObjects, navigateToSearchProduct } from '../../core/utils/utils';
import { DropdownInputComponent } from '../dropdown-input/dropdown-input.component';
import { DropdownIngredientInputComponent } from '../dropdown-ingredient-input/dropdown-ingredient-input.component';
import { enumRole } from '../../core/models/enums/role.enum';
import { DropdownCategoryInputComponent } from '../dropdown-category-input/dropdown-category-input.component';

@Component({
  selector: 'ingreedio-search-products-form',
  standalone: true,
  imports: [
    MatSelectModule,
    MatFormFieldModule,
    CommonModule,
    FormsModule,
    RouterLink,
    ReactiveFormsModule,
    DropdownInputComponent,
    DropdownIngredientInputComponent,
    DropdownCategoryInputComponent
  ],
  templateUrl: './search-products-form.component.html',
  styleUrl: './search-products-form.component.scss',
})
export class SearchProductsFormComponent implements OnInit{
  @Input()
  defaultFormValues: SearchProductsPropsModel = new SearchProductsPropsModel();

  @Input()
  showVertical: boolean = false;

  @Input()
  hideCheckbox: boolean = true;

  @Input()
  isSearchProductPage: boolean = false;

  @Input()
  userRole: enumRole = enumRole.Client;

  roleEnum = enumRole;

  searchProductForm: FormGroup = this.fb.group({})
  submittedError: boolean = false;
  allIngredients: IngredientResponse[] = [];
  filteredIngredients: IngredientResponse[] = [];
  chosenIngredients: IngredientResponse[] = [];
  showIngredients: boolean = false;
  allCategories: CategoryResponse[] = [];
  filteredCategories: CategoryResponse[] = [];
  chosenCategory: CategoryResponse | undefined = { id: 0, name: "" };
  showCategory: boolean = false;

  constructor(
    private ingredientDataService: IngredientsDataService,
    private categoryService: CategoryService,
    private router: Router,
    private fb: FormBuilder,
  ) { 
  }

  ngOnInit(): void {
    
    // this.ingredientDataService.getIngredients().subscribe((ingredients) => {
    //   this.allIngredients = ingredients;
    //   this.filteredIngredients = ingredients;
    // })

    // this.categoryService.getCategories().subscribe((categories) => {
    //   this.allCategories = categories;
    //   this.filteredCategories = categories;
    // })

    this.searchProductForm = this.fb.group({
      showOnlyFavourite: [this.defaultFormValues.showOnlyFavourite],
      category: [this.defaultFormValues.category?.name],
      searchPhrase: [this.defaultFormValues.searchPhrase, Validators.required],
      ingredient: ['']
    })

    this.chosenCategory = this.defaultFormValues.category;
    this.chosenIngredients = this.defaultFormValues.ingredients;
  }

  getIngredientValue() {
    return this.searchProductForm.get('ingredient')?.value
  }

  setIngredientValue(ingredientValue: '') {
    this.searchProductForm.patchValue({ingredient: ingredientValue})
  }

  getChosenIngredients() {
    return this.chosenIngredients
  }

  addToIngredients(ingredient: IngredientResponse) {
    this.chosenIngredients.push(ingredient)
  }

  deleteIngredient(ingredient: IngredientResponse) {
    let index = this.chosenIngredients.indexOf(ingredient);
    if (index !== -1) {
      this.chosenIngredients.splice(index, 1);
    }
  }

  getCategoryValue() {
    return this.searchProductForm.get('category')?.value
  }

  setCategoryValue(categoryValue: string) {
    this.searchProductForm.patchValue({category: categoryValue})
  }

  chooseCategory(category: CategoryResponse | null) {
    if (category === null) {
      this.chosenCategory = undefined;
      return;
    }
    this.chosenCategory = category
    this.searchProductForm.patchValue({category: category.name})
    this.filteredCategories = [category]
  }

  onSubmit() {
    this.submittedError = !this.searchProductForm.valid

    if (this.submittedError) {
      return;
    }

    console.log(this.searchProductForm.getRawValue())

    if (this.chosenCategory?.name !== this.searchProductForm.get('category')?.value) {
      this.chosenCategory = undefined
    }

    navigateToSearchProduct(
      this.router, 
      this.chosenCategory, 
      this.searchProductForm.get('searchPhrase')?.value, 
      this.chosenIngredients, 
      this.searchProductForm.get('showOnlyFavourite')?.value, 
      this.isSearchProductPage)
  }
}
