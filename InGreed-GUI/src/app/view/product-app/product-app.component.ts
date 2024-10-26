import { Component } from '@angular/core';
import { MainTemplateIngreedIOComponent } from '../../shared/main-template-ingreed-io/main-template-ingreed-io.component';
import { CommonModule } from '@angular/common';
import { StarsComponent } from '../../shared/stars/stars.component';
import { ProductModel } from '../../core/models/models/product.model';
import { ActivatedRoute, Router } from '@angular/router';
import { IngredientsDataService } from '../../core/services/ingredients-data/ingredients-data.service';
import { selectIsJwtTokenSet, selectJwtToken } from '../../core/store/jwt-token/jwt-token.selectors';
import { OpinionResponse } from '../../core/models/models/opinion.response';
import { OpinionService } from '../../core/services/opinion/opinion.service';
import { IngredientListComponent } from '../../shared/ingredient-list/ingredient-list-component';
import { DomSanitizer } from '@angular/platform-browser';
import { Store } from '@ngrx/store';
import { PreferenceService } from '../../core/services/preference/preference.service';
import { IngredientResponse } from '../../core/models/models/ingredient.response';
import { JwtHelperService } from '@auth0/angular-jwt';
import { MatDialog } from '@angular/material/dialog';
import { CreateOpinionComponent } from '../../shared/create-opinion/create-opinion.component';
import { isSet } from 'util/types';
import { Subscription, combineLatest } from 'rxjs';
import { CreateReportComponent } from '../../shared/create-report/create-report.component';
import { ReportService } from '../../core/services/report/report.service';

@Component({
  selector: 'ingreedio-product',
  standalone: true,
  imports: [MainTemplateIngreedIOComponent, CommonModule, StarsComponent, IngredientListComponent],
  templateUrl: './product-app.component.html',
  styleUrl: './product-app.component.scss'
})

export class ProductAppComponent {
  product: ProductModel | undefined;
  ingredientList: IngredientResponse[] = [];
  ingredientPreference: Map<number, number> = new Map<number, number>();
  preferenceImage = new Map<number, string>([
    [0, "../../../assets/heart-empty.png"],
    [1, "../../../assets/heart-full.png"]
  ]);
  opinionList: OpinionResponse[] = [];
  jwtHelperService = new JwtHelperService();
  isTokenSet: boolean = false;

  constructor(
    private router: Router,
    private store: Store,
    private dialog: MatDialog,
    ingredientService: IngredientsDataService,
    private preferenceService: PreferenceService,
    private opinionService: OpinionService,
    private reportService : ReportService,
    sanitizer: DomSanitizer) {

    this.product = (this.router.getCurrentNavigation()?.extras.state as { product: ProductModel })?.product;
    this.product.imageData.localURL = sanitizer.bypassSecurityTrustUrl(URL.createObjectURL(this.product.imageData.blob!))

    ingredientService.getIngredientsForProduct(this.product.id).subscribe((response) => {
      this.ingredientList = response;
      this.store.select(selectIsJwtTokenSet)
        .subscribe((isTokenSet) => {
          this.isTokenSet = isTokenSet;
          if (isTokenSet) {
            this.store.select(selectJwtToken).subscribe((token) => {
              let request = {
                userId: this.jwtHelperService.decodeToken(token as string)['Id'],
                ingredientIds: this.ingredientList.map(x => x.id),

              }
              preferenceService.getPreference(request, token as string).subscribe(preferenceResponse => {
                this.ingredientList.forEach(element => {
                  let pref = preferenceResponse.find(p => p.ingredientId == element.id);
                  if (pref == undefined) {
                    this.ingredientPreference.set(element.id, 0)
                  } else {
                    this.ingredientPreference.set(element.id, pref.preferenceType);
                  }
                });
              })
            })
          }
        });
    })

    this.opinionService.getOpinionForProduct(this.product.id).subscribe((response) => {
      this.opinionList = response;
    })


  }

  ngOnDestroy(){
    this.dialog.closeAll();
  }



