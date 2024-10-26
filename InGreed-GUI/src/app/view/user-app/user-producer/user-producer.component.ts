import { Component } from '@angular/core';
import { ProductAddAppComponent } from '../../product add-app/product-add-app-component';
import { Router, Scroll } from '@angular/router';
import { paths } from '../../../app-paths';
import { ProductDetailsComponent } from '../../../shared/product-details/product-details.component';
import { ProductModel } from '../../../core/models/models/product.model';
import { CommonModule } from '@angular/common';
import { ScrollBottomDirective } from '../../../core/directives/ScrollBottomDirective';
import { enumRole } from '../../../core/models/enums/role.enum';
import { Store } from '@ngrx/store';
import { selectIsJwtTokenSet, selectJwtToken } from '../../../core/store/jwt-token/jwt-token.selectors';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ProductRequest } from '../../../core/models/models/product-request';
import { ProductService } from '../../../core/services/product/product.service';

@Component({
  selector: 'ingreedio-user-producer',
  standalone: true,
  imports: [ProductAddAppComponent, ProductDetailsComponent, CommonModule, ScrollBottomDirective],
  templateUrl: './user-producer.component.html',
  styleUrl: './user-producer.component.scss'
})
export class UserProducerComponent {
  products: ProductModel[] = [] 
  roleEnum = enumRole
  jwtHelper = new JwtHelperService()
  pageNumber: number = 1;

  constructor(private router: Router, private store: Store, private productService: ProductService) {
    this.addProducts()
  }

  navigateToAddProduct() {
    this.router.navigate([paths.productAdd])
  }

  setProducts(productRequest : ProductRequest){
    this.productService.get(productRequest).subscribe((productResponse) => {
      productResponse.productRows.forEach((product, idx) => {
        this.products.push(product);
      });
    }); 
  }

  addProducts() {
    let productRequest = this.getProductsRequest()

    this.store.select(selectIsJwtTokenSet)
    .subscribe((isTokenSet) => {
      if (isTokenSet) {
        this.store.select(selectJwtToken).subscribe((token) => {
          productRequest.Id = this.jwtHelper.decodeToken(token as string)['Id'];

          this.setProducts(productRequest);
        })
      } else{
        this.setProducts(productRequest);
      }
    });
  }

  getProductsRequest(): ProductRequest {
    return {
      PageNumber: this.pageNumber,
      NormalNumber: 10,
      OnlyFavourite: false,
      PromotionNumber: 0
    };
  }
  
  loadMoreProducts() {
    this.pageNumber += 1;
    this.addProducts();
  }
}
