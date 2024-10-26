import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DropdownIngredientInputComponent } from './dropdown-ingredient-input.component';

describe('DropdownIngredientInputComponent', () => {
  let component: DropdownIngredientInputComponent;
  let fixture: ComponentFixture<DropdownIngredientInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DropdownIngredientInputComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DropdownIngredientInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
