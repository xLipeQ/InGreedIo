import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainTemplateIngreedIOComponent } from './main-template-ingreed-io.component';

describe('MainTemplateIngreedIOComponent', () => {
  let component: MainTemplateIngreedIOComponent;
  let fixture: ComponentFixture<MainTemplateIngreedIOComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MainTemplateIngreedIOComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(MainTemplateIngreedIOComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
