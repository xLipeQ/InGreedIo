import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainAppComponent } from './main-app.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { IngredientsDataService } from '../../core/services/ingredients-data/ingredients-data.service';

describe('MainAppComponent', () => {
  let component: MainAppComponent;
  let fixture: ComponentFixture<MainAppComponent>;
  let ingredientDataService: IngredientsDataService

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        IngredientsDataService
      ]
    }).compileComponents()

    fixture = TestBed.createComponent(MainAppComponent);
    component = fixture.componentInstance;
    
    ingredientDataService = TestBed.inject(IngredientsDataService);
    spyOn(ingredientDataService, 'getData').and.returnValue(['Ingredient 1', 'Ingredient 2', 'Ingredient 3', 'Ingredient 4', 'Ingredient 5']);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
