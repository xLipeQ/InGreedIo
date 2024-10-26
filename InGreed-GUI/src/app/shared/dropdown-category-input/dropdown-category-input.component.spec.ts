import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DropdownCategoryInputComponent } from './dropdown-category-input.component';

describe('DropdownCategoryInputComponent', () => {
  let component: DropdownCategoryInputComponent;
  let fixture: ComponentFixture<DropdownCategoryInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DropdownCategoryInputComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DropdownCategoryInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
