import { Component, Input, OnChanges, inject } from '@angular/core';
import { MainTemplateIngreedIOComponent } from '../../shared/main-template-ingreed-io/main-template-ingreed-io.component';
import { IngredientListComponent } from '../../shared/ingredient-list/ingredient-list-component';
import { FileListComponent } from '../../shared/file-list/file-list.component';
import { NgFor, NgIf } from '@angular/common';
import { ProductAddRequest } from '../../core/models/models/product-add-request';
import { ProductAddService } from '../../core/services/product-add/product-add.service';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { DropdownIngredientInputComponent } from '../../shared/dropdown-ingredient-input/dropdown-ingredient-input.component';
import { IngredientResponse } from '../../core/models/models/ingredient.response';
import { DropdownInputComponent } from '../../shared/dropdown-input/dropdown-input.component';
import { DropdownCategoryInputComponent } from '../../shared/dropdown-category-input/dropdown-category-input.component';
import { CategoryResponse } from '../../core/models/models/category.response';
import { JwtHelperService } from '@auth0/angular-jwt';
import { selectIsJwtTokenSet, selectJwtToken } from '../../core/store/jwt-token/jwt-token.selectors';
import { Store } from '@ngrx/store';
import { NotificationComponent } from '../../shared/notification/notification.component';
import { NotificationService } from '../../core/services/notification/notification.service';
@Component({
  selector: 'ingreedio-product-add-app-component',
  standalone: true,
  imports: [MainTemplateIngreedIOComponent, 
    IngredientListComponent,
    FileListComponent,
    NgFor,
    FormsModule,
    NgIf,
    DropdownIngredientInputComponent,
    DropdownInputComponent,
    DropdownCategoryInputComponent,
    NotificationComponent
  ],
  templateUrl: './product-add-app-component.html',
  styleUrl: './product-add-app-component.scss'
})
export class ProductAddAppComponent {
  productAdd: ProductAddRequest = {ProducentID: 3, ProductName: '', Description:'', Ingredients: [], Category: {id: 0, name: ''}};
  files: File[] = [];
  stringFiles : string[] = []; 
  formData: FormData = new FormData();
  ingredientsValue: string = ''
  searchProductForm: FormGroup = new FormGroup({})
  isProductAddingSuccess: boolean = false;
  jwtHelperService = new JwtHelperService();

  constructor(private productAddService : ProductAddService, private fb: FormBuilder,
    private store: Store, private notificationService : NotificationService
  ){
    this.searchProductForm = this.fb.group({
      category: ['', Validators.required],
      ingredient: ['', Validators.required],
    })
    
  }

  onFileSelected(event : Event) {
    // Iterate over selected files
    const target = event.target as HTMLInputElement;
    
    if(target.files == null || target.files.length == 0)
      return;

    const file = target.files[0];
    if(!file.name.includes('.jpg'))
    {
      this.notificationService.showNotification({
        type: "error",
        message: "only jpg are allowed!"
      });
      return;
    }
    if(this.files.findIndex(x => x.name == file.name) < 0)
    {
      this.stringFiles[0] = file.name;
      this.files[0] = file;
    }
    Array.from(this.files).forEach(x => this.formData.append('image', x));
  }   

  getCategoryValue() {
    return this.productAdd.Category.name
  }

  chooseCategory(category: CategoryResponse | null) {
    if (category === null) {
      this.productAdd.Category = {id: 0, name: ''}
      return;
    }

    this.productAdd.Category = category
    this.searchProductForm.patchValue({category: category.name})
  }

  getIngredientValue() {
    return this.ingredientsValue 
  }

  setIngredientValue(ingredientValue: '') {
    this.ingredientsValue = ingredientValue
  }

  getChosenIngredients() {
    return this.productAdd['Ingredients']
  }

  addToIngredients(ingredient: IngredientResponse) {
    this.productAdd['Ingredients'].push(ingredient)
  }

  deleteIngredient(ingredient: IngredientResponse) {
    let index = this.productAdd['Ingredients'].indexOf(ingredient);
    if (index !== -1) {
      this.productAdd['Ingredients'].splice(index, 1);
    }
  }

  canBeSend() : boolean{
    if(this.productAdd.ProductName == '')
    {
      this.notificationService.showNotification({
        type: 'error',
        message: 'Add product name!'
      });
      return false;
    }
    if(this.productAdd.Description == '')
    {
      this.notificationService.showNotification({
        type: 'error',
        message: 'Add description'
      });
      return false;
    }
    if(this.productAdd.Category.id == 0)
    {
      this.notificationService.showNotification({
        type: 'error',
        message: 'Select category'
      });
      return false;
    }
    if(this.productAdd.Ingredients.length == 0)
    {
      this.notificationService.showNotification({
        type: 'error',
        message: 'How can your product contain nothing? Are you selling air?'
      });
      return false;
    }
    if(this.files.length == 0)
    {
      this.notificationService.showNotification({
        type: 'error',
        message: 'Hey, let me see picture of your product!'
      });
      return false;
    }
    return true;
  }

  postSucces(){
    this.notificationService.showNotification({
      type: 'success',
      message: 'Your product has been added'
    });
  }

  postfailed(){
    this.notificationService.showNotification({
      type: 'error',
      message: 'Adding product failed'
    });
  }

  submit() {
    if(!this.canBeSend())
      return;
    this.store.select(selectIsJwtTokenSet)
    .subscribe((isTokenSet) => {
      if (isTokenSet) {
        this.store.select(selectJwtToken).subscribe((token) => {
          this.productAdd.ProducentID = Number(this.jwtHelperService.decodeToken(token as string)['Id']);
          const p = this.getformData();
          console.log(this.productAdd.ProducentID);
          this.productAddService.postProduct(p).subscribe({
            next: () => {
              this.isProductAddingSuccess = true;
              this.resetInputs();
              this.postSucces();
            },
            error: (err) => {
              this.isProductAddingSuccess = false;
              console.error('Post request failed', err);
              this.postfailed();
            }
          });
        });
      }
    });
    const can = this.canBeSend();
    
  }

  resetInputs() {
    this.productAdd = new ProductAddRequest()
    this.searchProductForm = this.fb.group({
      category: ['', Validators.required],
      ingredient: ['', Validators.required]
    })
    this.files = []
    this.stringFiles = []
  }

  getformData(){
    this.formData = new FormData();
    this.formData.append('Description', this.productAdd.Description);
    this.formData.append('ProducentID', this.productAdd.ProducentID.toString());
    this.formData.append('ProductName', this.productAdd.ProductName);
    this.productAdd.Ingredients.forEach(element => {
      this.formData.append('Ingredients', element.id.toString());
    });
    if (this.searchProductForm.get('category')?.value !== this.productAdd.Category.name) {
      this.productAdd.Category.id = 0;
    }
    this.formData.append('Category', JSON.stringify(this.productAdd.Category.id));
    this.formData.append('Image', this.files[0]);
    return this.formData;
  }
}
