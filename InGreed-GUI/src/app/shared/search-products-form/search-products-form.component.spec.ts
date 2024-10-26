import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SearchProductsFormComponent } from './search-products-form.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { IngredientsDataService } from '../../core/services/ingredients-data/ingredients-data.service';

describe('SearchProductsFormComponent', () => {
  let component: SearchProductsFormComponent;
  let fixture: ComponentFixture<SearchProductsFormComponent>;
  let ingredientDataService: IngredientsDataService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        FormsModule,
        MatFormFieldModule,
        MatSelectModule,
        BrowserAnimationsModule,
        SearchProductsFormComponent,
        HttpClientTestingModule
      ],
      providers: [IngredientsDataService]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchProductsFormComponent);
    component = fixture.componentInstance;
    ingredientDataService = TestBed.inject(IngredientsDataService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  // it('should filter ingredients based on the input', () => {
  //   component.ingredient = 'Oil';
  //   component.allIngredients = ['Oil', 'AnotherOil', 'SomeOil', 'Olive Oil']
  //   component.filterIngredients();
  //   expect(component.filteredIngredients.length).toBe(4);
  //   expect(component.filteredIngredients).toContain('Olive Oil');
  // });

  // it('should add chosen ingredient to the list and clear the input', () => {
  //   component.ingredient = 'Olive Oil';
  //   component.chooseIngredient('Olive Oil');
  //   expect(component.chosenIngredients).toContain('Olive Oil');
  //   expect(component.ingredient).toBe('');
  // });

  // it('should remove chosen ingredient from the list', () => {
  //   component.chosenIngredients = ['Olive Oil'];
  //   component.deleteIngredient('Olive Oil');
  //   expect(component.chosenIngredients).not.toContain('Olive Oil');
  // });

  it('should submit the form with correct values', () => {
    // spyOn(console, 'log');
    // component.onSubmit({
    //   category: 'cat1',
    //   searchPhrase: 'test',
    //   ingredient: 'Olive Oil',
    // });
    // expect(console.log).toHaveBeenCalledWith({
    //   category: 'cat1',
    //   searchPhrase: 'test',
    //   ingredient: 'Olive Oil',
    // });
  });
});
