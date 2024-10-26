import { Component, OnInit } from '@angular/core';
import { MainTemplateIngreedIOComponent } from '../../shared/main-template-ingreed-io/main-template-ingreed-io.component';
import { PanelComponent } from '../../shared/user-panel/panel/panel.component';
import { UserPanelComponent } from '../../shared/user-panel/user-panel.component';
import { Store } from '@ngrx/store';
import { CommonModule } from '@angular/common';
import { IngredientResponse } from '../../core/models/models/ingredient.response';
import { IngredientsDataService } from '../../core/services/ingredients-data/ingredients-data.service';
import { DropdownInputComponent } from '../../shared/dropdown-input/dropdown-input.component';
import { DropdownIngredientInputComponent } from '../../shared/dropdown-ingredient-input/dropdown-ingredient-input.component';
import { IngredientListComponent } from '../../shared/ingredient-list/ingredient-list-component';
import { checkIfObjectIsInArrayOfObjects } from '../../core/utils/utils';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PreferenceService } from '../../core/services/preference/preference.service';
import { selectIsJwtTokenSet, selectJwtToken } from '../../core/store/jwt-token/jwt-token.selectors';
import { Subscription, combineLatest } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'ingreedio-edit-preferences',
  standalone: true,
  imports: [MainTemplateIngreedIOComponent, UserPanelComponent, CommonModule, DropdownInputComponent, DropdownIngredientInputComponent, IngredientListComponent],
  templateUrl: './edit-preferences-app.component.html',
  styleUrl: './edit-preferences-app.component.scss'
})
export class EditPreferencesAppComponent implements OnInit {
  showFavourites: boolean = true;
  favouritesIngredients: IngredientResponse[] = []
  dislikedIngredients: IngredientResponse[] = []
  ingredientValue: IngredientResponse = { id: 0, name: "" }
  searchIngredientForm: FormGroup;
  jwtHelper: JwtHelperService = new JwtHelperService();

  constructor(
    private store: Store,
    private ingredientDataService: IngredientsDataService,
    private preferenceService: PreferenceService,
    private fb: FormBuilder) {
    this.searchIngredientForm = this.fb.group({
      ingredient: ['']
    })
  }

  ngOnInit(): void {
    // function to change, because we dont have endpoint for getting favourites ingredients and disliked ingredients
    const isSet$ = this.store.select(selectIsJwtTokenSet);
    const jwtToken$ = this.store.select(selectJwtToken);

    combineLatest([isSet$, jwtToken$]).subscribe(([isSet, jwtToken]) => {
      if (isSet && jwtToken) {

        this.ingredientDataService.getIngredients().subscribe((ingredients) => {
          this.preferenceService.getUserPreference(Number(this.jwtHelper.decodeToken(jwtToken as string)['Id']), jwtToken as string)
            .subscribe(preferences => {
              this.favouritesIngredients = ingredients.filter(ingredient =>
                preferences.find(pref => pref.ingredientId == ingredient.id && pref.preferenceType == 1) !== undefined);

              this.dislikedIngredients = ingredients.filter(ingredient =>
                preferences.find(pref => pref.ingredientId == ingredient.id && pref.preferenceType == -1) !== undefined);
            })
        })
      }
    });

  }

  changeListing(changeToFavourites: boolean) {
    this.showFavourites = changeToFavourites
  }

  getIngredientValue() {
    return this.searchIngredientForm.get('ingredient')?.value
  }

  addPreference(ingredient: IngredientResponse) {
    const isSet$ = this.store.select(selectIsJwtTokenSet);
    const jwtToken$ = this.store.select(selectJwtToken);

    combineLatest([isSet$, jwtToken$]).subscribe(([isSet, jwtToken]) => {
      if (isSet && jwtToken) {
        let type = 1;
        if (!this.showFavourites) {
          type = -1;
        }

        this.preferenceService.postPreference({
          userId : Number(this.jwtHelper.decodeToken(jwtToken as string)['Id']),
          ingredientId : ingredient.id,
          type : type // favourite
        }, jwtToken as string).subscribe(res => {
          if (this.showFavourites) {
            this.addToArray(ingredient, this.favouritesIngredients);
            this.deleteFromArray(ingredient, this.dislikedIngredients);
          } else {
            this.addToArray(ingredient, this.dislikedIngredients);
            this.deleteFromArray(ingredient, this.favouritesIngredients);
          }
        });
      }
    });
  }

  addToArray(ingredient: IngredientResponse, ingredientArray: IngredientResponse[]) {
    if (checkIfObjectIsInArrayOfObjects(ingredient, ingredientArray))
      return
    ingredientArray.push(ingredient)
  }

  deleteFromArray(ingredient: IngredientResponse, ingredientArray: IngredientResponse[]){
    let index = ingredientArray.indexOf(ingredient);
    if (index !== -1) {
      ingredientArray.splice(index, 1);
    }
  }


  deletePreference(ingredient: IngredientResponse){
    const isSet$ = this.store.select(selectIsJwtTokenSet);
    const jwtToken$ = this.store.select(selectJwtToken);

    combineLatest([isSet$, jwtToken$]).subscribe(([isSet, jwtToken]) => {
      if (isSet && jwtToken) {

        this.preferenceService.deletePreference({
          userId : Number(this.jwtHelper.decodeToken(jwtToken as string)['Id']),
          ingredientId : ingredient.id,
          type : undefined
        }, jwtToken as string).subscribe();
      }
    });
  }
}
