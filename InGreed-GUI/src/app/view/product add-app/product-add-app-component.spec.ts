import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductAddAppComponent } from './product-add-app-component';

describe('ProductAddAppComponentComponent', () => {
  let component: ProductAddAppComponent;
  let fixture: ComponentFixture<ProductAddAppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProductAddAppComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProductAddAppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
