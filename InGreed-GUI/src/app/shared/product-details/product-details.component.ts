import { Component, Input } from '@angular/core';
import { DescriptionFormatterPipe } from '../../core/pipes/description-formatter.pipe';
import { StarsComponent } from '../stars/stars.component';
import { Store } from '@ngrx/store';
import { selectIsJwtTokenSet, selectJwtToken } from '../../core/store/jwt-token/jwt-token.selectors';
import { ProductModel } from '../../core/models/models/product.model';
import { ProductService } from '../../core/services/product/product.service';
import { Route, Router } from '@angular/router';
import { paths } from '../../app-paths';
import { CommonModule } from '@angular/common';
import { DomSanitizer } from '@angular/platform-browser';
import { enumRole } from '../../core/models/enums/role.enum';

@Component({
  selector: 'ingreedio-product-details',
  standalone: true,
  imports: [DescriptionFormatterPipe, StarsComponent, CommonModule],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss'
})
export class ProductDetailsComponent {
  @Input()
  product: ProductModel = new ProductModel();
  @Input()
  productResponses: any;
  @Input()
  isAdminView: boolean = false;
  @Input()
  role: enumRole = enumRole.Client
  
  roleEnum = enumRole

  constructor(private store: Store, private productService: ProductService, private router: Router, private sanitizer: DomSanitizer) {
  }
  
  ngOnInit(){
    this.setImage();
  }

  addToFavourite(product: ProductModel) {
    this.store.select(selectIsJwtTokenSet)
      .subscribe((isTokenSet) => {
        if (isTokenSet) {
          this.store.select(selectJwtToken).subscribe((token) => {
            if(product.isFavourite){
              this.productService.deleteFavourite(token, product.id).subscribe();
            }
            else{
              this.productService.postFavourite(token, product.id).subscribe();
            }
          
            product.isFavourite = !product.isFavourite;
        })
        }
        
      });
    }
  navigateToProduct(product: ProductModel) {
    this.router.navigate([paths.product_details, product.id], {state: {product: product}});
  }

  setImage() {
      this.productService.getImage(this.product.id).subscribe(imageBlob => {
            
          this.product.imageData = {
            blob: imageBlob,
            localURL: this.sanitizer.bypassSecurityTrustUrl(URL.createObjectURL(imageBlob))
          };
      })
  }
}
