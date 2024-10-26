import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PricingAppComponent } from './pricing-app.component';

describe('PricingAppComponent', () => {
  let component: PricingAppComponent;
  let fixture: ComponentFixture<PricingAppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PricingAppComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PricingAppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
