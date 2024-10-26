import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserProducerComponent } from './user-producer.component';

describe('UserProducerComponent', () => {
  let component: UserProducerComponent;
  let fixture: ComponentFixture<UserProducerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserProducerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserProducerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
