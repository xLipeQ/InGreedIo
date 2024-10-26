import { Component, SimpleChanges } from '@angular/core';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';
import { MainTemplateIngreedIOComponent } from '../../shared/main-template-ingreed-io/main-template-ingreed-io.component';
import { SearchProductsPropsModel } from '../../core/models/models/search-products-props.model';
import { ProductModel } from '../../core/models/models/product.model';
import { CommonModule } from '@angular/common';
import { SearchProductsFormComponent } from '../../shared/search-products-form/search-products-form.component';
import { StarsComponent } from '../../shared/stars/stars.component';
import { paths } from '../../app-paths';
import { filter } from 'rxjs';
import { DescriptionFormatterPipe } from '../../core/pipes/description-formatter.pipe';
import { ProductService } from '../../core/services/product/product.service';
import { ProductRequest } from '../../core/models/models/product-request';
import { Store } from '@ngrx/store';
import { selectIsJwtTokenSet, selectJwtToken } from '../../core/store/jwt-token/jwt-token.selectors';
import {DomSanitizer} from '@angular/platform-browser';
import { PanelComponent } from '../../shared/user-panel/panel/panel.component';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ProductDetailsComponent } from '../../shared/product-details/product-details.component';
import { ScrollBottomDirective } from '../../core/directives/ScrollBottomDirective';
import { enumRole } from '../../core/models/enums/role.enum';
import { ROLES_JWT_FIELD } from '../../core/constants/constants';

@Component({
  selector: 'ingreedio-search-products-app',
  standalone: true,
  imports: [MainTemplateIngreedIOComponent, CommonModule, SearchProductsFormComponent, DescriptionFormatterPipe, StarsComponent, PanelComponent, ProductDetailsComponent, ScrollBottomDirective],
  templateUrl: './search-products-app.component.html',
  styleUrl: './search-products-app.component.scss',
})
export class SearchProductsAppComponent {
  jwtHelper : JwtHelperService = new JwtHelperService();
  formData: SearchProductsPropsModel;
  products: ProductModel[]; 
  promotionNumber: number;
  normalNumber: number;
  pageNumber: number;
  imgBlob : Blob | undefined;
  userRole: enumRole = enumRole.Client;
  userIsLoggedIn: boolean = false;
  productsResponses: any = []

  constructor(
      private router: Router, 
      private activatedRoute: ActivatedRoute,
      private productService: ProductService,
      private store: Store,
      private sanitizer: DomSanitizer) {

    const navigation = this.router.getCurrentNavigation();
    const state = navigation?.extras.state as { formValue: SearchProductsPropsModel };
    if (state) {
      this.formData = state.formValue;
    } else {
      this.formData = new SearchProductsPropsModel(undefined, "", []);
    }

    this.promotionNumber = 0;
    this.pageNumber = 1;
    this.normalNumber = 10;
    
    this.products = []
    this.loadProducts()
    const isSet$ = store.select(selectIsJwtTokenSet);

    isSet$.subscribe(isSet => {
      this.userIsLoggedIn = isSet;
    })
  }

  setProducts(productRequest : ProductRequest){
    this.productService.get(productRequest).subscribe((productResponse) => {
      productResponse.productRows.forEach((product, idx) => {
        this.products.push(product);
      });
    }); 
  }

  loadMoreProducts() {
    this.pageNumber += 1
    this.loadProducts()
  }

  loadProducts() {
    let productRequest = this.getProductsRequest()

    this.store.select(selectIsJwtTokenSet)
    .subscribe((isTokenSet) => {
      if (isTokenSet) {
        this.store.select(selectJwtToken).subscribe((token) => {
          if(this.formData.showOnlyFavourite){
            productRequest.OnlyFavourite = true;
          }
          this.userRole = this.jwtHelper.decodeToken(token as string)[ROLES_JWT_FIELD]
          if (this.userRole !== enumRole.Producent) {
            productRequest.Id = this.jwtHelper.decodeToken(token as string)['Id'];
          }
          this.setProducts(productRequest);
        })
      } else{
        this.setProducts(productRequest);
      }
    });
  }

  getProductsRequest(): ProductRequest {
    return {
      OnlyFavourite: false,
      Category: this.formData.category?.id,
      Ingredients: this.formData.ingredients.map(ing => ing.id),
      SearchPhrase: this.formData.searchPhrase,
      PageNumber: this.pageNumber,
      PromotionNumber: this.promotionNumber,
      NormalNumber: this.normalNumber,
    };
  }
}