  changePreference(ingredientID: number) {
    this.store.select(selectIsJwtTokenSet)
      .subscribe((isTokenSet) => {
        if (isTokenSet) {
          this.store.select(selectJwtToken).subscribe((token) => {
            if (this.ingredientPreference.get(ingredientID) == 0) {
              this.preferenceService.postPreference(
                {
                  userId: Number(this.jwtHelperService.decodeToken(token as string)['Id']),
                  ingredientId: ingredientID,
                  type: 1
                }, token as string).subscribe(response => {
                  this.ingredientPreference.set(ingredientID, 1);
                })
            } else {
              this.preferenceService.deletePreference(
                {
                  userId: Number(this.jwtHelperService.decodeToken(token as string)['Id']),
                  ingredientId: ingredientID,
                  type: undefined
                }, token as string).subscribe(response => {
                  this.ingredientPreference.set(ingredientID, 0);
                })
            }
          });
        }
      })
  }


  openAddReviewModal() {
    const isSet$ = this.store.select(selectIsJwtTokenSet);
    const jwtToken$ = this.store.select(selectJwtToken);

    combineLatest([isSet$, jwtToken$]).subscribe(([isSet, jwtToken]) => {
      if (isSet && jwtToken) {
          let dialogRef = this.dialog.open(CreateOpinionComponent, {
            height: '400px',
            width: '600px',
          });

          dialogRef.afterClosed().subscribe(result => {
            if (result['finished']) {
              this.opinionService.postOpinion({
                productId : this.product!.id,
                userId : Number(this.jwtHelperService.decodeToken(jwtToken as string)['Id']),
                comment : result['content'],
                rating : result['rating']
              }, jwtToken as string).subscribe(res => {
                this.opinionList.push({
                  userId : Number(this.jwtHelperService.decodeToken(jwtToken as string)['Id']),
                  username : this.jwtHelperService.decodeToken(jwtToken as string)['Username'],
                  content: result['content'],
                  rating: result['rating']
                });
              });
            }
          })
        
      }
    });
  }


  openReportModal(opinion : OpinionResponse) {
    const isSet$ = this.store.select(selectIsJwtTokenSet);
    const jwtToken$ = this.store.select(selectJwtToken);

    combineLatest([isSet$, jwtToken$]).subscribe(([isSet, jwtToken]) => {
      if (isSet && jwtToken) {
          let dialogRef = this.dialog.open(CreateReportComponent, {
            height: '400px',
            width: '600px',
          });

          dialogRef.afterClosed().subscribe(result => {
            if (result['finished']) {
              this.reportService.postReport({
                productId: this.product!.id,
                opinionCreatorId: opinion.userId,
                reporterId: Number(this.jwtHelperService.decodeToken(jwtToken as string)['Id']),
                reason: result['reason']
              }, jwtToken as string).subscribe(res => {

              });
            }
          })
        
      }
    });
  }

  deleteOpinion(){
    this.store.select(selectIsJwtTokenSet)
    .subscribe((isTokenSet) => {
      if (isTokenSet) {
        this.store.select(selectJwtToken).subscribe((token) => {
          let id = Number(this.jwtHelperService.decodeToken(token as string)['Id']);
          let opinion = this.opinionList.find(opinion => opinion.userId === id);
          if(opinion != undefined){
            this.opinionService.deleteOpinion(this.product!.id, id, token as string).subscribe(res => {
              this.opinionList = this.opinionList.filter(opinion => opinion.userId !== id);
            });
          }
        });
      }
    });
  }

  isLoggedInClient(opinion : OpinionResponse | undefined = undefined){
    let isOk = false;
    this.store.select(selectIsJwtTokenSet)
    .subscribe((isTokenSet) => {
      if (isTokenSet) {
        this.store.select(selectJwtToken).subscribe((token) => {
          if(opinion === undefined){
            isOk = true;
          } else{
            let id = Number(this.jwtHelperService.decodeToken(token as string)['Id']);
            isOk = id === opinion.userId;

          }
        });
      }
    });
    return isOk;
  }

  numSequence(n: number): Array<number> {
    return Array(n);
  }
}

