import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { SearchProductsAppComponent } from './search-products-app.component';

describe('SearchProductsAppComponent', () => {
 let component: SearchProductsAppComponent;
 let fixture: ComponentFixture<SearchProductsAppComponent>;
 let mockActivatedRoute;

 beforeEach(async () => {
    mockActivatedRoute = {
      queryParams: of({ data: JSON.stringify({ key: 'value' }) }) // Mock queryParams observable
    };

    await TestBed.configureTestingModule({
      providers: [
        { provide: ActivatedRoute, useValue: mockActivatedRoute }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(SearchProductsAppComponent);
    component = fixture.componentInstance;
 });

 it('should create', () => {
    expect(component).toBeTruthy();
 });
});