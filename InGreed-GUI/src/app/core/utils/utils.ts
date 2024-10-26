import { NavigationExtras, Router } from "@angular/router";
import { CategoryResponse } from "../models/models/category.response";
import { IngredientResponse } from "../models/models/ingredient.response";
import { SearchProductsPropsModel } from "../models/models/search-products-props.model";
import { paths } from "../../app-paths";
import { enumRole } from "../models/enums/role.enum";
import { selectIsJwtTokenSet, selectJwtToken } from "../store/jwt-token/jwt-token.selectors";
import { Store } from "@ngrx/store";
import { inject } from "@angular/core";
import { JwtHelperService } from "@auth0/angular-jwt";
import { ROLES_JWT_FIELD } from "../constants/constants";

export function navigateToSearchProduct(
  router: Router, 
  category: CategoryResponse | undefined, 
  phrase: string, 
  ingredients: IngredientResponse[], 
  showOnlyPremium: boolean = false,
  replaceUrl: boolean = false
 ) {
    const searchProductsProps: SearchProductsPropsModel = 
    new SearchProductsPropsModel(
        category,
        phrase,
        ingredients,
        showOnlyPremium
  )


  let navigationExtras: NavigationExtras = {
    state: {
      formValue: searchProductsProps
    },
    replaceUrl: replaceUrl
  };
  
  if (replaceUrl) {
    router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
      router.navigate([paths.searchProducts], navigationExtras);
    });
  } else {
    router.navigate([paths.searchProducts], navigationExtras);
  }
}

export function getEnumValueFromString<T extends Record<string, string>>(str: string, enumObj: T): T[keyof T] | undefined {
  const enumValues = Object.values(enumObj) as string[];
  if (enumValues.includes(str)) {
      return str as T[keyof T];
  }
  return undefined;
}

export function isJwtSet(store: Store): boolean {
  const isSet$ = store.select(selectIsJwtTokenSet);
  let isJwtSet = false;

  isSet$.subscribe(isSet => {
    isJwtSet = isSet
  })

  return isJwtSet
}

export function getJwtToken() {
  const store = inject(Store)
  const jwtToken$ = store.select(selectJwtToken)
  let myJwtToken: String = ""

  jwtToken$.subscribe(jwtToken => {
    myJwtToken = jwtToken
  })

  return myJwtToken
}

export function checkIfJwtTokenRoleIsEqual(userRole: enumRole): boolean {
  const jwtHelperService = inject(JwtHelperService)
  const jwtToken = getJwtToken();
  let role = ""

  if (jwtToken) {
    role = jwtHelperService.decodeToken(jwtToken as string)[ROLES_JWT_FIELD]
  }

  return role === userRole
}

export function navigateToHomeIfFalse(condition: boolean) {
  const router = inject(Router)

  if (!condition) {
    router.navigateByUrl('', {skipLocationChange: true}).then(() => {
      router.navigate(['']);
    });
  }
}

export function checkIfObjectIsInArrayOfObjects(obj: any, arr: any[]): boolean {
  return arr.some(arrObj => {
    return Object.keys(obj).every(key => obj[key] === arrObj[key]);
  });
}