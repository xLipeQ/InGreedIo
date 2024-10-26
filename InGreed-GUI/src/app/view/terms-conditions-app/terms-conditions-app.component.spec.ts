import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TermsConditionsAppComponent } from './terms-conditions-app.component';

describe('TermsConditionsAppComponent', () => {
  let component: TermsConditionsAppComponent;
  let fixture: ComponentFixture<TermsConditionsAppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TermsConditionsAppComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TermsConditionsAppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
