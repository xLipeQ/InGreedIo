import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { IngredientsDataService } from './ingredients-data.service';

describe('IngredientsDataService', () => {
  let service: IngredientsDataService;
  let httpMock: HttpTestingController;
 
  beforeEach(() => {
     TestBed.configureTestingModule({
       imports: [HttpClientTestingModule],
       providers: [IngredientsDataService]
     });
 
     service = TestBed.inject(IngredientsDataService);
     httpMock = TestBed.inject(HttpTestingController);
  });
 
  afterEach(() => {
     httpMock.verify(); // Ensure that there are no outstanding requests
  });
 
  it('should be created', () => {
     expect(service).toBeTruthy();
  });
})
