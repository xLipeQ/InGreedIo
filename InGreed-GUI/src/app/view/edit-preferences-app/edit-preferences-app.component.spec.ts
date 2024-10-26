import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPreferencesAppComponent } from './edit-preferences-app.component';

describe('EditPreferencesComponent', () => {
  let component: EditPreferencesAppComponent;
  let fixture: ComponentFixture<EditPreferencesAppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditPreferencesAppComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditPreferencesAppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
